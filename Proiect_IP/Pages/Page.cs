using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    /// <summary>
    /// Clasa care seteaza starile si le afiseaza
    /// </summary>
    public class Page
    {
        private IState _state;

        /// <summary>
        /// Functia seteaza noua stare
        /// </summary>
        /// <param name="state"></param>
        public void SetState(IState state)
        {
            this._state = state;
        }

        /// <summary>
        /// Functia face ca stare sa fie vizibila
        /// </summary>
        public void Show() => this._state.Show();

        /// <summary>
        /// Functia returneaza stare curenta
        /// </summary>
       
        public IState State => this._state;
    }
}