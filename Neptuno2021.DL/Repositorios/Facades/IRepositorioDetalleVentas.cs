using System.Collections.Generic;
using Neptuno2021.BL.DTOs.DetalleVenta;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.DL.Repositorios.Facades
{
    public interface IRepositorioDetalleVentas
    {
        List<DetalleVentaListDto> GetLista(int ventaId);
        void Guardar(DetalleVenta detalle);
    }
}
