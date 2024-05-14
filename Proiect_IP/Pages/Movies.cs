using Newtonsoft.Json;
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
    public partial class Movies : Form
    {

        private List<SearchMovie> list;

        public Movies()
        {
            InitializeComponent();
        }

        private void Movies_Load(object sender, EventArgs e)
        {
            list = Resources.GetMovies();

            displayMovies();
        }

        private void displayMovies()
        {
            
            foreach(SearchMovie movie in list)
            {
                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                //moviePanel.AutoSize = true;
                moviePanel.Size = new Size(360, 600);
                moviePanel.Padding = new Padding(25);
                moviePanel.BorderStyle = BorderStyle.FixedSingle;
                


                Label title = new Label();
                title.Text = movie.Title;
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.Font = new Font("Microsoft Sans Serif", 20);
                title.Width = 300;
                title.Height = 70;
                title.BorderStyle = BorderStyle.FixedSingle;
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(300, 450);
                pictureBox.ImageLocation = Resources.imageUrl + movie.PosterPath;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(title);

                flowLayoutPanel1.Controls.Add(moviePanel);
            }
 
        }
    }
}
