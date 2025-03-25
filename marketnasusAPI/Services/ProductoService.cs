using marketnasusAPI.DTOs;
using marketnasusAPI.Models;
using marketnasusAPI.Repositories.Interfaces;
using marketnasusAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketnasusAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<ProductoDTO> GetProductoByCodigoBarrasAsync(string codigoBarras)
        {
            var producto = await _productoRepository.GetByCodigoBarrasAsync(codigoBarras);
            if (producto == null)
                return null;

            return MapearAProductoDTO(producto);
        }

        public async Task<ProductoDTO> GetProductoByIdAsync(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null)
                return null;

            return MapearAProductoDTO(producto);
        }

        public async Task<IEnumerable<ProductoDTO>> GetAllProductosAsync()
        {
            var productos = await _productoRepository.GetAllAsync();
            return productos.Select(p => MapearAProductoDTO(p));
        }

        public async Task AddProductoAsync(ProductoDTO productoDto)
        {
            // Mapeo del DTO a la entidad Producto
            var producto = new Producto
            {
                CodigoBarras = productoDto.CodigoBarras,
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                Precio = productoDto.Precio,
                // Puedes mapear más propiedades si es necesario (por ejemplo, Cantidad, IdCategoria, etc.)
            };

            await _productoRepository.AddAsync(producto);
        }

        public async Task UpdateProductoAsync(ProductoDTO productoDto)
        {
            // Se asume que el DTO contiene el ID del producto a actualizar
            var producto = await _productoRepository.GetByIdAsync(productoDto.Id);
            if (producto == null)
                return;

            // Actualizar propiedades
            producto.CodigoBarras = productoDto.CodigoBarras;
            producto.Nombre = productoDto.Nombre;
            producto.Descripcion = productoDto.Descripcion;
            producto.Precio = productoDto.Precio;
            // Actualiza otras propiedades si es necesario

            await _productoRepository.UpdateAsync(producto);
        }

        public async Task DeleteProductoAsync(int id)
        {
            await _productoRepository.DeleteAsync(id);
        }

        // Método privado para mapear de Producto a ProductoDTO
        private ProductoDTO MapearAProductoDTO(Producto producto)
        {
            return new ProductoDTO
            {
                Id = producto.Id,
                CodigoBarras = producto.CodigoBarras,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                // Mapea otras propiedades según lo requieras (por ejemplo, Cantidad, etc.)
            };
        }
    }
}
