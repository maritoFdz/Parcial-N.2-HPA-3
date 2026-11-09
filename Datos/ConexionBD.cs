using System;
using MySql.Data.MySqlClient;

namespace Datos
{
    /// <summary>
    /// Centraliza la conexión a MySQL usando un usuario específico de la aplicacin
    /// (app_login) con privilegios mínimos: solo EXECUTE sobre dos procedimientos.
    /// </summary>
    public static class ConexionBD
    {
        private static string Env(string nombre, string porDefecto)
        {
            string valor = Environment.GetEnvironmentVariable(nombre);
            return string.IsNullOrWhiteSpace(valor) ? porDefecto : valor;
        }

        /// <summary>Cadena de conxión</summary>
        public static string CadenaConexion
        {
            get
            {
                var b = new MySqlConnectionStringBuilder
                {
                    Server = Env("LOGIN_DB_SERVER", "localhost"),
                    Port = 3306,
                    Database = Env("LOGIN_DB_NAME", "bd_login"),
                    UserID = Env("LOGIN_DB_USER", "app_login"),
                    Password = Env("LOGIN_DB_PASSWORD", "ClaveSegura#2026")
                };
                return b.ConnectionString;
            }
        }

        /// <summary>Crea una conexión nueva.</summary>
        public static MySqlConnection Crear()
        {
            return new MySqlConnection(CadenaConexion);
        }
    }
}