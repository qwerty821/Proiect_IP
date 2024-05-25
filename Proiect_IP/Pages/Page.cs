/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Dragan Valeriu                                 *
 *  E-mail:      valeriu.dragan@student.tuiasi.ro                         *
 *  Description: Contine clasa Page                                       *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


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