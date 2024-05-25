/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Dragan Valeriu                                 *
 *  E-mail:      valeriu.dragan@student.tuiasi.ro                         *
 *  Description: Clasa pentru lucrul cu resursele aplicatiei              *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Proiect_IP
{
    /// <summary>
    /// Clasa pentru lucrul cu resursele aplicatiei
    /// </summary>
    public static class Res
    {
        public static string baseDirectory { get; set; }
        public static string ResDirectory { get; set; }
        public static string imageUrl { get; } = "https://image.tmdb.org/t/p/w500/";
        public static string moviesFile { get; } = "movies.json";
        public static string ratingFiles { get; } = "ratings.json";

        public static string helpFile { get; } = "HelpUser.chm"; 

        private static int SelectedMovie;

        /// <summary>
        /// Constructorul clasei pentru resurse
        /// </summary>
        static Res()
        {
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            baseDirectory = baseDirectory.Replace("Proiect_IP\\bin\\Debug\\", "") + "\\";

            ResDirectory = baseDirectory + "Res\\";
        }

        /// <summary>
        /// Metoda pentru salvarea filmelor intru-un fisier cu formatul json
        /// </summary>
        /// <param name="movies"></param>
        public static void WriteMovies(object movies)
        {
            string JsonResult = JsonConvert.SerializeObject(movies);
            File.WriteAllText(ResDirectory + moviesFile, JsonResult);
        }

        /// <summary>
        /// Metoda care returneaza filmele din fisierul json
        /// </summary>
        /// <returns>O lista de tipul List<SearchMovie></returns>
        public static List<SearchMovie> GetMovies()
        {
            string text;
            try
            {
                text = File.ReadAllText(ResDirectory + moviesFile);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException("Nu exista fisierul sau directorul" + $"{ResDirectory} + {moviesFile}");
            }

            List<SearchMovie> list = JsonConvert.DeserializeObject<List<SearchMovie>>(text);
            return list;
        }

        /// <summary>
        /// Metoda salveaza intr-o variabila statica filmul curent
        /// </summary>
        /// <param name="id"></param>
        public static void SetSelectedMovie(int id)
        {
            SelectedMovie = id;
        }

        /// <summary>
        /// Metoda returneaza filmul curent care este selectat
        /// </summary>
        /// <returns>Un obiect de tipul SearchMovie</returns>
        public static SearchMovie GetSelectedMovie()
        {
            List<SearchMovie> list = GetMovies();
            foreach (SearchMovie movie in list)
            {
                if (movie.Id == SelectedMovie)
                {
                    return movie;
                }
            }
            return null;
        }

        /// <summary>
        /// Metoda salveaza Ratingul filmului curent intr-un fisier json
        /// </summary>
        /// <param name="rating"></param>
        public static void SaveRating(int rating)
        {
            RatingObj obj = new RatingObj(SelectedMovie, rating);

            if (File.Exists(ResDirectory + ratingFiles))
            {
                string text = File.ReadAllText(ResDirectory + ratingFiles);
                List<RatingObj> list = JsonConvert.DeserializeObject<List<RatingObj>>(text);
                if (list == null)
                {
                    list = new List<RatingObj>();
                }
                bool exists = false;
                int index = -1;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id == obj.Id)
                    {
                        exists = true;
                        index = i;
                        break;
                    }
                }
                if (!exists)
                {
                    list.Add(obj);
                }
                else
                {
                    list[index].Rating = rating;
                }

                string jsonResult = JsonConvert.SerializeObject(list);
                File.WriteAllText(ResDirectory + ratingFiles, jsonResult);
            }
            else
            {
                string jsonResult = JsonConvert.SerializeObject(obj);
                File.Create(ResDirectory + ratingFiles);
                File.WriteAllText(ResDirectory + ratingFiles, jsonResult);
            }
        }

        public class RatingObj
        {
            public int Id;
            public int Rating;

            public RatingObj(int id, int rating)
            {
                this.Id = id;
                this.Rating = rating;
            }
        }

        /// <summary>
        /// Metoda returneaza ratingul filmului curent
        /// </summary>
        /// <returns>Ratingul sau un string gol</returns>
        public static string GetRating()
        {
            try
            {
                string text = File.ReadAllText(ResDirectory + ratingFiles);
                List<RatingObj> list = JsonConvert.DeserializeObject<List<RatingObj>>(text);

                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (SelectedMovie == list[i].Id)
                        {
                            return $"{list[i].Rating}";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return "";
            }

            return "";
        }

        public static string GetHelpPath()
        {
            return ResDirectory + helpFile;
        }
        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}