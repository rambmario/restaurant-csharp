using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Gestion_gastronomica
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Formularios.frmLogin frm = new Formularios.frmLogin();
            frm.ShowDialog();
            
            if(frm.DialogResult == DialogResult.OK)
            Application.Run(new Formularios.frmPedido());
        }
    }
}
