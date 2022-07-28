using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    static class Store
    {
        public static List<PlaylistModel> UsersPlaylist { get; set; }
        public static PlaylistModel CurrentPlaylist { get; set; }

        internal static async Task LoadCurrentPlaylistVideosAsync(PlaylistModel playlistModel)
        {
            var videos = await YoutubeAPIController.LoadPlaylistVideos(playlistModel.Link);
            CurrentPlaylist = new PlaylistModel(playlistModel.Link, playlistModel.Title, playlistModel.Description, videos);
        }

        internal static async Task LoadUserPlaylistsAsync()
        {
            UsersPlaylist = new List<PlaylistModel>();
            UsersPlaylist = await YoutubeAPIController.LoadUserPlaylists();
        }

        public static async Task RemoveFromCurrentPlaylist(int index, string videoURL)
        {
            try
            {
                await YoutubeAPIController.RemoveVideoFromPlaylist(CurrentPlaylist.Link, index, videoURL);
                CurrentPlaylist.RemoveAt(index);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static async Task AddToCurrentPlaylistAsync(string videoURL)
        {
            try
            {
                var video = await YoutubeAPIController.InsertVideoIntoPlaylist(CurrentPlaylist.Link, CurrentPlaylist.Count, videoURL);
                CurrentPlaylist.Add(video);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task InsertIntoCurrentPlaylistAsync(int index, string videoURL)
        {
            try
            {
                var video = await YoutubeAPIController.InsertVideoIntoPlaylist(CurrentPlaylist.Link, index, videoURL);
                CurrentPlaylist.Insert(index, video);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        internal static async Task MoveToNewPositionInCurrentPlaylist(int oldIndex, int newIndex, string videoURL)
        {
            try
            {
                await YoutubeAPIController.UpdateVideoPositionInPlaylist(CurrentPlaylist.Link, oldIndex, newIndex, videoURL);
                CurrentPlaylist.Move(oldIndex, newIndex);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
