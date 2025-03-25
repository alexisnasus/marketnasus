using marketnasusAPI.DTOs;
using marketnasusAPI.Models;
using marketnasusAPI.Repositories.Interfaces;
using marketnasusAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketnasusAPI.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaDTO> GetCategoriaByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
            if (categoria == null)
                return null;

            return MapearACategoriaDTO(categoria);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllCategoriasAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            return categorias.Select(c => MapearACategoriaDTO(c));
        }

        public async Task AddCategoriaAsync(CategoriaDTO categoriaDto)
        {
            var categoria = new Categoria
            {
                Nombre = categoriaDto.Nombre,
                IdSeccion = categoriaDto.IdSeccion,
                // La propiedad FechaCreacion se asigna automáticamente (o puedes asignarla con CURRENT_TIMESTAMP)
            };

            await _categoriaRepository.AddCategoriaAsync(categoria);
        }

        public async Task UpdateCategoriaAsync(CategoriaDTO categoriaDto)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdAsync(categoriaDto.Id);
            if (categoria == null)
                return;

            categoria.Nombre = categoriaDto.Nombre;
            categoria.IdSeccion = categoriaDto.IdSeccion;

            await _categoriaRepository.UpdateCategoriaAsync(categoria);
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            await _categoriaRepository.DeleteCategoriaAsync(id);
        }

        private CategoriaDTO MapearACategoriaDTO(Categoria categoria)
        {
            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                IdSeccion = categoria.IdSeccion,
                FechaCreacion = categoria.FechaCreacion
            };
        }
    }
}
