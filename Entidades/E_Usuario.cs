using System;

namespace Entidades
{
    /// <summary>
    /// Entidad que representa un registro de la tabla usuarios.
    /// Es una clase "pura": solo datos, sin lógica.
    /// </summary>
    public class E_Usuario
    {
        /// <summary>Llave primaria autoincremental.</summary>
        public int Id { get; set; }

        /// <summary>Código del usuario (ej. 001).</summary>
        public string DsId { get; set; }

        /// <summary>Nombre de usuario para iniciar sesión.</summary>
        public string DsUsuario { get; set; }

        /// <summary>Hash de la contraseña </summary>
        public string DsPassword { get; set; }

        /// <summary>Estado: '1' activo, '0' inactivo.</summary>
        public string DsEstado { get; set; }

        /// <summary>Rol del usuario: ADMIN o USER.</summary>
        public string DsRol { get; set; }

        public string DsUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public string DsUsuarioModificacion { get; set; }
        public DateTime DtFechaModificacion { get; set; }
    }
}