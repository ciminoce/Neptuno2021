using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Proveedor;

namespace Neptuno2021.Servicios.Servicios.Facades
{
    public interface IServicioProveedores
    {
        List<ProveedorListDto> GetLista();
        bool Existe(ProveedorEditDto proveedorEditDto);
        void Guardar(ProveedorEditDto proveedorEditDto);
        void Borrar(int proveedorId);
        ProveedorEditDto GetProveedorPorId(int proveedorId);
    }
}
