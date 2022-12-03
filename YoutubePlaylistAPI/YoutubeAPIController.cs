using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    internal static class YoutubeAPIController
    {
        // TODO: change path to smth normal
        const string clientSecretPath = @"client_secrets.json";
        const string applicationName = "Vixtape Manager";

        public static readonly string LinkPrefix = @"https://youtu.be/";
        private static string LinkWithoutPrefix(string link)
        {
            if (link == null)
                throw new ArgumentNullException();
            return link.Replace(LinkPrefix, "");
        }

        public static async Task<List<PlaylistModel>> LoadUserPlaylists()
        {
            UserCredential credential;
            using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { YouTubeService.Scope.Youtube },
                    "user",
                    CancellationToken.None
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            var playlistListRequest = youtubeService.Playlists.List("snippet");
            playlistListRequest.Mine = true;
            playlistListRequest.MaxResults = 50;

            var result = new List<PlaylistModel>();
            do
            {
                var playlistListResponse = await playlistListRequest.ExecuteAsync();
                foreach (var playlist in playlistListResponse.Items)
                {
                    var playlistListId = playlist.Id;
                    var playlistListName = playlist.Snippet.Title;
                    var playlistDescription = playlist.Snippet.Description;

                    var currentPlaylist = new PlaylistModel(playlistListId, playlistListName, playlistDescription);
                    result.Add(currentPlaylist);
                }
                playlistListRequest.PageToken = playlistListResponse.NextPageToken;
            } while (playlistListRequest.PageToken != null);
            return result;
        }

        public static async Task<List<VideoModel>> LoadPlaylistVideos(string playlistURL)
        {
            UserCredential credential;
            using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { YouTubeService.Scope.Youtube },
                    "user",
                    CancellationToken.None
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
            playlistItemsListRequest.PlaylistId = playlistURL;
            playlistItemsListRequest.MaxResults = 50;

            var result = new List<VideoModel>();
            do
            {
                var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
                foreach (var video in playlistItemsListResponse.Items)
                {
                    var videoId = $"{LinkPrefix}{video.Snippet.ResourceId.VideoId}";
                    var videoTitle = video.Snippet.Title;
                    var videoChannelTitle = video.Snippet.VideoOwnerChannelTitle;

                    var currentVideo = new VideoModel(videoId, videoTitle, videoChannelTitle);
                    result.Add(currentVideo);
                }
                playlistItemsListRequest.PageToken = playlistItemsListResponse.NextPageToken;
            } while (playlistItemsListRequest.PageToken != null);
            return result;
        }

        public static async Task UpdateVideoPositionInPlaylist(string playlistURL, int oldIndex, int newIndex, string fullVideoURL)
        {
            var videoURL = LinkWithoutPrefix(fullVideoURL);
            UserCredential credential;
            using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { YouTubeService.Scope.Youtube },
                    "user",
                    CancellationToken.None
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
            playlistItemsListRequest.PlaylistId = playlistURL;
            playlistItemsListRequest.VideoId = videoURL;

            var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
            foreach (var video in playlistItemsListResponse.Items)
            {
                var newPlaylistItem = video;
                newPlaylistItem.Snippet.Position = newIndex;
                
                var request = youtubeService.PlaylistItems.Update(newPlaylistItem, "snippet");
                await request.ExecuteAsync();
            }
        }



        public static async Task<VideoModel> InsertVideoIntoPlaylist(string playlistURL, bool hasManualSorting, int index, string fullVideoURL)
        {
            var videoURL = LinkWithoutPrefix(fullVideoURL);
            UserCredential credential;
            using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { YouTubeService.Scope.Youtube },
                    "user",
                    CancellationToken.None
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            var newPlaylistItem = new PlaylistItem();
            newPlaylistItem.Snippet = new PlaylistItemSnippet();
            if (hasManualSorting)
                newPlaylistItem.Snippet.Position = index;
            newPlaylistItem.Snippet.PlaylistId = playlistURL;
            newPlaylistItem.Snippet.ResourceId = new ResourceId();
            newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
            newPlaylistItem.Snippet.ResourceId.VideoId = videoURL;
            try
            {
                newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();
                return new VideoModel(fullVideoURL, newPlaylistItem.Snippet.Title, newPlaylistItem.Snippet.VideoOwnerChannelTitle);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task RemoveVideoFromPlaylist(string playlistURL, int index, string fullVideoURL)
        {
            var videoURL = LinkWithoutPrefix(fullVideoURL);
            UserCredential credential;
            using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { YouTubeService.Scope.Youtube },
                    "user",
                    CancellationToken.None
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
            playlistItemsListRequest.PlaylistId = playlistURL;
            playlistItemsListRequest.VideoId = videoURL;

            var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
            foreach (var video in playlistItemsListResponse.Items)
            {
                var resourceId = video.Id;
                var position = video.Snippet.Position;

                if (position == index) {
                    var request = youtubeService.PlaylistItems.Delete(resourceId);
                    await request.ExecuteAsync();
                }
            }
        }
    }
}
