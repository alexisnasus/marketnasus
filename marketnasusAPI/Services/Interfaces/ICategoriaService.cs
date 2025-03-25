using marketnasusAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketnasusAPI.Services.Interfaces
{
    public interface ICategoriaService
    {
        // Obtiene una categoría por su ID
        Task<CategoriaDTO> GetCategoriaByIdAsync(int id);

        // Obtiene todas las categorías
        Task<IEnumerable<CategoriaDTO>> GetAllCategoriasAsync();

        // Agrega una nueva categoría
        Task AddCategoriaAsync(CategoriaDTO categoriaDto);

        // Actualiza una categoría existente
        Task UpdateCategoriaAsync(CategoriaDTO categoriaDto);

        // Elimina una categoría por su ID  
        Task DeleteCategoriaAsync(int id);
    }
}
