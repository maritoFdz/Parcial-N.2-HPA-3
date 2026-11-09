namespace Negocios.Seguridad
{
    /// <summary>
    /// Contrato 1: su ÚNICA responsabilidad es generar el hash de una contraseña.
    /// Se usa cuando el usuario se registra o cambia su contraseña.
    /// </summary>
    public interface IHashService
    {
        /// <summary>Genera el hash (con salt aleatorio) de un texto plano.</summary>
        string GenerarHash(string textoPlano);
    }
}