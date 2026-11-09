namespace Presentacion.Formularios
{
    /// <summary>Formulario hijo MDI de bienvenida.</summary>
    public partial class FrmBienvenida : Form
    {
        public FrmBienvenida(string usuario)
        {
            InitializeComponent();
            lblBienvenida.Text = "¡Bienvenido, " + usuario + "!\r\n\r\nUse el menú de la izquierda para navegar.";
        }
    }
}