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

        public static void Push()
        {
            // Send new data to API
        }

        public static void Pull()
        {
            // API fetching
        }
    }
}
