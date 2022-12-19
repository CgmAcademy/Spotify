using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utility.Read
{
    public static class Utility
    {

        public static List<string> ReadfromFile(string path) 
        {
            var lines = File.ReadAllLines(path).ToList();
            return lines;
        }

        public static List<T> CreateObject<T>(List<string> lines) where T : class, new()
        {
            List<T> list = new List<T>();
            string[] headers = lines.ElementAt(0).Split(',');
            lines.RemoveAt(0);
            bool corretto = false;
            bool p = true;
            T entry = new T();
            var prop = entry.GetType().GetProperties();

            if (prop.Length == headers.Length)
            {
                for (int i = 0; i < prop.Length; i++)
                {

                    if (prop.ElementAt(i).Name == headers[i])
                    {
                        corretto = true;
                    }
                    else p = false;

                }
            }

            if (corretto && p)
            {
                foreach (var line in lines)
                {
                    int j = 0;
                    string[] colons = line.Split(',');
                    entry = new T();
                    foreach (var col in colons)
                    {
                        entry.GetType().GetProperty(headers[j]).SetValue(entry, Convert.ChangeType(col, entry.GetType().GetProperty(headers[j]).PropertyType));
                        j++;
                    }
                    list.Add(entry);
                }
            }
            else Console.WriteLine("le proprietà nel file non corrispondono a proprietà oggetto");

            return list;
        }

        public static void WriteonFile<T>(string path, List<T> ts) where T : class, new()
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var cols = ts[0].GetType().GetProperties();

            if (!File.Exists(path))
            {
                foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
                {
                    sb.Append(col.Name);
                    sb.Append(',');
                }

                list.Add(sb.ToString().Substring(0, sb.Length - 1));

            }
            foreach (var row in ts)
            {

                sb = new StringBuilder();
                foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
                {

                    sb.Append(col.GetValue(row));
                    sb.Append(',');


                }
                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }
            File.AppendAllLines(path, list);
        }

        public static void GetSettings()
        {
            var services = new ServiceCollection();
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            services.AddSingleton<Settings>();
            OptionsConfigurationServiceCollectionExtensions.Configure<Settings>(services, config.GetSection("settings"));
            config.GetRequiredSection("settings").Get<Settings>();
        }

        public static List<string> TopArtist()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            List<string> list = new List<string>();
            int i = 0;
            foreach (Artist artist in DataStore.dataStore.artists)
            {
                foreach (Song song in DataStore.dataStore.song)
                {
                    if (song.ArtistName == artist.Name)
                    {
                        i += song.Popularity;
                    }
                }
                dict.Add(artist.Name, i);

                i = 0;
            }

            foreach (KeyValuePair<string, int> kvp in dict.OrderBy(x => x.Value).Reverse().Take(5))
            {
                list.Add(kvp.Key);
            }



            return list;
        }

       

    }
}
