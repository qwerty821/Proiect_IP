using System;
using System.Collections.Generic;
using System.Drawing;
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
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }
            this._state = state;
        }


        /// <summary>
        /// Functia face ca starea sa fie vizibila
        /// </summary>
        public void Show() => this._state.Show();

        /// <summary>
        /// Functia returneaza starea precedenta
        /// </summary>

        public IState GetState() => this._state;

        public void SetLocation(Point p)
        {
            _state.SetLocation(p);
        }
        public Point GetLocation()
        {
            return _state.GetLocation();
        }
    }
}