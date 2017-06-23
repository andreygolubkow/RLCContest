#region Using
using System;
using System.Windows.Forms;

#endregion

namespace RLCCalculator
{
    public static class Program
    {
        #region Public Methods
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #endregion
    }
}
