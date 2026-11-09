using System;
using System.Windows.Forms;
using Entidades;
using Presentacion.Vistas;

namespace Presentacion.Formularios
{
    /// <summary>
    /// Vista de inicio de sesión. Solo muestra controles y avisa al Presentador;
    /// no sabe nada de hashes ni de la base de datos.
    /// </summary>
    public partial class FrmLogin : Form, ILoginView
    {
        /// <summary>Usuario autenticado (disponible cuando el resultado del diálogo es OK).</summary>
        public E_Usuario UsuarioAutenticado { get; private set; }

        /// <inheritdoc />
        public event EventHandler IngresarClick;

        /// <inheritdoc />
        public string Usuario => txtUsuario.Text;

        /// <inheritdoc />
        public string Password => txtPassword.Text;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IngresarClick?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc />
        public void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
        }

        /// <inheritdoc />
        public void LimpiarPassword()
        {
            txtPassword.Clear();
            txtPassword.Focus();
        }

        /// <inheritdoc />
        public void LoginExitoso(E_Usuario usuario)
        {
            UsuarioAutenticado = usuario;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <inheritdoc />
        public void Cancelar()
        {
            MessageBox.Show(lblMensaje.Text, "Acceso bloqueado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}