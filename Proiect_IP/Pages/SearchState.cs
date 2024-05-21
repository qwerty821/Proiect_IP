using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Objects.Movies;

namespace Pages
{
    public class SearchState : IState
    {
        private SearchPage _searchPage;
         
        public SearchState()
        {
            _searchPage = new SearchPage();
        }

        public void Show() => _searchPage.Show();

        public Form GetForm() => _searchPage;

        public void SetCallBack(Action<object, States> func)
        {
            _searchPage.SetCallBack(func);
        }

        public void SetLocation(Point p) => _searchPage.SetLocation(p);

        public Point GetLocation() => _searchPage.GetLocation();
    }
}
