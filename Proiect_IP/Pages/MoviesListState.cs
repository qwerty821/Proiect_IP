using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pages
{
    public class MoviesListState : IState
    {
        Movies _movies;

        public MoviesListState()
        {
            _movies = new Movies();
        }
        public Form GetForm() => _movies;

        public void SetCallBack(Action<object, States> action)
        {
            _movies.SetCallBack(action);
        }

        public void Show() => _movies.Show();

        public void SetLocation(Point p) => _movies.SetLocation(p);
        
        public Point GetLocation() =>  _movies.GetLocation();
         
    }
}
