using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class Album
    {
        public string ArtistName { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public List<Song> Songs { get; set; }

        public Album(string Name, string title, Song song) 
        {
            ArtistName = Name;
            Title = title;
            Songs= new List<Song>();
            Songs.Add(song);
        }
        public void CreateArtist(List<Artist> artists)
        {

            for (int i = 0; i < artists.Count; i++)
            {
                if (artists[i].Name == ArtistName)
                {
                    foreach(Album album in artists[i].Albums) 
                    {
                        if (album.Title == Title)
                        {
                            return;
                        }
                        else
                        {
                            artists[i].Albums.Add(album);
                            return;
                        }
                    }
                }
            }
            artists.Add(new Artist(ArtistName, this));


        }
    }
}
