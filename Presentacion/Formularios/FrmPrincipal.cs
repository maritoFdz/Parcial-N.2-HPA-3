using Entidades;
using Negocios.Servicios;
using Presentacion.Presentadores;
using Presentacion.Vistas;

namespace Presentacion.Formularios
{
    /// <summary>
    /// Ventana principal MDI con menú lateral izquierdo, reloj en tiempo real
    /// y, en la parte inferior del menú, el usuario que inició sesión.
    /// </summary>
    public partial class FrmPrincipal : Form, IMainView
    {
        private readonly MainPresenter _presenter;
        private readonly IUsuarioService _servicio;
        private readonly E_Usuario _usuario;
        private readonly IProductoService _productos;

        /// <summary>Indica si la ventana se cerró para volver al login (cerrar sesión).</summary>
        public bool CerrarSesion { get; private set; }

        public FrmPrincipal(E_Usuario usuario, IUsuarioService servicio, IProductoService productos)
        {
            InitializeComponent();

            _usuario = usuario;
            _servicio = servicio;
            _productos = productos;

            _presenter = new MainPresenter(this, usuario);
            _presenter.Inicializar();
            if (!_servicio.PuedeRegistrar(_usuario))
            {
                btnRegistrar.Visible = false;
                btnCerrarSesion.Top = btnRegistrar.Top; // sube el botón para no dejar un hueco
            }
            tmrReloj.Start();
        }

        // ---------------- IMainView ----------------

        /// <inheritdoc />
        public void MostrarUsuario(string texto)
        {
            lblUsuario.Text = texto;
        }

        /// <inheritdoc />
        public void MostrarHora(string hora, string fecha)
        {
            lblHora.Text = hora;
            lblFecha.Text = fecha;
        }

        // ---------------- Eventos ----------------

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            _presenter.ActualizarHora();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirInicio();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AbrirRegistro();
        }

        private void AbrirRegistro()
        {
            if (ActivarSiExiste(typeof(FrmRegistroUsuario))) return;

            var hijo = new FrmRegistroUsuario { MdiParent = this };
            new RegistroUsuarioPresenter(hijo, _servicio, _usuario);
            hijo.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion = true;
            Close();
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            try
            {
                AbrirInicio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al abrir Inicio");
            }
        }

        // ---------------- Formularios hijos (MDI) ----------------

        private void AbrirBienvenida()
        {
            if (ActivarSiExiste(typeof(FrmBienvenida))) return;

            var hijo = new FrmBienvenida(_usuario.DsUsuario) { MdiParent = this };
            hijo.Show();
        }

        private bool ActivarSiExiste(Type tipo)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == tipo)
                {
                    f.Activate();
                    return true;
                }
            }
            return false;
        }

        private void AbrirInicio()
        {
            if (ActivarSiExiste(typeof(FrmProductos))) return;

            var hijo = new FrmProductos { MdiParent = this };
            var presenter = new ProductosPresenter(hijo, _productos, _usuario);
            presenter.Inicializar();

            hijo.WindowState = FormWindowState.Maximized;
            hijo.Show();
        }
    }
}