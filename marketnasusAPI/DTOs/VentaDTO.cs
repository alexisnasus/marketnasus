using System;
using System.Collections.Generic;

namespace marketnasusAPI.DTOs
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        // Detalles de la venta
        public List<VentaDetalleDTO> Detalles { get; set; }
    }
}
