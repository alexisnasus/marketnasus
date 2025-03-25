using marketnasusAPI.DTOs;
using marketnasusAPI.Models;
using marketnasusAPI.Repositories.Interfaces;
using marketnasusAPI.Services.Interfaces;

namespace marketnasusAPI.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoRepository _productoRepository;

        public VentaService(IVentaRepository ventaRepository, IProductoRepository productoRepository)
        {
            _ventaRepository = ventaRepository;
            _productoRepository = productoRepository;
        }

        public async Task ProcesarVentaAsync(VentaDTO ventaDto)
        {
            // Validar y procesar cada detalle de venta
            foreach (var detalle in ventaDto.Detalles)
            {
                await ValidarStockAsync(detalle.IdProducto, detalle.Cantidad);
                // Aquí podrías aplicar descuentos, si corresponde
            }

            // Calcular el total de la venta
            ventaDto.MontoTotal = CalcularTotalVenta(ventaDto.Detalles);

            // Mapear el DTO a la entidad Venta directamente (sin un método de mapeo separado)
            var ventaEntity = new Venta
            {
                FechaVenta = ventaDto.FechaVenta,
                FechaCreacion = DateTime.UtcNow,
                MontoTotal = ventaDto.MontoTotal,
                VentaDetalles = ventaDto.Detalles.Select(detalle => new VentaDetalle
                {
                    IdProducto = detalle.IdProducto,
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = detalle.PrecioUnitario
                }).ToList()
            };

            // Registrar la venta a través del repositorio
            await _ventaRepository.AddVentaAsync(ventaEntity);
        }

        public async Task AnularVentaAsync(int id)
        {
            // Recuperar la venta a anular
            var venta = await _ventaRepository.GetVentaByIdAsync(id);
            if (venta == null)
            {
                throw new Exception("Venta no encontrada.");
            }

            // Verificar si la venta ya fue anulada
            if (venta.Anulada)
            {
                throw new Exception("La venta ya ha sido anulada.");
            }

            // Revertir la actualización de stock para cada detalle de la venta
            foreach (var detalle in venta.VentaDetalles)
            {
                var producto = await _productoRepository.GetByIdAsync(detalle.IdProducto);
                if (producto != null)
                {
                    // Sumar la cantidad vendida para devolver el stock
                    producto.Cantidad += detalle.Cantidad;
                    await _productoRepository.UpdateAsync(producto);
                }
            }

            // Marcar la venta como anulada
            venta.Anulada = true;

            // Actualizar la venta en el repositorio
            await _ventaRepository.UpdateVentaAsync(venta);
        }

        private async Task ValidarStockAsync(int idProducto, int cantidadSolicitada)
        {
            var producto = await _productoRepository.GetByIdAsync(idProducto);
            if (producto == null || producto.Cantidad < cantidadSolicitada)
            {
                throw new Exception("Stock insuficiente o producto no encontrado.");
            }
        }

        private decimal CalcularTotalVenta(IEnumerable<VentaDetalleDTO> detalles)
        {
            return detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
        }
    }
}
