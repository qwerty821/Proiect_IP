using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.Search;

namespace Proiect_IP
{
    public static class Resources
    {
        public static string baseDirectory { get; }
        public static string ResDirectory { get; }

        public static string imageUrl { get; } =  "https://image.tmdb.org/t/p/w500/";

        public static string moviesFile { get; } = "movies.json";

        static Resources()
        {
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            baseDirectory = baseDirectory.Replace("Proiect_IP\\bin\\Debug\\", "") + "\\";
        
            ResDirectory = baseDirectory + "Res\\";
        }

        public static void WriteMovies(string text)
        {
            File.WriteAllText(ResDirectory + moviesFile, text);
        }

        public static List<SearchMovie> GetMovies()
        {
            string text = File.ReadAllText(ResDirectory + moviesFile);
            List<SearchMovie> list = JsonConvert.DeserializeObject<List<SearchMovie>>(text);
          
            return list;
        }
    }
}
