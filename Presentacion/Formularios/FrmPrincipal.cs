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

        /// <summary>Indica si la ventana se cerró para volver al login (cerrar sesión).</summary>
        public bool CerrarSesion { get; private set; }

        public FrmPrincipal(E_Usuario usuario, IUsuarioService servicio)
        {
            InitializeComponent();

            _usuario = usuario;
            _servicio = servicio;

            _presenter = new MainPresenter(this, usuario);
            _presenter.Inicializar();
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
            AbrirBienvenida();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Se completa en la Fase 8
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion = true;
            Close();
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            AbrirBienvenida();
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
    }
}