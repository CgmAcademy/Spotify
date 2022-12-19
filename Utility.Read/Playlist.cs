using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class Playlist
    {
        public string Name { get; set; }
        public string Author { get; set; }

        private List<Song> Songs = new List<Song>();

        public Playlist(string name, string author)
        {
            Name = name;
            Author = author;
            addTolist();
        }
        public Playlist()
        {

        }

        public void addTolist()
        {
            DataStore.dataStore.playlists.Add(this);
            Utility.WriteonFile(Settings.playlistpath, DataStore.dataStore.playlists);
        }
        public void AddSong(Song song)
        {
            Songs.Add(song);
            song.PlaylistName= Name;
            Utility.WriteonFile(Settings.musicpath, DataStore.dataStore.song);
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
            song.PlaylistName = null;
            Utility.WriteonFile(Settings.musicpath, DataStore.dataStore.song);
        }

        public void GeneratefromFile(List<Song> s)
        {
            foreach(Song song in s)
            {
                if(song.PlaylistName == Name)
                {
                    Songs.Add(song);
                }
            }
        }
    }
}
