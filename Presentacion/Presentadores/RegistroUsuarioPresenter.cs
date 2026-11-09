using System;
using Entidades;
using Negocios.Servicios;
using Presentacion.Vistas;

namespace Presentacion.Presentadores
{
    /// <summary>Presentador del registro de usuarios. Aquí se usa GenerarHash (vía Negocios).</summary>
    public sealed class RegistroUsuarioPresenter
    {
        private readonly IRegistroUsuarioView _vista;
        private readonly IUsuarioService _servicio;
        private readonly E_Usuario _usuarioActual;

        public RegistroUsuarioPresenter(IRegistroUsuarioView vista, IUsuarioService servicio, E_Usuario usuarioActual)
        {
            _vista = vista;
            _servicio = servicio;
            _usuarioActual = usuarioActual;
            _vista.RegistrarClick += OnRegistrar;
        }

        private void OnRegistrar(object sender, EventArgs e)
        {
            if (_vista.Password != _vista.Confirmacion)
            {
                _vista.MostrarMensaje("Las contraseñas no coinciden.", true);
                return;
            }

            try
            {
                _servicio.Registrar(_usuarioActual, _vista.Usuario, _vista.Password);
                _vista.MostrarMensaje("Usuario registrado correctamente.", false);
                _vista.Limpiar();
            }
            catch (ArgumentException ex)
            {
                _vista.MostrarMensaje(ex.Message, true);
            }
            catch (InvalidOperationException ex)
            {
                _vista.MostrarMensaje(ex.Message, true);
            }
            catch (UnauthorizedAccessException ex)
            {
                _vista.MostrarMensaje(ex.Message, true);
            }
            catch (Exception)
            {
                _vista.MostrarMensaje("No se pudo guardar. Revise la conexión a la base de datos.", true);
            }
        }
    }
}