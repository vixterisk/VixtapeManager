using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    internal class PlaylistModel
    {
        /// <summary>
        /// Returns url of the youtube-playlist.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Returns the title of the playlist.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Returns the number of videos in the playlist.
        /// </summary>
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
        public PlaylistModel(string link, string title)
        {
            Link = link;
            Title = title;
            videos = new List<VideoModel>();
        }

        public PlaylistModel(string link, string title, List<VideoModel> videos)
        {
            Link = link;
            Title = title;
            this.videos = videos;
        }

        public VideoModel this[int index]
        {
            get { 
                return videos[index]; 
            }
            set { 
                videos[index] = value; 
            }
        }

        /// <summary>
        /// Adds a video at the end of the playlist.
        /// </summary>
        public void Add(VideoModel video)
        {
            videos.Add(video);
        }

        /// <summary>
        /// Inserts a video into the playlist at the specified index.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Insert(int index, VideoModel video)
        {
            // @TODO Fix try-catch to work properly 
            try
            {
                videos.Insert(index, video);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException(e.Message);
            }
        }

        /// <summary>
        /// Removes a video from the playlist at the specified index.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Remove(int index)
        {
            try
            {
                videos.RemoveAt(index);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException(e.Message);
            }
        }

        /// <summary>
        /// Creates a Video List from current playlist.
        /// </summary>
        /// <exception cref="PlaylistNullException"></exception>
        public List<VideoModel> GetVideos()
        {
            try
            {
                return videos.ToList();
            }
            catch (PlaylistNullException e)
            {
                throw new PlaylistNullException(e.Message);
            }
        }

        /// <summary>
        /// Moves a video in the playlist from one position to another.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Move(int oldIndex, int newIndex)
        {
            try
            {
                var video = videos[oldIndex];
                Remove(oldIndex);
                Insert(newIndex, video);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException(e.Message);
            }
        }
        public override string ToString()
        {
            return Title.ToString() + @", https://www.youtube.com/playlist?list=" + Link.ToString();
        }
    }
}
