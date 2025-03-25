using Microsoft.AspNetCore.Mvc;
using marketnasusAPI.Services.Interfaces;
using marketnasusAPI.DTOs;
using System.Threading.Tasks;

namespace marketnasusAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeccionesController : ControllerBase
    {
        private readonly ISeccionService _seccionService;

        public SeccionesController(ISeccionService seccionService)
        {
            _seccionService = seccionService;
        }

        // GET: api/secciones
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var secciones = await _seccionService.GetAllSeccionesAsync();
            return Ok(secciones);
        }

        // GET: api/secciones/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seccion = await _seccionService.GetSeccionByIdAsync(id);
            if (seccion == null)
                return NotFound();
            return Ok(seccion);
        }

        // POST: api/secciones
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SeccionDTO seccionDto)
        {
            if (seccionDto == null)
                return BadRequest();

            await _seccionService.AddSeccionAsync(seccionDto);
            // Se asume que se asigna el ID en la base de datos y se refleja en el DTO.
            return CreatedAtAction(nameof(GetById), new { id = seccionDto.Id }, seccionDto);
        }

        // PUT: api/secciones/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SeccionDTO seccionDto)
        {
            if (seccionDto == null || seccionDto.Id != id)
                return BadRequest();

            var existingSeccion = await _seccionService.GetSeccionByIdAsync(id);
            if (existingSeccion == null)
                return NotFound();

            await _seccionService.UpdateSeccionAsync(seccionDto);
            return NoContent();
        }

        // DELETE: api/secciones/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSeccion = await _seccionService.GetSeccionByIdAsync(id);
            if (existingSeccion == null)
                return NotFound();

            await _seccionService.DeleteSeccionAsync(id);
            return NoContent();
        }
    }
}
