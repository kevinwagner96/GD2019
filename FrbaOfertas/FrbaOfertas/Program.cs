using FrbaOfertas.Model;
using FrbaOfertas.RegistroUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
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
            Login();
        }

        static void Login()
        {
            Boolean log = true;
            while (log)
            {
                Login login = new Login();
                var result = login.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Form1 form = new Form1(login.returnUsuario);
                    var r2 = form.ShowDialog();
                    if (r2 == DialogResult.OK)
                    {
                        log = true;
                    }
                    else
                    {
                        log = false;
                    }
                }
                else {
                    log = false;
                }
            }
        }
    }
}
