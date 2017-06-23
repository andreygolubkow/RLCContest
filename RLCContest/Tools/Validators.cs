#region Using
using System.Windows.Forms;

#endregion

namespace Tools
{
    public static class Validators
    {
        #region Public Methods
        public static void DoubleEnterValidate(string text, KeyPressEventArgs e)
        {
            if (text.Contains(",") || text.Length == 0)
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
        #endregion
    }
}
