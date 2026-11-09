using System;
using System.Collections.Generic;
using Entidades;

namespace Presentacion.Vistas
{
    /// <summary>Contrato de la Vista del CRUD de productos (pantalla de Inicio).</summary>
    public interface IProductosView
    {
        string Nombre { get; }
        string Precio { get; }
        string Stock { get; }

        /// <summary>Id de la fila seleccionada en la lista (0 si no hay).</summary>
        int IdSeleccionado { get; }

        event EventHandler AgregarClick;
        event EventHandler ActualizarClick;
        event EventHandler EliminarClick;
        event EventHandler LimpiarClick;
        event EventHandler FilaSeleccionada;

        void MostrarProductos(IEnumerable<E_Producto> productos);
        void MostrarUsuarioActual(string texto);
        void HabilitarEdicion(bool habilitada);
        void CargarProducto(E_Producto producto);
        void LimpiarFormulario();
        void MostrarMensaje(string mensaje, bool esError);
        bool ConfirmarEliminar(string nombre);
    }
}