using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Objects.Movies;

namespace Pages
{

    public  class MovieInfoState : IState
    {
        MovieInfo _movie;
        public MovieInfoState()
        {
            _movie = new MovieInfo();
        }
        public Form GetForm() => _movie;

        public void SetCallBack(Action<object, States> action)
        {
            _movie.SetCallBack(action);
        }
        public void Show() => _movie.Show();

        public void SetLocation(Point p) =>  _movie.SetLocation(p);

        public Point GetLocation() => _movie.GetLocation();
    }
}
