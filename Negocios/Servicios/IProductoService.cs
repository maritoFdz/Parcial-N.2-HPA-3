using System.Collections.Generic;
using Entidades;

namespace Negocios.Servicios
{
    /// <summary>Contrato del Modelo para el CRUD de productos.</summary>
    public interface IProductoService
    {
        /// <summary>Indica si el usuario tiene permiso para crear, actualizar y eliminar.</summary>
        bool PuedeModificar(E_Usuario actual);

        /// <summary>Lista los productos. Cualquier usuario autenticado puede verlos.</summary>
        List<E_Producto> Listar();

        void Agregar(E_Usuario actual, string nombre, decimal precio, int stock);
        void Actualizar(E_Usuario actual, int id, string nombre, decimal precio, int stock);
        void Eliminar(E_Usuario actual, int id);
    }
}