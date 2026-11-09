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

            IUsuarioService servicio = new N_Usuario();

            while (true)
            {
                var login = new FrmLogin();
                new LoginPresenter(login, servicio);

                if (login.ShowDialog() != DialogResult.OK)
                    break;

                using var principal = new FrmPrincipal(login.UsuarioAutenticado, servicio);
                Application.Run(principal);

                if (!principal.CerrarSesion)
                    break;
            }
        }
    }
}