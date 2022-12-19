using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class Artist
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public List<Album> Albums { get; set; }

        public Artist(string name, Album album)
        {
            Name = name;
            Albums = new List<Album>();
            Albums.Add(album);
        }
    }
}
