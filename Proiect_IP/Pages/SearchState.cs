
/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Butnaru Dan                                    *
 *  E-mail:      dan.butnaru@student.tuiasi.ro                            *
 *  Description: Contine starea pentru pagina de cautare                  *
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

        /// <summary>
        /// Constructor pentru clasa SearchState.
        /// Inițializează o nouă instanță a paginii de căutare.
        /// </summary>
        public SearchState()
        {
            _searchPage = new SearchPage();
        }

        /// <summary>
        /// Afișează pagina de căutare.
        /// </summary>
        public void Show() => _searchPage.Show();

        /// <summary>
        /// Returnează o fereastra SearchPage
        /// </summary>
        public Form GetForm() => _searchPage;

        /// <summary>
        /// Metoda seteaza o functie de Callback pentru a apela o functie care schimba starea
        /// </summary>
        /// <param name="action"></param>
        public void SetCallBack(Action<object, States> func)
        {
            _searchPage.SetCallBack(func);
        }
        /// <summary>
        /// Seteaza locatia ferestrei
        /// </summary>
        /// <param name="p"></param>
        public void SetLocation(Point p) => _searchPage.SetLocation(p);
        /// <summary>
        /// Returneaza locatia ferestrei
        /// </summary>
        /// <returns></returns>
        public Point GetLocation() => _searchPage.GetLocation();
    }
}
