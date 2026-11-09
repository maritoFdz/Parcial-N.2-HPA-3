using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;

namespace Datos
{
    /// <summary>Acceso a datos de la tabla productos, solo con procedimientos almacenados.</summary>
    public class D_Producto
    {
        /// <summary>Devuelve todos los productos.</summary>
        public List<E_Producto> Listar()
        {
            var lista = new List<E_Producto>();

            using MySqlConnection cn = ConexionBD.Crear();
            using var cmd = new MySqlCommand("CALL sp_listar_productos()", cn);
            cn.Open();

            using MySqlDataReader fReader = cmd.ExecuteReader();
            while (fReader.Read())
            {
                lista.Add(new E_Producto
                {
                    Id = fReader.GetInt32("id"),
                    DsNombre = fReader.GetString("dsNombre"),
                    DcPrecio = fReader.GetDecimal("dcPrecio"),
                    NuStock = fReader.GetInt32("nuStock"),
                    DsUsuarioCreacion = fReader.GetString("dsUsuarioCreacion"),
                    DtFechaCreacion = fReader.GetDateTime("dtFechaCreacion")
                });
            }
            return lista;
        }

        /// <summary>Inserta un producto nuevo.</summary>
        /// <exception cref="InvalidOperationException">Si ya existe un producto con ese nombre.</exception>
        public void Agregar(string nombre, decimal precio, int stock, string creador)
        {
            try
            {
                using MySqlConnection cn = ConexionBD.Crear();
                using var cmd = new MySqlCommand(
                    "CALL sp_agregar_producto(@p_nombre, @p_precio, @p_stock, @p_creador)", cn);
                cmd.Parameters.AddWithValue("@p_nombre", nombre);
                cmd.Parameters.AddWithValue("@p_precio", precio);
                cmd.Parameters.AddWithValue("@p_stock", stock);
                cmd.Parameters.AddWithValue("@p_creador", creador);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new InvalidOperationException("Ya existe un producto con ese nombre.", ex);
            }
        }

        /// <summary>Actualiza nombre, precio y stock de un producto.</summary>
        /// <exception cref="InvalidOperationException">Si el nombre ya lo usa otro producto.</exception>
        public void Actualizar(int id, string nombre, decimal precio, int stock)
        {
            try
            {
                using MySqlConnection cn = ConexionBD.Crear();
                using var cmd = new MySqlCommand(
                    "CALL sp_actualizar_producto(@p_id, @p_nombre, @p_precio, @p_stock)", cn);
                cmd.Parameters.AddWithValue("@p_id", id);
                cmd.Parameters.AddWithValue("@p_nombre", nombre);
                cmd.Parameters.AddWithValue("@p_precio", precio);
                cmd.Parameters.AddWithValue("@p_stock", stock);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new InvalidOperationException("Ya existe un producto con ese nombre.", ex);
            }
        }

        /// <summary>Elimina un producto.</summary>
        public void Eliminar(int id)
        {
            using MySqlConnection cn = ConexionBD.Crear();
            using var cmd = new MySqlCommand("CALL sp_eliminar_producto(@p_id)", cn);
            cmd.Parameters.AddWithValue("@p_id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}