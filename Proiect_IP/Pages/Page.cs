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
        /// Metoda seteaza noua stare
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
        /// Metoda face ca starea sa fie vizibila
        /// </summary>
        public void Show() => this._state.Show();

        /// <summary>
        /// Metoda returneaza starea precedenta
        /// </summary>

        public IState GetState() => this._state;
        /// <summary>
        /// Metoda seteaza locatia ferestrei corespunzatoare starii curente
        /// </summary>
        /// <param name="p"></param>
        public void SetLocation(Point p) => _state.SetLocation(p);

        /// <summary>
        /// Metoda returneaza locatia ferestrei corespunzatoare starii curente
        /// </summary>
        /// <param name="p"></param>
        public Point GetLocation() =>  _state.GetLocation();

    }
}