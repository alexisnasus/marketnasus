using System;
using System.Collections.Generic;

namespace marketnasusAPI.DTOs
{
    public class SeccionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        // Lista de categorías que pertenecen a la sección
        public List<CategoriaDTO> Categorias { get; set; }
    }
}
