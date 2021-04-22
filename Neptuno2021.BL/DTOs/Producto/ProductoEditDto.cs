using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.BL.DTOs.Proveedor;

namespace Neptuno2021.BL.DTOs.Producto
{
    public class ProductoEditDto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public ProveedorListDto ProveedorDto { get; set; }
        public CategoriaListDto CategoriaDto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public double UnidadesEnExistencia { get; set; }
        public double UnidadesEnPedido { get; set; }
        public bool Suspendido { get; set; }

    }
}
