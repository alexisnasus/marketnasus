using System;

namespace marketnasusAPI.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; } // Ejemplo: "entrada", "salida"
        public int Cantidad { get; set; }
        public string Observaciones { get; set; }

        // Relación: Cada movimiento de inventario está asociado a un producto
        public Producto Producto { get; set; }
    }
}
