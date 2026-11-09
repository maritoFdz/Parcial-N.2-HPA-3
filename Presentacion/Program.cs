using Negocios.Servicios;
using Presentacion.Formularios;
using Presentacion.Presentadores;

namespace Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>
                MessageBox.Show(e.Exception.ToString(), "Error no controlado");

            IUsuarioService servicio = new N_Usuario();
            IProductoService productos = new N_Producto();

            while (true)
            {
                var login = new FrmLogin();
                new LoginPresenter(login, servicio);

                if (login.ShowDialog() != DialogResult.OK)
                    break;

                using var principal = new FrmPrincipal(login.UsuarioAutenticado, servicio, productos);
                Application.Run(principal);

                if (!principal.CerrarSesion)
                    break;
            }
        }
    }
}