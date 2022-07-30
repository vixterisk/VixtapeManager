using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    internal class VideoModel //: IBindingListView
    {
        [Index(0)]
        public string Link { get; set; }
        [Index(1)]
        public string Title { get; set; }
        [Index(2)]
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
