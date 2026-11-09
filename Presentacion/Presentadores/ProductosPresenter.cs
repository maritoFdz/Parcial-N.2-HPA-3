using System;
using System.Collections.Generic;
using System.Globalization;
using Entidades;
using Negocios.Servicios;
using Presentacion.Vistas;

namespace Presentacion.Presentadores
{
    /// <summary>Presentador del CRUD de productos: coordina la Vista con la capa de Negocios.</summary>
    public sealed class ProductosPresenter
    {
        private readonly IProductosView _vista;
        private readonly IProductoService _servicio;
        private readonly E_Usuario _actual;

        private List<E_Producto> _productos = new List<E_Producto>();
        private int _idSeleccionado;

        public ProductosPresenter(IProductosView vista, IProductoService servicio, E_Usuario usuarioActual)
        {
            _vista = vista;
            _servicio = servicio;
            _actual = usuarioActual;

            _vista.AgregarClick += OnAgregar;
            _vista.ActualizarClick += OnActualizar;
            _vista.EliminarClick += OnEliminar;
            _vista.LimpiarClick += OnLimpiar;
            _vista.FilaSeleccionada += OnFilaSeleccionada;
        }

        /// <summary>Muestra el usuario, ajusta los permisos de la pantalla y carga la lista.</summary>
        public void Inicializar()
        {
            _vista.MostrarUsuarioActual("Sesión: " + _actual.DsUsuario + " (" + _actual.DsRol + ")");
            _vista.HabilitarEdicion(_servicio.PuedeModificar(_actual));
            Recargar();
        }

        private void Recargar()
        {
            _idSeleccionado = 0;
            try
            {
                _productos = _servicio.Listar();
                _vista.MostrarProductos(_productos);
            }
            catch (Exception)
            {
                _vista.MostrarMensaje("No se pudo cargar la lista de productos.", true);
            }
        }

        private void OnFilaSeleccionada(object sender, EventArgs e)
        {
            _idSeleccionado = _vista.IdSeleccionado;

            E_Producto seleccionado = _productos.Find(p => p.Id == _idSeleccionado);
            if (seleccionado != null)
                _vista.CargarProducto(seleccionado);
        }

        private void OnAgregar(object sender, EventArgs e)
        {
            if (!LeerNumeros(out decimal precio, out int stock)) return;

            Ejecutar(
                () => _servicio.Agregar(_actual, _vista.Nombre, precio, stock),
                "Producto agregado correctamente.");
        }

        private void OnActualizar(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                _vista.MostrarMensaje("Seleccione un producto de la lista.", true);
                return;
            }
            if (!LeerNumeros(out decimal precio, out int stock)) return;

            Ejecutar(
                () => _servicio.Actualizar(_actual, _idSeleccionado, _vista.Nombre, precio, stock),
                "Producto actualizado correctamente.");
        }

        private void OnEliminar(object sender, EventArgs e)
        {
            E_Producto seleccionado = _productos.Find(p => p.Id == _idSeleccionado);
            if (seleccionado == null)
            {
                _vista.MostrarMensaje("Seleccione un producto de la lista.", true);
                return;
            }

            if (!_vista.ConfirmarEliminar(seleccionado.DsNombre))
                return;

            Ejecutar(
                () => _servicio.Eliminar(_actual, seleccionado.Id),
                "Producto eliminado.");
        }

        private void OnLimpiar(object sender, EventArgs e)
        {
            _idSeleccionado = 0;
            _vista.LimpiarFormulario();
            _vista.MostrarMensaje(string.Empty, false);
        }

        /// <summary>Convierte los textos de precio y stock a número. Es validación de formato de la pantalla.</summary>
        private bool LeerNumeros(out decimal precio, out int stock)
        {
            stock = 0;

            if (!decimal.TryParse(_vista.Precio, NumberStyles.Number, CultureInfo.CurrentCulture, out precio))
            {
                _vista.MostrarMensaje("El precio debe ser un número válido.", true);
                return false;
            }
            if (!int.TryParse(_vista.Stock, NumberStyles.Integer, CultureInfo.CurrentCulture, out stock))
            {
                _vista.MostrarMensaje("El stock debe ser un número entero.", true);
                return false;
            }
            return true;
        }

        /// <summary>Ejecuta una acción de Negocios y traduce el resultado a mensajes para la Vista.</summary>
        private void Ejecutar(Action accion, string mensajeExito)
        {
            try
            {
                accion();
                Recargar();
                _vista.LimpiarFormulario();
                _vista.MostrarMensaje(mensajeExito, false);
            }
            catch (ArgumentException ex)
            {
                _vista.MostrarMensaje(ex.Message, true);
            }
            catch (UnauthorizedAccessException ex)
            {
                _vista.MostrarMensaje(ex.Message, true);
            }
            catch (InvalidOperationException ex)
            {
                _vista.MostrarMensaje(ex.Message, true);
            }
            catch (Exception)
            {
                _vista.MostrarMensaje("No se pudo completar la operación. Revise la conexión a la base de datos.", true);
            }
        }
    }
}