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
            
            Action<object> action = changeState;
            searchState.SetCallBack(action);
            
            page.SetState(searchState);

            this.Shown += delegate { FirstState(); };
        }

        public void FirstState()
        {
            Hide();
            page.Show();
        }

        public void changeState(object sender)
        {
            page.SetState(new MoviesListState());
            ((Form)sender).Hide();
            page.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
