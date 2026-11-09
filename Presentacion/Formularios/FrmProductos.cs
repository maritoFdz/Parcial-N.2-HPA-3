using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Presentacion.Vistas;

namespace Presentacion.Formularios
{
    /// <summary>Vista del CRUD de productos (pantalla de Inicio).</summary>
    public partial class FrmProductos : Form, IProductosView
    {
        /// <inheritdoc />
        public event EventHandler AgregarClick;
        /// <inheritdoc />
        public event EventHandler ActualizarClick;
        /// <inheritdoc />
        public event EventHandler EliminarClick;
        /// <inheritdoc />
        public event EventHandler LimpiarClick;
        /// <inheritdoc />
        public event EventHandler FilaSeleccionada;

        /// <inheritdoc />
        public string Nombre => txtNombre.Text;

        /// <inheritdoc />
        public string Precio => txtPrecio.Text;

        /// <inheritdoc />
        public string Stock => txtStock.Text;

        /// <inheritdoc />
        public int IdSeleccionado =>
            dgvProductos.CurrentRow == null ? 0 : (int)dgvProductos.CurrentRow.Cells["Id"].Value;

        public FrmProductos()
        {
            InitializeComponent();
        }

        // ---------------- Eventos de los controles ----------------

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarClick?.Invoke(this, EventArgs.Empty);
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                FilaSeleccionada?.Invoke(this, EventArgs.Empty);
        }

        // ---------------- IProductosView ----------------

        /// <inheritdoc />
        public void MostrarProductos(IEnumerable<E_Producto> productos)
        {
            dgvProductos.DataSource = productos.Select(p => new
            {
                Id = p.Id,
                Producto = p.DsNombre,
                Precio = p.DcPrecio,
                Stock = p.NuStock,
                CreadoPor = p.DsUsuarioCreacion,
                Fecha = p.DtFechaCreacion
            }).ToList();

            dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "N2";
            dgvProductos.ClearSelection();
        }

        /// <inheritdoc />
        public void MostrarUsuarioActual(string texto)
        {
            lblUsuarioActual.Text = texto;
        }

        /// <inheritdoc />
        public void HabilitarEdicion(bool habilitada)
        {
            pnlSuperior.Visible = habilitada;

            if (!habilitada)
            {
                lblMensaje.ForeColor = Color.DimGray;
                lblMensaje.Text = "Modo solo lectura: solo el administrador puede modificar productos.";
            }
        }

        /// <inheritdoc />
        public void CargarProducto(E_Producto producto)
        {
            txtNombre.Text = producto.DsNombre;
            txtPrecio.Text = producto.DcPrecio.ToString("0.00");
            txtStock.Text = producto.NuStock.ToString();
        }

        /// <inheritdoc />
        public void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

        /// <inheritdoc />
        public void MostrarMensaje(string mensaje, bool esError)
        {
            lblMensaje.ForeColor = esError ? Color.Firebrick : Color.SeaGreen;
            lblMensaje.Text = mensaje;
        }

        /// <inheritdoc />
        public bool ConfirmarEliminar(string nombre)
        {
            return MessageBox.Show(
                "¿Eliminar el producto \"" + nombre + "\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}