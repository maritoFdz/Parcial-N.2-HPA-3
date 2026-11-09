using Entidades;

namespace Negocios.Servicios
{
    /// <summary>
    /// Contrato del "Modelo" para los Presentadores: lo que la capa de Negocios
    /// ofrece sobre usuarios.
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>Valida credenciales. Devuelve el usuario (sin hash) o null si son incorrectas.</summary>
        E_Usuario Login(string usuario, string password);
        bool PuedeRegistrar(E_Usuario actual);

        /// <summary>Registra un usuario nuevo guardando solo el hash de su contraseña.</summary>
        void Registrar(E_Usuario actual, string usuario, string password);
    }
}