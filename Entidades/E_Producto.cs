using System;

namespace Entidades
{
    /// <summary>Entidad que representa un registro de la tabla productos.</summary>
    public class E_Producto
    {
        public int Id { get; set; }
        public string DsNombre { get; set; }
        public decimal DcPrecio { get; set; }
        public int NuStock { get; set; }
        public string DsUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
    }
}