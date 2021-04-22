namespace Neptuno2021.BL.Entidades
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
        public decimal Precio { get; set; }
        public double Cantidad { get; set; }

    }
}
