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
        static Page page;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            page = new Page();

            SearchState searchState = new SearchState();

            searchState.SetCallBack(changeState);
            
            page.SetState(searchState);

            this.Shown += delegate { FirstState(); };
        }

        public void FirstState()
        {
            Hide();
            page.Show();
        }

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

                page.SetState(newState);
                ((Form)sender).Hide();
                page.Show();
                 
            } catch(Exception ex)
            {
                MessageBox.Show("Starea este invalida");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
