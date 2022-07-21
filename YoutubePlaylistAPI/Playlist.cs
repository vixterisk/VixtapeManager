using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    internal class Playlist
    {
        public string Link { get; set; }

        readonly List<Video> videos;
        public Playlist()
        {
            videos = new List<Video>();
        }

        public Playlist(string link, List<Video> videos)
        {
            Link = link;
            this.videos = videos;
        }

        public void Add(Video video)
        {
            videos.Add(video);
        }

        public void Insert(int index, Video video)
        {
            videos.Insert(index, video);
        }

        public void Remove(int index)
        {
            videos.RemoveAt(index);
        }

        public Video GetVideoByIndex(int i)
        {
            return videos[i];
        }

        public List<Video> GetVideos()
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
