using System;
using Entidades;

namespace Presentacion.Vistas
{
    /// <summary>
    /// Contrato de la Vista de inicio de sesión (MVP).
    /// El Presentador solo conoce esta interfaz.
    /// </summary>
    public interface ILoginView
    {
        /// <summary>Texto escrito en el campo usuario.</summary>
        string Usuario { get; }

        /// <summary>Texto escrito en el campo contraseña.</summary>
        string Password { get; }

        /// <summary>Se dispara cuando el usuario pulsa "Ingresar".</summary>
        event EventHandler IngresarClick;

        void MostrarMensaje(string mensaje);
        void LimpiarPassword();
        void LoginExitoso(E_Usuario usuario);
        void Cancelar();
    }
}