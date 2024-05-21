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
        void Show();

        Form GetForm();

        void SetCallBack(Action<object, States> action);

        
        void SetLocation(Point p);
        Point GetLocation();

    }
}
