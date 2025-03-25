using marketnasusAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketnasusAPI.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        // Obtiene una categoría por su ID
        Task<Categoria> GetCategoriaByIdAsync(int id);

        // Obtiene todas las categorías
        Task<IEnumerable<Categoria>> GetAllAsync();

        // Agrega una nueva categoría
        Task AddCategoriaAsync(Categoria categoria);

        // Actualiza una categoría existente
        Task UpdateCategoriaAsync(Categoria categoria);

        // Elimina una categoría por su ID
        Task DeleteCategoriaAsync(int id);
    }
}
