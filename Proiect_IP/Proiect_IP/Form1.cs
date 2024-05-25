/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Dragan Valeriu                                 *
 *  E-mail:      valeriu.dragan@student.tuiasi.ro                         *
 *  Description: Aicie este punctul de start al aplicatiei                *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using static System.Net.Mime.MediaTypeNames;
using Pages;
namespace Proiect_IP
{
    public partial class Form1 : Form
    {
        Page page;
        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// De aici este initializata aplicatia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            IState state = new MovieInfoState();
            try
            {
                page = new Page();

                SearchState searchState = new SearchState();

                searchState.SetCallBack(changeState);

                page.SetState(searchState);

                this.Shown += delegate { FirstState(); };
            } catch(Exception ex)
            {
                MessageBox.Show("Starea este invalida");
            }
        }
        /// <summary>
        /// Se afiseaza prima stare
        /// </summary>
        public void FirstState()
        {

            Hide();
            page.Show();

        }

        /// <summary>
        /// Metoda principala care face posibl schimbarea starilor
        /// </summary>
        /// <param name="sender">Ferestra curenta</param>
        /// <param name="state">Noua stare</param>
        public void changeState(object sender, States state)
        {
            try
            {
                IState newState = null;
                switch (state)
                {
                    case States.Search_PageState: newState = new SearchState(); break;
                    case States.Movies_ListState: newState = new MoviesListState(); break;
                    case States.Movie_InfoState: newState = new MovieInfoState(); break;
                    default: return;
                }

                newState.SetCallBack(changeState);

                Point p = page.GetLocation();

                Console.WriteLine(p);

                page.SetState(newState);
                
                page.SetLocation(p);
                
                ((Form)sender).Hide();
                page.Show();
                 
            } catch(Exception ex)
            {
                MessageBox.Show("Starea este invalida");
            }
        }
 
    }
}
