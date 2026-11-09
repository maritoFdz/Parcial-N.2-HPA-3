using System;

namespace Presentacion.Vistas
{
    /// <summary>Contrato de la Vista para registrar usuarios.</summary>
    public interface IRegistroUsuarioView
    {
        string Usuario { get; }
        string Password { get; }
        string Confirmacion { get; }

        event EventHandler RegistrarClick;

        void MostrarMensaje(string mensaje, bool esError);
        void Limpiar();
    }
}