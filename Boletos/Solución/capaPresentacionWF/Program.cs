using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacionWF
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
            //Application.Run(new fRuta());
            //Application.Run(new fPropietario());
            //Application.Run(new fClientes());
            //Application.Run(new fCompra_Boletos());
            //Application.Run(new fUsuario());
            Application.Run(new MDIPrincipal());
        }
    }
}
