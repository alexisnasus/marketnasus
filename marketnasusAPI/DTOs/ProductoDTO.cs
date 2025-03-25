namespace marketnasusAPI.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int? UmbralReabastecimiento { get; set; }
        // Opcionalmente, puedes agregar datos de la categoría o sección si es necesario
    }
}
