using System;
using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.DTOs.DetalleVenta;

namespace Neptuno2021.BL.DTOs.Venta
{
    public class VentaEditDto
    {
        public int VentaId { get; set; }
        public ClienteListDto Cliente { get; set; }
        public DateTime FechaVenta { get; set; }

        public List<DetalleVentaEditDto> DetalleVentas { get; set; } = new List<DetalleVentaEditDto>();

    }
}
