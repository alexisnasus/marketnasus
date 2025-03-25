using System;

namespace marketnasusAPI.Models
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Relación: Cada detalle está asociado a una venta y a un producto
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
