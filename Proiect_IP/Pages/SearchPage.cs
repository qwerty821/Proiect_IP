﻿using Newtonsoft.Json;
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
using TMDbLib.Objects.Search;
using static Proiect_IP.Res;
namespace Pages
{
    public partial class SearchPage : Form
    {
        private Action<object, States> _callBackFunc;

        public SearchPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
        }

        public void SetCallBack(Action<object, States> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            searchButton.Click += delegate { action(this, States.Movies_ListState); };
            _callBackFunc = action;
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
            Res.WriteMovies(movies);
        }

        private void SearchPage_Load(object sender, EventArgs e)
        {
            TMDbClient client = new TMDbClient("ba989c6148c4f9e4f7456f4d3ba6a8b7");
            var mov = client.GetMoviePopularListAsync().Result;
            var list = mov.Results;
            SaveToJson(list);

            foreach (SearchMovie movie in list)
            {
                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                //moviePanel.AutoSize = true;
                moviePanel.Size = new Size(300, 500);
                moviePanel.Padding = new Padding(25);
                moviePanel.BorderStyle = BorderStyle.FixedSingle;

                moviePanel.Click += delegate { SelectedMovie(movie); };

                moviePanel.Click += delegate {
                    _callBackFunc(this, States.Movie_InfoState);

                };

                Label title = new Label();
                title.Text = movie.Title;
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.Font = new Font("Microsoft Sans Serif", 20);
                title.Width = 240;
                title.Height = 70;
                title.BorderStyle = BorderStyle.FixedSingle;
                PictureBox pictureBox = new PictureBox();

                pictureBox.Click += delegate { SelectedMovie(movie); };

                pictureBox.Click += delegate {
                    _callBackFunc(this, States.Movie_InfoState);
                };

                pictureBox.Size = new Size(240, 350);
                pictureBox.ImageLocation = Res.imageUrl + movie.PosterPath;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(title);

                flowLayoutPanel1.Controls.Add(moviePanel);
            }
        }
        private void SelectedMovie(object sender)
        {
            Res.SetSelectedMovie(((SearchMovie)sender).Id);
        }

        public void SetLocation(Point p) => this.Location = p;
        public Point GetLocation() => this.Location;

    }
}
