using System;

namespace marketnasusAPI.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSeccion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
