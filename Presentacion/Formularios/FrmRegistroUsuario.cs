using System;
using System.Drawing;
using System.Windows.Forms;
using Presentacion.Vistas;

namespace Presentacion.Formularios
{
    /// <summary>Vista para registrar usuarios (formulario hijo MDI).</summary>
    public partial class FrmRegistroUsuario : Form, IRegistroUsuarioView
    {
        /// <inheritdoc />
        public event EventHandler RegistrarClick;

        /// <inheritdoc />
        public string Usuario => txtUsuario.Text;

        /// <inheritdoc />
        public string Password => txtPassword.Text;

        /// <inheritdoc />
        public string Confirmacion => txtConfirmacion.Text;

        public FrmRegistroUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarClick?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc />
        public void MostrarMensaje(string mensaje, bool esError)
        {
            lblMensaje.ForeColor = esError ? Color.Firebrick : Color.SeaGreen;
            lblMensaje.Text = mensaje;
        }

        /// <inheritdoc />
        public void Limpiar()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
            txtConfirmacion.Clear();
            txtUsuario.Focus();
        }
    }
}