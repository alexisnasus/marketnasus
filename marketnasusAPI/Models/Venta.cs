using System;
using System.Collections.Generic;

namespace marketnasusAPI.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Anulada { get; set; } = false;

        // Relación: Una venta puede tener muchos detalles
        public ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}
