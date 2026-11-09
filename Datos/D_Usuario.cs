using System;
using MySql.Data.MySqlClient;
using Entidades;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de la tabla usuarios. Solo usa procedimientos almacenados
    /// y no contiene reglas de negocio (el hash se verifica en la capa de Negocios).
    /// </summary>
    public class D_Usuario
    {
        /// <summary>
        /// Busca un usuario activo por su nombre. Devuelve el hash almacenado
        /// en DsPassword, o null si el usuario no existe.
        /// </summary>
        public E_Usuario ObtenerPorUsuario(string usuario)
        {
            using MySqlConnection cn = ConexionBD.Crear();
            using var cmd = new MySqlCommand("CALL sp_login(@p_usuario)", cn);
            cmd.Parameters.AddWithValue("@p_usuario", usuario);
            cn.Open();

            using MySqlDataReader fReader = cmd.ExecuteReader();
            if (!fReader.Read())
                return null;

            return new E_Usuario
            {
                Id = fReader.GetInt32("id"),
                DsId = fReader.GetString("dsId"),
                DsUsuario = fReader.GetString("dsUsuario"),
                DsPassword = fReader.GetString("dsPassword"),
                DsEstado = fReader.GetString("dsEstado"),
                DsRol = fReader.GetString("dsRol")
            };
        }

        /// <summary>Inserta un usuario nuevo con su hash ya calculado.</summary>
        /// <exception cref="InvalidOperationException">Si el usuario ya existe.</exception>
        public void Registrar(string usuario, string hash, string usuarioCreacion)
        {
            try
            {
                using MySqlConnection cn = ConexionBD.Crear();
                using var cmd = new MySqlCommand("CALL sp_registrar_usuario(@p_usuario, @p_hash, @p_creador)", cn);
                cmd.Parameters.AddWithValue("@p_usuario", usuario);
                cmd.Parameters.AddWithValue("@p_hash", hash);
                cmd.Parameters.AddWithValue("@p_creador", usuarioCreacion);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new InvalidOperationException("El usuario ya existe.", ex);
            }
        }
    }
}