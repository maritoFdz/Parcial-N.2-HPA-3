using System;
using System.Security.Cryptography;

namespace Negocios.Seguridad
{
    /// <summary>
    /// Implementación de IVerificarHashService. Lee el salt y las iteraciones
    /// del hash almacenado, recalcula y compara en tiempo constante.
    /// </summary>
    public sealed class VerificarHashService : IVerificarHashService
    {
        /// <inheritdoc />
        public bool Verificar(string textoPlano, string hashAlmacenado)
        {
            if (string.IsNullOrEmpty(textoPlano) || string.IsNullOrEmpty(hashAlmacenado))
                return false;

            string[] partes = hashAlmacenado.Split('$');
            if (partes.Length != 4 || partes[0] != ParametrosHash.Prefijo)
                return false;

            if (!int.TryParse(partes[1], out int iteraciones) || iteraciones <= 0)
                return false;

            byte[] salt, esperado;
            try
            {
                salt = Convert.FromBase64String(partes[2]);
                esperado = Convert.FromBase64String(partes[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            byte[] calculado = Rfc2898DeriveBytes.Pbkdf2(
                textoPlano, salt, iteraciones, HashAlgorithmName.SHA256, esperado.Length);

            return CryptographicOperations.FixedTimeEquals(calculado, esperado);
        }
    }
}