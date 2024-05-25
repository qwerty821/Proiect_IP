/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Ursu Catalin                                   *
 *  E-mail:      catalin-eugen.ursu@student.tuiasi.ro                     *
 *  Description: Contine clasa penrtu pagina Movies                       *
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Objects.Search;
using static Proiect_IP.Res;
namespace Pages
{
    public partial class Movies : Form
    {

        private List<SearchMovie> list;

        private Action<object, States> _callBackFunc;
        /// <summary>
        /// Constructorul ferestrei Movies
        /// </summary>
        public Movies()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
        }
        /// <summary>
        /// Inițializează lista de filme și le afișează.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Movies_Load(object sender, EventArgs e)
        {
            list = Res.GetMovies();
            displayMovies();
        }
        /// <summary>
        /// Afișează lista de filme pe fereastra.
        /// Creează elemente UI pentru fiecare film și le adaugă în flowLayoutPanel1.
        /// </summary>
        private void displayMovies()
        {
            if (list == null)
            {
                return;
            }
            foreach(SearchMovie movie in list)
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
        /// Setează funcția de callback care va fi apelată în anumite evenimente.
        /// </summary>
        /// <param name="action">Un delegat de tipul Action</param>
        public void SetCallBack(Action<object, States> action)
        {
           _callBackFunc = action;
            buttonAcasa.Click += delegate { action(this, States.Search_PageState); };
           
        }
        /// <summary>
        /// Setează filmul selectat în Res.
        /// </summary>
        /// <param name="sender">Obiect</param>
        private void SelectedMovie(object sender)
        {
            Res.SetSelectedMovie(((SearchMovie)sender).Id);
        }

        /// <summary>
        /// Seteaza locatia ferestrei
        /// </summary>
        /// <param name="p">Un Point  care contine x,y</param>
        public void SetLocation(Point p) => this.Location = p;
        /// <summary>
        ///  Returnaza Locatia ferestrei
        /// </summary>
        /// <returns>Valorile x,y sub forma unui Point</returns>
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

        private void Movies_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
