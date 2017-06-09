using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public static class Validators
    {
        public static void DoubleEnterValidate(string text,KeyPressEventArgs e)
        {
            if ( text.Contains(",") || text.Length == 0)
            {
                if (e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
            }

        }
    }
}
