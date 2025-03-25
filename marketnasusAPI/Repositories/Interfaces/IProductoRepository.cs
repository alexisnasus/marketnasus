using marketnasusAPI.Models;

namespace marketnasusAPI.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        // Obtiene un producto por su ID
        Task<Producto> GetByIdAsync(int id);

        // Obtiene un producto por su código de barras (opcional, para otros casos)
        Task<Producto> GetByCodigoBarrasAsync(string codigoBarras);

        // Obtiene todos los productos
        Task<IEnumerable<Producto>> GetAllAsync();

        // Agrega un nuevo producto
        Task AddAsync(Producto producto);

        // Actualiza un producto existente
        Task UpdateAsync(Producto producto);

        // Elimina un producto por su ID
        Task DeleteAsync(int id);
    }
}
