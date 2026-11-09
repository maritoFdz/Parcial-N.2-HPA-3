using System;
using System.Collections.Generic;
using Datos;
using Entidades;

namespace Negocios.Servicios
{
    /// <summary>
    /// Reglas de negocio de productos. Aquí se aplica el permiso:
    /// solo el rol ADMIN puede crear, actualizar o eliminar.
    /// </summary>
    public class N_Producto : IProductoService
    {
        private const string RolAdmin = "ADMIN";
        private readonly D_Producto _datos;

        public N_Producto() : this(new D_Producto())
        {
        }

        public N_Producto(D_Producto datos)
        {
            _datos = datos;
        }

        /// <inheritdoc />
        public bool PuedeModificar(E_Usuario actual)
        {
            return actual != null && actual.DsRol == RolAdmin;
        }

        /// <inheritdoc />
        public List<E_Producto> Listar()
        {
            return _datos.Listar();
        }

        /// <inheritdoc />
        public void Agregar(E_Usuario actual, string nombre, decimal precio, int stock)
        {
            ExigirAdmin(actual);
            nombre = Validar(nombre, precio, stock);
            _datos.Agregar(nombre, precio, stock, actual.DsUsuario);
        }

        /// <inheritdoc />
        public void Actualizar(E_Usuario actual, int id, string nombre, decimal precio, int stock)
        {
            ExigirAdmin(actual);
            if (id <= 0)
                throw new ArgumentException("Seleccione un producto de la lista.");

            nombre = Validar(nombre, precio, stock);
            _datos.Actualizar(id, nombre, precio, stock);
        }

        /// <inheritdoc />
        public void Eliminar(E_Usuario actual, int id)
        {
            ExigirAdmin(actual);
            if (id <= 0)
                throw new ArgumentException("Seleccione un producto de la lista.");

            _datos.Eliminar(id);
        }

        // ---------------- Reglas ----------------

        private void ExigirAdmin(E_Usuario actual)
        {
            if (!PuedeModificar(actual))
                throw new UnauthorizedAccessException("Solo el administrador puede realizar esta acción.");
        }

        private static string Validar(string nombre, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Ingrese el nombre del producto.");

            nombre = nombre.Trim();
            if (nombre.Length > 100)
                throw new ArgumentException("El nombre no puede pasar de 100 caracteres.");
            if (precio < 0 || precio > 99999999.99m)
                throw new ArgumentException("El precio debe estar entre 0 y 99,999,999.99.");
            if (stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            return nombre;
        }
    }
}