using System;
using System.Collections.Generic;

namespace marketnasusAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSeccion { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación: Una categoría pertenece a una sección
        public Seccion Seccion { get; set; }

        // Relación: Una categoría tiene muchos productos
        public ICollection<Producto> Productos { get; set; }
    }
}
