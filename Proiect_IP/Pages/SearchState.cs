using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void SetCallBack(Action<object> func)
        {
            _searchPage.SetCallBack(func);
        }
    }
}
