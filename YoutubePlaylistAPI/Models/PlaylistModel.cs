using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    internal class PlaylistModel : IList
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
        /// Returns the description of the playlist.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Returns the number of videos in the playlist.
        /// </summary>
        public int Count => videos.Count;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;
        // TODO: ?
        public object SyncRoot => this;
        // TODO: ?
        public bool IsSynchronized => true;

        object IList.this[int index] { get => videos[index]; set { videos[index] = (VideoModel)value; } }

        List<VideoModel> videos = new List<VideoModel>();
        public PlaylistModel()
        {
        }

        public PlaylistModel(string link, string title, string description)
        {
            Link = link;
            Title = title;
            Description = description;
        }

        public PlaylistModel(string link, string title, string description, List<VideoModel> videos) : this(link, title, description)
        {
            this.videos = videos;
        }

        public override string ToString()
        {
            return Title.ToString() + @", https://www.youtube.com/playlist?list=" + Link.ToString();
        }

        /// <summary>
        /// Adds a video at the end of the playlist. Returns index of the element if successful and -1 otherwise.
        /// </summary>
        public int Add(Object value)
        {
            if (value == null || !(value is VideoModel))
                return -1;
            videos.Add((VideoModel)value);
            return videos.Count;
        }

        public bool Contains(Object value)
        {
            return videos.Contains(value);
        }

        public void Clear()
        {
            videos.Clear();
        }

        public int IndexOf(Object value)
        {
            return videos.IndexOf((VideoModel)value);
        }

        /// <summary>
        /// Inserts a video into the playlist at the specified index.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Insert(int index, object value)
        {
            if (index < 0 || index > videos.Count)
            {
                throw new IndexOutOfRangeException("Video Index was invalid.");
            }
            videos.Insert(index, (VideoModel)value);
        }
        /// <summary>
        /// Removes a video from the playlist.
        /// </summary>
        public void Remove(Object value)
        {
            videos.Remove((VideoModel)value);
        }
        /// <summary>
        /// Removes a video from the playlist at the specified index.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > videos.Count)
            {
                throw new IndexOutOfRangeException("Video Index was invalid.");
            }
            videos.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            videos.CopyTo((VideoModel[])array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return null;
        }

        /// <summary>
        /// Creates a Video List from current playlist.
        /// </summary>
        /// <exception cref="PlaylistNullException"></exception>
        public List<VideoModel> GetVideos()
        {
            if (videos == null)
            {
                throw new PlaylistNullException("Playlist was null.");
            }
            return videos.ToList();
        }

        /// <summary>
        /// Moves a video in the playlist from one position to another.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <exception cref="PlaylistNullException"></exception>
        public void Move(int oldIndex, int newIndex)
        {
            if (videos == null)
            {
                throw new PlaylistNullException("Playlist was null.");
            }
            try
            {
                var video = videos[oldIndex];
                RemoveAt(oldIndex);
                Insert(newIndex, video);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException(e.Message);
            }
        }
    }
}
