using System;
using System.Windows.Forms;

namespace UI.Desktop
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
            Application.Run(new frmLogin());
            //Application.Run(new Cursos());



            //Esto es para validar la primera vez que arranque el sistema

            /*
            if(!Validaciones.ExistePlan())
            {
                Planes frmPlanes = new Planes();
                frmPlanes.ShowDialog();
            }*/


            //Esto es para validar la primera vez que arranque el sistema
            /*
            if (!Validaciones.ExisteEspecialidad())
            {
                Especialidades frmEspecialidad = new Especialidades();
                frmEspecialidad.ShowDialog();
            }
            */

            //Esto es para validar la primera vez que arranque el sistema
            /*if(!Validaciones.ExistePersona())
            {
                Personas frmPersonas = new Personas();
                frmPersonas.ShowDialog();
            }*/

        }
    }
}
