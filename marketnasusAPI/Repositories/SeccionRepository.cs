using marketnasusAPI.Data;
using marketnasusAPI.Models;
using marketnasusAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketnasusAPI.Repositories
{
    public class SeccionRepository : ISeccionRepository
    {
        private readonly ApplicationDbContext _context;

        public SeccionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Seccion> GetSeccionByIdAsync(int id)
        {
            return await _context.Secciones.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Seccion>> GetAllAsync()
        {
            return await _context.Secciones.ToListAsync();
        }

        public async Task AddSeccionAsync(Seccion seccion)
        {
            await _context.Secciones.AddAsync(seccion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSeccionAsync(Seccion seccion)
        {
            _context.Secciones.Update(seccion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeccionAsync(int id)
        {
            var seccion = await GetSeccionByIdAsync(id);
            if (seccion != null)
            {
                _context.Secciones.Remove(seccion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
