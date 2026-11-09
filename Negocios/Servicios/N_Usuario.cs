using System;
using Datos;
using Entidades;
using Negocios.Seguridad;

namespace Negocios.Servicios
{
    /// <summary>
    /// Reglas de negocio de usuarios. Recibe sus dependencias por constructor
    /// usando los dos contratos de hash independientes.
    /// </summary>
    public class N_Usuario : IUsuarioService
    {
        private const int LargoMinimoPassword = 6;
        private const string RolAdmin = "ADMIN";
        private readonly D_Usuario _datos;
        private readonly IHashService _hash;
        private readonly IVerificarHashService _verificar;

        /// <summary>Constructor por defecto: arma las implementaciones reales.</summary>
        public N_Usuario()
            : this(new D_Usuario(), new HashService(), new VerificarHashService())
        {
        }

        /// <summary>Constructor para inyectar dependencias (útil en pruebas unitarias).</summary>
        public N_Usuario(D_Usuario datos, IHashService hash, IVerificarHashService verificar)
        {
            _datos = datos;
            _hash = hash;
            _verificar = verificar;
        }

        /// <inheritdoc />
        public E_Usuario Login(string usuario, string password)
        {
            if (string.IsNullOrWhiteSpace(usuario))
                throw new ArgumentException("Ingrese el usuario.");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Ingrese la contraseña.");

            E_Usuario encontrado = _datos.ObtenerPorUsuario(usuario.Trim());
            if (encontrado == null)
                return null;

            if (!_verificar.Verificar(password, encontrado.DsPassword))
                return null;

            encontrado.DsPassword = null; // el hash no viaja hacia la interfaz
            return encontrado;
        }

        /// <inheritdoc />
        /// <inheritdoc />
        public bool PuedeRegistrar(E_Usuario actual)
        {
            return actual != null && actual.DsRol == RolAdmin;
        }

        /// <inheritdoc />
        public void Registrar(E_Usuario actual, string usuario, string password)
        {
            if (!PuedeRegistrar(actual))
                throw new UnauthorizedAccessException("Solo el administrador puede registrar usuarios.");

            if (string.IsNullOrWhiteSpace(usuario))
                throw new ArgumentException("Ingrese el usuario.");
            usuario = usuario.Trim();
            if (usuario.Length < 3 || usuario.Length > 50)
                throw new ArgumentException("El usuario debe tener entre 3 y 50 caracteres.");
            if (string.IsNullOrEmpty(password) || password.Length < LargoMinimoPassword)
                throw new ArgumentException("La contraseña debe tener al menos " + LargoMinimoPassword + " caracteres.");

            string hash = _hash.GenerarHash(password);
            _datos.Registrar(usuario, hash, actual.DsUsuario);
        }
    }
}