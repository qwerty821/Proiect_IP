/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Dragan Valeriu                                 *
 *  E-mail:      valeriu.dragan@student.tuiasi.ro                         *
 *  Description: Contine starea MovieInfoState                            *
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
using System.Windows.Forms;
using TMDbLib.Objects.Movies;

namespace Pages
{

    public  class MovieInfoState : IState
    {
        MovieInfo _movie;

        /// <summary>
        /// Constructor pentru clasa MovieInfoState.
        /// Inițializează o nouă instanță a paginii cu informatii despre un film.
        /// </summary>
        public MovieInfoState()
        {
            _movie = new MovieInfo();
        }

        /// <summary>
        /// Returnează o fereastra MovieInfo
        /// </summary>
        public Form GetForm() => _movie;

        /// <summary>
        /// Metoda seteaza o functie de Callback pentru a apela o functie care schimba starea
        /// </summary>
        /// <param name="action"></param>
        public void SetCallBack(Action<object, States> action)
        {
            _movie.SetCallBack(action);
        }
        /// <summary>
        /// Afișează pagina cu informatii.
        /// </summary>
        public void Show() => _movie.Show();

        /// <summary>
        /// Seteaza locatia ferestrei
        /// </summary>
        /// <param name="p"></param>
        public void SetLocation(Point p) =>  _movie.SetLocation(p);
        /// <summary>
        /// Returneaza locatia ferestrei
        /// </summary>
        /// <returns></returns>
        public Point GetLocation() => _movie.GetLocation();
    }
}
