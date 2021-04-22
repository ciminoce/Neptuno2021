using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2021.BL.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public Proveedor Proveedor { get; set; }
        public Categoria Categoria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public double UnidadesEnExistencia { get; set; }
        public double UnidadesEnPedido { get; set; }
        public bool Suspendido { get; set; }
    }
}
