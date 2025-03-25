using marketnasusAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketnasusAPI.Repositories.Interfaces
{
    public interface ISeccionRepository
    {
        // Obtiene una sección por su ID
        Task<Seccion> GetSeccionByIdAsync(int id);

        // Obtiene todas las secciones
        Task<IEnumerable<Seccion>> GetAllAsync();

        // Agrega una nueva sección
        Task AddSeccionAsync(Seccion seccion);

        // Actualiza una sección existente
        Task UpdateSeccionAsync(Seccion seccion);

        // Elimina una sección por su ID
        Task DeleteSeccionAsync(int id);
    }
}
