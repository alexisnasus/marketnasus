using marketnasusAPI.Data;
using marketnasusAPI.Models;
using marketnasusAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketnasusAPI.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public VentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Recupera una venta por su ID, incluyendo sus detalles
        public async Task<Venta> GetVentaByIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.VentaDetalles)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        // Recupera todas las ventas, incluyendo los detalles de cada una
        public async Task<IEnumerable<Venta>> GetAllVentasAsync()
        {
            return await _context.Ventas
                .Include(v => v.VentaDetalles)
                .ToListAsync();
        }

        // Agrega una nueva venta a la base de datos
        public async Task AddVentaAsync(Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();
        }

        // Actualiza la venta existente en la base de datos
        public async Task UpdateVentaAsync(Venta venta)
        {
            _context.Ventas.Update(venta);
            await _context.SaveChangesAsync();
        }

        // Elimina una venta por su ID
        public async Task DeleteVentaAsync(int id)
        {
            var venta = await GetVentaByIdAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
