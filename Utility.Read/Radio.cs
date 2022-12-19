using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class Radio
    {
        public string Genre { get; set; }
        public string Name { get; set; }

        public Radio() { }
        public Radio(string genre, string name)
        {
            Genre= genre;
            Name= name;
            addTolist();
        }

        public void addTolist()
        {
            DataStore.dataStore.radios.Add(this);
            Utility.WriteonFile(Settings.radiospath, DataStore.dataStore.radios);
        }
    }
}
