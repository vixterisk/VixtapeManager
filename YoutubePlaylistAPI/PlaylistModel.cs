using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    internal class PlaylistModel
    {
        public string Link { get; set; }
        public int Count { get { return videos.Count; } }

        readonly List<VideoModel> videos;
        public PlaylistModel()
        {
            videos = new List<VideoModel>();
        }

        public PlaylistModel(string link, List<VideoModel> videos)
        {
            Link = link;
            this.videos = videos;
        }

        public void Add(VideoModel video)
        {
            videos.Add(video);
        }

        public void Insert(int index, VideoModel video)
        {
            videos.Insert(index, video);
        }

        public void Remove(int index)
        {
            videos.RemoveAt(index);
        }

        public VideoModel GetVideoByIndex(int i)
        {
            return videos[i];
        }

        public List<VideoModel> GetVideos()
        {
            return videos.ToList();
        }
        public void Move(int oldIndex, int newIndex)
        {
            var video = GetVideoByIndex(oldIndex);
            Remove(oldIndex);
            Insert(newIndex, video);
        }
    }
}
