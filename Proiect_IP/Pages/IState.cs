/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2024, Dragan Valeriu                                 *
 *  E-mail:      valeriu.dragan@student.tuiasi.ro                         *
 *  Description: Contine Interfata IState                                 *
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

namespace Pages
{ 
    public interface IState
    {
        /// <summary>
        /// Afiseaza o fereastra
        /// </summary>
        void Show();
        /// <summary>
        /// Returneaza o fereastra
        /// </summary>
        /// <returns></returns>
        Form GetForm();
        /// <summary>
        /// seteaza o functie callback
        /// </summary>
        /// <param name="action"></param>
        void SetCallBack(Action<object, States> action);

        /// <summary>
        /// Seteaza locatia unei ferestre
        /// </summary>
        /// <param name="p"></param>
        void SetLocation(Point p);
        /// <summary>
        /// Returneaza locatia unei ferestre
        /// </summary>
        /// <param name="p"></param>
        Point GetLocation();
    }
}
