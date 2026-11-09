using System;
using System.Security.Cryptography;

namespace Negocios.Seguridad
{
    /// <summary>
    /// Implementación de IHashService con PBKDF2-SHA256 y salt aleatorio.
    /// Formato del resultado: PBKDF2$iteraciones$salt(Base64)$hash(Base64).
    /// </summary>
    public sealed class HashService : IHashService
    {
        /// <inheritdoc />
        public string GenerarHash(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano))
                throw new ArgumentException("La contraseña no puede estar vacía.");

            byte[] salt = RandomNumberGenerator.GetBytes(ParametrosHash.TamanoSalt);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                textoPlano, salt, ParametrosHash.Iteraciones,
                HashAlgorithmName.SHA256, ParametrosHash.TamanoHash);

            return string.Join("$",
                ParametrosHash.Prefijo,
                ParametrosHash.Iteraciones,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }
    }
}