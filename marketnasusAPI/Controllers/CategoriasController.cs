using Microsoft.AspNetCore.Mvc;
using marketnasusAPI.Services.Interfaces;
using marketnasusAPI.DTOs;
using System.Threading.Tasks;

namespace marketnasusAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaService.GetAllCategoriasAsync();
            return Ok(categorias);
        }

        // GET: api/categorias/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        // POST: api/categorias
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
                return BadRequest();

            await _categoriaService.AddCategoriaAsync(categoriaDto);
            return CreatedAtAction(nameof(GetById), new { id = categoriaDto.Id }, categoriaDto);
        }

        // PUT: api/categorias/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null || categoriaDto.Id != id)
                return BadRequest();

            var existingCategoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (existingCategoria == null)
                return NotFound();

            await _categoriaService.UpdateCategoriaAsync(categoriaDto);
            return NoContent();
        }

        // DELETE: api/categorias/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCategoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (existingCategoria == null)
                return NotFound();

            await _categoriaService.DeleteCategoriaAsync(id);
            return NoContent();
        }
    }
}
