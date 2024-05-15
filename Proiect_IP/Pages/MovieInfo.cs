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
        }

        public void SetCallBack(Action<object, States> action)
        {
            _callBackFunc = action;
            button1.Click += delegate { action(this, States.Search_PageState); };
        }

        private void MovieInfo_Load(object sender, EventArgs e)
        {
            SearchMovie movie = Res.GetSelectedMovie();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = Res.imageUrl + movie.PosterPath;
            
            title.Text = movie.Title;
            rating.Text = $"{movie.VoteAverage} ({movie.VoteCount})";
            year.Text = movie.ReleaseDate.ToString();
            despre.Text = movie.Overview;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
