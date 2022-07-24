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
    internal class YoutubeAPIController
    {
        public async Task LoadUserPlaylists()
        {
            UserCredential credential;
            //@TODO change path to smth normal
            using (var stream = new FileStream(@"D:\VS_Projects\ypA\YoutubePlaylistAPI\YoutubePlaylistAPI\client_secrets.json", FileMode.Open, FileAccess.Read))
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
                ApplicationName = this.GetType().ToString()
            });

            var playlistListRequest = youtubeService.Playlists.List("snippet");
            playlistListRequest.Mine = true;
            playlistListRequest.MaxResults = 50;
            do
            {
                var playlistListResponse = await playlistListRequest.ExecuteAsync();
                foreach (var playlist in playlistListResponse.Items)
                {
                    var playlistListId = playlist.Id;
                    var playlistListName = playlist.Snippet.Title;

                    var currentPlaylist = new PlaylistModel(playlistListId, playlistListName);
                    Store.UsersPlaylist.Add(currentPlaylist);
                }
                playlistListRequest.PageToken = playlistListResponse.NextPageToken;
            } while (playlistListRequest.PageToken != null);
        }

        public async Task LoadPlaylistVideos(string playlistURL)
        {
            UserCredential credential;
            using (var stream = new FileStream(@"D:\VS_Projects\ypA\YoutubePlaylistAPI\YoutubePlaylistAPI\client_secrets.json", FileMode.Open, FileAccess.Read))
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
                ApplicationName = this.GetType().ToString()
            });

            var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
            playlistItemsListRequest.PlaylistId = playlistURL;
            playlistItemsListRequest.MaxResults = 50;
            do
            {
                var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
                foreach (var video in playlistItemsListResponse.Items)
                {
                    var videoId = video.Snippet.ResourceId.VideoId;
                    var videoTitle = video.Snippet.Title;
                    var videoChannelTitle = video.Snippet.VideoOwnerChannelTitle;

                    var currentVideo = new VideoModel(videoId, videoTitle, videoChannelTitle);
                    Store.CurrentPlaylist.Add(currentVideo);
                }
                playlistItemsListRequest.PageToken = playlistItemsListResponse.NextPageToken;
            } while (playlistItemsListRequest.PageToken != null);
        }
    }
}
