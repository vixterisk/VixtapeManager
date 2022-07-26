﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistAPI
{
    static class State
    {
        public static Playlist CurrentPlaylist { get; set; }

        public static void FillTest()
        {
            CurrentPlaylist = new Playlist();
            CurrentPlaylist.Add(new Video(@"https://youtu.be/RU5HQllMg2M", "Doja", "Rules"));
            CurrentPlaylist.Add(new Video(@"https://youtu.be/XfR239JKMEo", "Weeknd", "Can't feel my face"));
            CurrentPlaylist.Add(new Video(@"https://youtu.be/POb02mjj2zE", "TWICE", "Likey"));
            CurrentPlaylist.Add(new Video(@"https://youtu.be/SH2l0H_Rzxg", "Mashup", "K/DA x BLACKPINK – More /How You Like That /The Baddest /Ddu-du Ddu-du /Kill This Love MASHUP"));
            CurrentPlaylist.Add(new Video(@"https://youtu.be/pvErlF7Ihrc", "CRAVEN", "Mr. Gambino"));
            CurrentPlaylist.Add(new Video(@"https://youtu.be/zBOz5MLC-nI", "Мэшап", "НУ И КАК ТАМ В ЕГИПТЕ?"));
            CurrentPlaylist.Add(new Video(@"https://youtu.be/oz0_ESST2YU", "Draco and the Malfoys", "Amortentia"));
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
