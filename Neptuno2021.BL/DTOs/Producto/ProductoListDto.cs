using System;

namespace Neptuno2021.BL.DTOs.Producto
{
    public class ProductoListDto:ICloneable
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public double UnidadesEnExistencia { get; set; }
        public bool Suspendido { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
