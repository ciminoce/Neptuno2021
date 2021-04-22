using Neptuno2021.BL.DTOs.Producto;

namespace Neptuno2021.BL.DTOs.DetalleVenta
{
    public class DetalleVentaEditDto
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public ProductoListDto Producto { get; set; }
        public decimal Precio { get; set; }
        public double Cantidad { get; set; }

        public decimal Total => Precio * (decimal)Cantidad;


    }
}
