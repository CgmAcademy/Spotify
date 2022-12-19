using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class DataStore
    {
        public List<Artist> artists = new List<Artist>();
        public List<Album> albums = new List<Album>();
        public List<Song> song;
        public List<Playlist> playlists = new List<Playlist>();
        public List<Radio> radios = new List<Radio>();
        public static DataStore dataStore;

        
        DataStore()
        {
            song = Utility.CreateObject<Song>(Utility.ReadfromFile(Settings.musicpath));
            try
            {
                playlists = Utility.CreateObject<Playlist>(Utility.ReadfromFile(Settings.playlistpath));
                foreach (Playlist playlist in playlists)
                {
                    playlist.GeneratefromFile(song);
                }
            }
            catch
            {
                Console.WriteLine("No playlist found");
            }
            try
            {
                radios = Utility.CreateObject<Radio>(Utility.ReadfromFile(Settings.radiospath));
            }
            catch
            {
                Console.WriteLine("No radio found");
            }
            foreach (Song s in song)
            {
                s.CreateAlbum(albums);
            }
            foreach (Album album in albums)
            {
                album.CreateArtist(artists);
            }

        }
        public static DataStore GetInstance()
        {
            if(dataStore == null)
            {
                return dataStore = new DataStore(); 
            }
            else
            {
                return dataStore;
            }
            
        }
    }
}
