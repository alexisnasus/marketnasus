using marketnasusAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketnasusAPI.Repositories.Interfaces
{
    public interface IVentaRepository
    {
        // Obtiene una venta por su ID, incluyendo los detalles de venta
        Task<Venta> GetVentaByIdAsync(int id);

        // Obtiene todas las ventas registradas
        Task<IEnumerable<Venta>> GetAllVentasAsync();

        // Agrega una nueva venta a la base de datos
        Task AddVentaAsync(Venta venta);

        // Actualiza una venta existente
        Task UpdateVentaAsync(Venta venta);

        // Elimina una venta por su ID
        Task DeleteVentaAsync(int id);
    }
}
