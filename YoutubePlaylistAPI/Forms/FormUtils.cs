using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    internal static class FormUtils
    {
        public static bool isIndexValueValid(object value, int upperBound)
        {
            return value != null
                    && int.TryParse(value.ToString(), out int index)
                    && index >= 1
                    && index <= upperBound
                ;
        }
    }
}
