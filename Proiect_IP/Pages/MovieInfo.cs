/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Dragan Valeriu                                 *
 *  E-mail:      valeriu.dragan@student.tuiasi.ro                         *
 *  Description: Contine clasa pentru pagina MovieInfo                    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Proiect_IP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Objects.Search;

namespace Pages
{
    public partial class MovieInfo : Form
    {
        private Action<object, States> _callBackFunc;
        public MovieInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
        }
        /// <summary>
        /// Metoda seteaza o functie de Callback pentru a apela o functie care schimba starea
        /// </summary>
        /// <param name="action"></param>
        public void SetCallBack(Action<object, States> action)
        {
            _callBackFunc = action;
            button1.Click += delegate { action(this, States.Search_PageState); };
        }

        /// <summary>
        /// Afiseaza informatiile despre filmul selectat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovieInfo_Load(object sender, EventArgs e)
        {
            SearchMovie movie = Res.GetSelectedMovie();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = Res.imageUrl + movie.PosterPath;
            
            title.Text = movie.Title;
            rating.Text = $"{movie.VoteAverage} ({movie.VoteCount})";
            year.Text = movie.ReleaseDate.ToString().Split(' ')[0];
            info3.Text = movie.MediaType.ToString();
            despre.Text = movie.Overview;

            ratingBar.ValueChanged += delegate { changeRating(); };

            string r = Res.GetRating();
            if (r != "")
            {
                setedRating.Visible = true;
                setedRating.Text = $"Ratingul dat de tine \r\neste {r}";
            }
        }

        /// <summary>
        /// Metoda este apelata cand utilizatorul interactioneza 
        /// cu valoare ratingului
        /// </summary>
        private void changeRating()
        {
            ratingLabel.Text = (ratingBar.Value + 1).ToString();
        }
        /// <summary>
        /// Metoda este apelata cand utilizatorul a apasat butonul de 
        /// confirmare al ratingului, respectiv afiseaza pe fereastra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            setedRating.Visible = true;
            setedRating.Text = $"Ratingul dat de tine \r\neste {(ratingBar.Value + 1)}" ;

            Res.SaveRating((ratingBar.Value + 1));
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

        private void MovieInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
