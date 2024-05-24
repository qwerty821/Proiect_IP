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
