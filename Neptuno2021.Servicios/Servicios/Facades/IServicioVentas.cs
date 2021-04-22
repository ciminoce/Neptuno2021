using System.Collections.Generic;
using Neptuno2021.BL.DTOs.DetalleVenta;
using Neptuno2021.BL.DTOs.Venta;

namespace Neptuno2021.Servicios.Servicios.Facades
{
    public interface IServicioVentas
    {
        List<VentaListDto> GetLista();
        void Guardar(VentaEditDto ventaDto);
        VentaEditDto GetVentaPorId(int id);

        List<DetalleVentaListDto> GetDetalle(int ventaDtoVentaId);
    }
}
