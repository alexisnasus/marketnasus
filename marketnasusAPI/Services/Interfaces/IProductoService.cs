using marketnasusAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketnasusAPI.Services.Interfaces
{
    public interface IProductoService
    {
        // Obtiene un producto basado en su código de barras
        Task<ProductoDTO> GetProductoByCodigoBarrasAsync(string codigoBarras);

        // Obtiene un producto por su ID
        Task<ProductoDTO> GetProductoByIdAsync(int id);

        // Obtiene todos los productos
        Task<IEnumerable<ProductoDTO>> GetAllProductosAsync();

        // Agrega un nuevo producto
        Task AddProductoAsync(ProductoDTO productoDto);

        // Actualiza un producto existente
        Task UpdateProductoAsync(ProductoDTO productoDto);

        // Elimina un producto por su ID
        Task DeleteProductoAsync(int id);
    }
}
