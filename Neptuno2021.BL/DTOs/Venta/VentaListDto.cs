using System;
using System.Security.AccessControl;

namespace Neptuno2021.BL.DTOs.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
