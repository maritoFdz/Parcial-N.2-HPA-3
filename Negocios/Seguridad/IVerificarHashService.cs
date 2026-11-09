namespace Negocios.Seguridad
{
    /// <summary>
    /// Contrato 2: su ÚNICA responsabilidad es verificar si una contraseña en texto plano
    /// coincide con el hash almacenado. Se usa cuando el usuario inicia sesión.
    /// </summary>
    public interface IVerificarHashService
    {
        /// <summary>Compara un texto plano contra un hash almacenado.</summary>
        bool Verificar(string textoPlano, string hashAlmacenado);
    }
}