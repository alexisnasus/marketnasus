using System;
using System.Collections.Generic;

namespace marketnasusAPI.Models
{
    public class Seccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación: Una sección tiene muchas categorías
        public ICollection<Categoria> Categorias { get; set; }
    }
}
