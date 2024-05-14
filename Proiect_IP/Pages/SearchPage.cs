using Newtonsoft.Json;
using Proiect_IP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using static Proiect_IP.Res;
namespace Pages
{
    public partial class SearchPage : Form
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        public void SetCallBack(Action<object, States> action)
        {
            searchButton.Click += delegate { action(this, States.Movies_ListState); };
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            
            TMDbClient client = new TMDbClient("ba989c6148c4f9e4f7456f4d3ba6a8b7");

            string title = textBox1.Text;

            var movie = client.SearchMovieAsync(title).Result;
            var movies = movie.Results;

            SaveToJson(movies);
        }

        private void SaveToJson(object movies)
        {
            string JsonResult = JsonConvert.SerializeObject(movies);
            Res.WriteMovies(JsonResult);
            
        }
    }
}
