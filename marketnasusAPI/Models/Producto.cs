using System;

namespace marketnasusAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }
        public int Cantidad { get; set; }
        public int? UmbralReabastecimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Relación: Un producto pertenece a una categoría
        public Categoria Categoria { get; set; }
    }
}
