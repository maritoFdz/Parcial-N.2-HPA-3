using System;
using Entidades;
using Negocios.Servicios;
using Presentacion.Vistas;
using Presentacion.Formularios;

namespace Presentacion.Presentadores
{
    /// <summary>
    /// Presentador del login: recibe la acción de la Vista, pide al Modelo (Negocios)
    /// validar las credenciales y le devuelve el resultado a la Vista.
    /// No conoce Windows Forms ni MySQL.
    /// </summary>
    public sealed class LoginPresenter
    {
        private const int MaximoIntentos = 3;
        private readonly ILoginView _vista;
        private readonly IUsuarioService _servicio;
        private int _intentos;

        public LoginPresenter(ILoginView vista, IUsuarioService servicio)
        {
            _vista = vista;
            _servicio = servicio;
            _vista.IngresarClick += OnIngresar;
        }

        private void OnIngresar(object sender, EventArgs e)
        {
            try
            {
                E_Usuario usuario = _servicio.Login(_vista.Usuario, _vista.Password);

                if (usuario == null)
                {
                    _intentos++;
                    _vista.LimpiarPassword();

                    if (_intentos >= MaximoIntentos)
                    {
                        _vista.MostrarMensaje("Demasiados intentos fallidos. La aplicación se cerrará.");
                        _vista.Cancelar();
                        return;
                    }

                    _vista.MostrarMensaje("Usuario o contraseña incorrectos. Intento " + _intentos + " de " + MaximoIntentos + ".");
                    return;
                }

                _vista.LoginExitoso(usuario);
            }
            catch (ArgumentException ex)
            {
                _vista.MostrarMensaje(ex.Message);
            }
            catch (Exception)
            {
                _vista.MostrarMensaje("No se pudo conectar con la base de datos. Revise la configuración.");
            }
        }
    }
}