/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Butnaru Dan                                    *
 *  E-mail:      dan.butnaru@student.tuiasi.ro                            *
 *  Description: Contine clasa pentru pagina de cautare                   *
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
using Proiect_IP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        /// <summary>
        /// Constructorul Ferestrei SearchPage
        /// </summary>
        public SearchPage()
        {
            try
            {
                InitializeComponent();
            } catch(Exception ex) {
                Console.WriteLine("aaaaaaaaaa");
                throw new Exception(ex.Message);
            }
            this.StartPosition = FormStartPosition.Manual;
        }

        /// <summary>
        /// Setează funcția de callback care va fi apelată în anumite evenimente.
        /// </summary>
        /// <param name="action">Un delegat de tipul Action</param>
        public void SetCallBack(Action<object, States> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            searchButton.Click += delegate { action(this, States.Movies_ListState); };
            _callBackFunc = action;
        }

        /// <summary>
        /// 1.Metoda este apelata la apasarea butonului de cautare.
        /// 2.Se face conexiunea la API si efectueaza cutare filmului introdus de utilizator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            
            TMDbClient client = new TMDbClient("ba989c6148c4f9e4f7456f4d3ba6a8b7");

            string title = textBox1.Text;

            var movie = client.SearchMovieAsync(title).Result;
            var movies = movie.Results;
            SaveToJson(movies);
        }
        /// <summary>
        /// Salveaza lista de filme intr-un fiser
        /// </summary>
        /// <param name="movies"></param>
        private void SaveToJson(object movies)
        {
            Res.WriteMovies(movies);
        }
        /// <summary>
        /// Metoda este apelata la intilizare ferestrei SearchPage, dupa care se conecteza la API
        /// si afiseaza ce mai populare filme la moment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchPage_Load(object sender, EventArgs e)
        {
            
            TMDbClient client = new TMDbClient("ba989c6148c4f9e4f7456f4d3ba6a8b7");
            
            if (Res.CheckInternetConnection() == false)
            {
                throw new Exception("Aplicatia nu este conectata la internet");
            }

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
        /// <summary>
        /// Salveaza in resurse filmul selectat
        /// </summary>
        /// <param name="sender"></param>
        private void SelectedMovie(object sender)
        {
            Res.SetSelectedMovie(((SearchMovie)sender).Id);
        }
        /// <summary>
        /// Seteaza loactia ferestrei
        /// </summary>
        /// <param name="p"></param>
        public void SetLocation(Point p) => this.Location = p;
        /// <summary>
        /// Returneaza locatia ferestrei
        /// </summary>
        /// <returns></returns>
        public Point GetLocation() => this.Location;
        /// <summary>
        /// Afiseaza help-ul
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Res.GetHelpPath());
        }
    }
}
