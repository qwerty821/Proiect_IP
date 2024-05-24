using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pages
{
    public class MoviesListState : IState
    {
        Movies _movies;

        /// <summary>
        /// Constructor pentru clasa MoviesListState.
        /// Creaza o instanță de tipul Movies.
        /// </summary>
        public MoviesListState()
        {
            _movies = new Movies();
        }
        /// <summary>
        /// Returnează o fereastra MoviesListState
        /// </summary>
        public Form GetForm() => _movies;

        /// <summary>
        /// Metoda seteaza o functie de Callback pentru a apela o functi care schimba starea
        /// </summary>
        /// <param name="action"></param>
        public void SetCallBack(Action<object, States> action) => _movies.SetCallBack(action);

        /// <summary>
        /// Afișează pagina care contine rezultatul cautarii.
        /// </summary>
        public void Show() => _movies.Show();
        
        /// <summary>
        /// Seteaza locatia ferestrei
        /// </summary>
        /// <param name="p"></param>
        public void SetLocation(Point p) => _movies.SetLocation(p);

        /// <summary>
        /// Returneaza locatia ferestrei
        /// </summary>
        /// <param name="p"></param>
        public Point GetLocation() =>  _movies.GetLocation();
         
    }
}
