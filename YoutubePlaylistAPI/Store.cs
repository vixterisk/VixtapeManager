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

        internal static async Task LoadPlaylistVideosAsync()
        {
            var controller = new YoutubeAPIController();
            await controller.LoadPlaylistVideos(CurrentPlaylist.Link);
        }

        internal static async Task LoadUserPlaylistsAsync()
        {
            UsersPlaylist = new List<PlaylistModel>();
            var controller = new YoutubeAPIController();
            await controller.LoadUserPlaylists();
        }

        public static void RemoveFromCurrentPlaylist(int index)
        {
            CurrentPlaylist.Remove(index);
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

        internal static void MoveToNewPositionInCurrentPlaylist(int oldIndex, int newIndex)
        {
            CurrentPlaylist.Move(oldIndex, newIndex);
        }
    }
}
