using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    public class VideoIndexOutOFRangeException : ArgumentOutOfRangeException
    {
        public VideoIndexOutOFRangeException()
        {
        }

        public VideoIndexOutOFRangeException(string message)
            : base(message)
        {
        }
    }
    public class PlaylistNullException : ArgumentNullException
    {
        public PlaylistNullException()
        {
        }

        public PlaylistNullException(string message)
            : base(message)
        {
        }
    }

    public class VideoNullException : ArgumentNullException
    {
        public VideoNullException()
        {
        }

        public VideoNullException(string message)
            : base(message)
        {
        }
    }
}
