using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    internal class VideoModel
    {
        public static readonly string LinkPrefix = @"https://youtu.be/";
        public string Link { get; set; }
        public string Title { get; set; }
        public string Channel { get; set; }
        public VideoModel()
        {
        }

        public VideoModel(string link, string title, string channel)
        {
            this.Link = link;
            this.Title = title;
            this.Channel = channel;
        }
    }
}
