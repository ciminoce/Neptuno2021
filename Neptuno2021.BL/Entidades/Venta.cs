using System;
using System.Collections.Generic;

namespace Neptuno2021.BL.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaVenta { get; set; }

        public List<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();

    }
}
