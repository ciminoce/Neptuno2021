using System;
using System.Collections.Generic;
using System.Linq;
using Neptuno2021.BL.DTOs.DetalleVenta;

namespace Neptuno2021.BL.DTOs.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaVenta { get; set; }

        public List<DetalleVentaListDto> ItemsVenta { get; set; } = new List<DetalleVentaListDto>();

        public decimal TotalVenta => ItemsVenta.Sum(i => i.PrecioUnitario * (decimal) i.Cantidad);
    }
}
