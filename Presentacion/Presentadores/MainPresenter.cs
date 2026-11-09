using System.Globalization;
using Entidades;
using Presentacion.Vistas;

namespace Presentacion.Presentadores
{
    /// <summary>Presentador de la ventana principal: prepara el texto de la hora y del usuario en sesión.</summary>
    public sealed class MainPresenter
    {
        private readonly IMainView _vista;
        private readonly E_Usuario _usuario;
        private static readonly CultureInfo Cultura = new CultureInfo("es-PA");

        public MainPresenter(IMainView vista, E_Usuario usuario)
        {
            _vista = vista;
            _usuario = usuario;
        }

        /// <summary>Muestra el usuario y la hora inicial.</summary>
        public void Inicializar()
        {
            _vista.MostrarUsuario(_usuario.DsUsuario);
            ActualizarHora();
        }

        /// <summary>Llamado por el Timer de la Vista cada segundo.</summary>
        public void ActualizarHora()
        {
            DateTime ahora = DateTime.Now;
            _vista.MostrarHora(
                ahora.ToString("HH:mm:ss", Cultura),
                ahora.ToString("dddd, dd 'de' MMMM 'de' yyyy", Cultura));
        }
    }
}