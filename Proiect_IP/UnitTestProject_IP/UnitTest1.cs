using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proiect_IP;
using System;
using Pages;
using System.IO;
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
           Assert.IsNull(Res.GetMovies());
        }

        [TestMethod]
        [ExpectedException (typeof(NullReferenceException))]
        public void Test_Get_Selected_Movie_With_Empty_File()
        {
             Res.GetSelectedMovie();
        }

        [Ignore]
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_Internet_Conection()
        {
            SearchPage page = new SearchPage();
            

        }





    }
}
