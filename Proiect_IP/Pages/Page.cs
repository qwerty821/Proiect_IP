using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Page
    {
        private IState _state;
        public void SetState(IState state ) {
            this._state = state;
        }

        public void Show() => this._state.Show();
        
        public IState State => this._state;
         
    }
}
