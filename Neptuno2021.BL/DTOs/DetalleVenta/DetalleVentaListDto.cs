namespace Neptuno2021.BL.DTOs.DetalleVenta
{
    public class DetalleVentaListDto
    {
        public int DetalleVentaId { get; set; }
        public string Producto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public double Cantidad { get; set; }

        public decimal Total => PrecioUnitario*(decimal) Cantidad;
    }
}
