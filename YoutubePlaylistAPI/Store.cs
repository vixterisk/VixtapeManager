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

        internal static async Task LoadCurrentPlaylistVideosAsync()
        {
            var controller = new YoutubeAPIController();
            var videos = await controller.LoadPlaylistVideos(CurrentPlaylist.Link);
            CurrentPlaylist = new PlaylistModel(CurrentPlaylist.Link, videos);
        }

        internal static async Task LoadUserPlaylistsAsync()
        {
            UsersPlaylist = new List<PlaylistModel>();
            var controller = new YoutubeAPIController();
            UsersPlaylist = await controller.LoadUserPlaylists();
        }

        public static async Task RemoveFromCurrentPlaylist(int index, string videoURL)
        {
            var controller = new YoutubeAPIController();
            try
            {
                await controller.RemoveVideoFromPlaylist(CurrentPlaylist.Link, index, videoURL);
                CurrentPlaylist.Remove(index);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static async Task AddToCurrentPlaylistAsync(string videoURL)
        {
            var controller = new YoutubeAPIController(); 
            try
            {
                var video = await controller.InsertVideoIntoPlaylist(CurrentPlaylist.Link, CurrentPlaylist.Count, videoURL);
                CurrentPlaylist.Add(video);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task InsertIntoCurrentPlaylistAsync(int index, string videoURL)
        {
            var controller = new YoutubeAPIController();
            try
            {
                var video = await controller.InsertVideoIntoPlaylist(CurrentPlaylist.Link, index, videoURL);
                CurrentPlaylist.Insert(index, video);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        internal static async Task MoveToNewPositionInCurrentPlaylist(int oldIndex, int newIndex, string videoURL)
        {
            var controller = new YoutubeAPIController();
            try
            {
                await controller.UpdateVideoPositionInPlaylist(CurrentPlaylist.Link, oldIndex, newIndex, videoURL);
                CurrentPlaylist.Move(oldIndex, newIndex);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
