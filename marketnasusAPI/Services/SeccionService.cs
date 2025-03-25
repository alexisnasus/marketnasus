using marketnasusAPI.DTOs;
using marketnasusAPI.Models;
using marketnasusAPI.Repositories.Interfaces;
using marketnasusAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketnasusAPI.Services
{
    public class SeccionService : ISeccionService
    {
        private readonly ISeccionRepository _seccionRepository;

        public SeccionService(ISeccionRepository seccionRepository)
        {
            _seccionRepository = seccionRepository;
        }

        public async Task<SeccionDTO> GetSeccionByIdAsync(int id)
        {
            var seccion = await _seccionRepository.GetSeccionByIdAsync(id);
            if (seccion == null)
                return null;

            return MapearASeccionDTO(seccion);
        }

        public async Task<IEnumerable<SeccionDTO>> GetAllSeccionesAsync()
        {
            var secciones = await _seccionRepository.GetAllAsync();
            return secciones.Select(s => MapearASeccionDTO(s));
        }

        public async Task AddSeccionAsync(SeccionDTO seccionDto)
        {
            var seccion = new Seccion
            {
                Nombre = seccionDto.Nombre,
                Descripcion = seccionDto.Descripcion,
                // FechaCreacion se puede asignar automáticamente
            };

            await _seccionRepository.AddSeccionAsync(seccion);
        }

        public async Task UpdateSeccionAsync(SeccionDTO seccionDto)
        {
            var seccion = await _seccionRepository.GetSeccionByIdAsync(seccionDto.Id);
            if (seccion == null)
                return;

            seccion.Nombre = seccionDto.Nombre;
            seccion.Descripcion = seccionDto.Descripcion;

            await _seccionRepository.UpdateSeccionAsync(seccion);
        }

        public async Task DeleteSeccionAsync(int id)
        {
            await _seccionRepository.DeleteSeccionAsync(id);
        }

        private SeccionDTO MapearASeccionDTO(Seccion seccion)
        {
            return new SeccionDTO
            {
                Id = seccion.Id,
                Nombre = seccion.Nombre,
                Descripcion = seccion.Descripcion,
                FechaCreacion = seccion.FechaCreacion
            };
        }
    }
}
