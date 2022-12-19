using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class Song
    {
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string Title { get; set; }
        public int Popularity { get; set; }
        public string PlaylistName { get; set; }
        public string Genre { get; set; }
        public Song() 
        {
            
        }
        public void CreateAlbum(List<Album> albums)
        {
            
            for (int i = 0; i < albums.Count; i++)
            {
                if (albums[i].ArtistName == ArtistName)
                {
                    if (albums[i].Title == AlbumName)
                    {
                        albums[i].Songs.Add(this);
                        return;
                    }
                }
            }
            albums.Add(new Album(ArtistName, AlbumName, this));
            
            
        }
    }
}
