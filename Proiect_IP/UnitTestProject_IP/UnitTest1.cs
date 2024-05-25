using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proiect_IP;
using System;
using Pages;
using System.IO;
using System.Collections.Generic;
using TMDbLib.Objects.Search;
namespace UnitTestProject_IP
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Res_GetRating_Without_Selected_Movie()
        {
            Assert.AreEqual("", Res.GetRating());
        }


        [TestMethod]
        public void Test_Page_With_Different_State()
        {
            Page page = new Page();
            page.SetState(new SearchState());
            Assert.IsNotInstanceOfType(page.GetState(), typeof(MovieInfoState));
        }


        [TestMethod]
        public void Test_Page_With_Same_State()
        {
            Page page = new Page();
            page.SetState(new SearchState());
            Assert.IsInstanceOfType(page.GetState(), typeof(SearchState));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Page_With_Null_State()
        {
            Page page = new Page();
            page.SetState(null);
            page.Show();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Null_State()
        {
            Page page = new Page(); 
            page.SetState(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Null_Call_Back_Function()
        {
            SearchPage search = new  SearchPage();
            search.SetCallBack(null);
            
        }
        

        [TestMethod]
        public void Test_Get_Movies_With_Empty_File()
        {
            File.Delete(Res.ResDirectory + Res.moviesFile);
            File.Create (Res.ResDirectory + Res.moviesFile);
            Assert.IsNull(Res.GetMovies());
        }

        [TestMethod]
        [ExpectedException (typeof(NullReferenceException))]
        public void Test_Get_Selected_Movie_With_Empty_File()
        {
            File.Delete(Res.ResDirectory + Res.moviesFile);
            File.Create(Res.ResDirectory + Res.moviesFile);
            Res.GetSelectedMovie();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_Internet_Conection()
        {
            SearchPage page = new SearchPage();
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Res_Write_Null_Movies()
        {
           Res.WriteMovies(null);   

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_Negative_SelectedMovie_Id()
        {
            Res.SetSelectedMovie(-1);

        }

        [TestMethod]
        [Timeout(2000)] 
        public void Test_SearchPage_2_seconds()
        {
            SearchPage searchPage = new SearchPage();
        }

        [TestMethod]
        [Timeout(2000)]
        public void Test_Movies_2_seconds()
        {
            Movies searchPage = new Movies();
        }

        [TestMethod]
        [Timeout(2000)]
        public void Test_MovieInfo_2_seconds()
        {
            MovieInfo minfo = new MovieInfo();
        }

        [TestMethod]
        [Timeout(500)]
        public void Test_Res_Write_1000_Movies_Save_500_milliseconds()
        {
            List<SearchMovie> searchMovies = new List<SearchMovie>();
            for (int i = 0; i < 1000; i++)
            {
                searchMovies.Add(new SearchMovie() { 
                    Title = "test",
                    Id = i,
                    ReleaseDate = DateTime.Now,
                    BackdropPath = "test",
                });
            }

            Res.WriteMovies(searchMovies);
        }
        [TestMethod]
        [Timeout(500)]
        public void Test_Res_Read_1000_Movies_500_milliseconds()
        {

            var m = Res.GetMovies();
        }

        [TestMethod]
        [Timeout(2000)]
        public void Test_Res_Write_100000_Movies_Save_2_seconds()
        {
            List<SearchMovie> searchMovies = new List<SearchMovie>();
            for (int i = 0; i < 100000; i++)
            {
                searchMovies.Add(new SearchMovie()
                {
                    Title = "test",
                    Id = i,
                    ReleaseDate = DateTime.Now,
                    BackdropPath = "test",
                });
            }

            Res.WriteMovies(searchMovies);
        }

        [TestMethod]
        [Timeout(2000)]
        public void Test_Res_Read_100000_Movies_2_seconds()
        {
            var m = Res.GetMovies();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Test_Res_Read_Movies_File_Not_Found()
        {
            File.Delete(Res.ResDirectory + Res.moviesFile);
            var m = Res.GetMovies();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Test_Res_Read_Rating_File_Not_Found()
        {
            File.Delete(Res.ResDirectory + Res.moviesFile);
            var m = Res.GetRating();
        }



    }
}
