using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        public string PublishDateTime { get; set; }
        public VideoModel()
        {
        }

        public VideoModel(string link, string title, string channel, DateTime? date)
        {
            this.Link = link;
            this.Title = title;
            this.Channel = channel;
            if (date.HasValue)
                PublishDateTime = FormattedDate(date.Value.Date);
            else PublishDateTime = FormattedDate(DateTime.MinValue.Date);
        }

        string FormattedDate(DateTime date)
        {
            return date.ToUniversalTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
