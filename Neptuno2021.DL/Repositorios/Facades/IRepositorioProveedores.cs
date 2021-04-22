using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Proveedor;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.DL.Repositorios.Facades
{
    public interface IRepositorioProveedores
    {
        List<ProveedorListDto> GetLista();
        void Guardar(Proveedor proveedor);
        bool Existe(Proveedor proveedor);
        void Borrar(int proveedorId);
        ProveedorEditDto GetProveedorPorId(int proveedorId);
    }
}
