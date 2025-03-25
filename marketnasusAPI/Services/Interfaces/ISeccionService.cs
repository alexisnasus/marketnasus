using marketnasusAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketnasusAPI.Services.Interfaces
{
    public interface ISeccionService
    {
        // Obtiene una sección por su ID
        Task<SeccionDTO> GetSeccionByIdAsync(int id);

        // Obtiene todas las secciones
        Task<IEnumerable<SeccionDTO>> GetAllSeccionesAsync();

        // Agrega una nueva sección
        Task AddSeccionAsync(SeccionDTO seccionDto);

        // Actualiza una sección existente
        Task UpdateSeccionAsync(SeccionDTO seccionDto);

        // Elimina una sección por su ID
        Task DeleteSeccionAsync(int id);
    }
}
