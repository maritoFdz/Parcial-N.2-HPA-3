namespace Presentacion.Vistas
{
    /// <summary>Contrato de la Vista principal (MDI con menú lateral).</summary>
    public interface IMainView
    {
        void MostrarUsuario(string texto);
        void MostrarHora(string hora, string fecha);
    }
}