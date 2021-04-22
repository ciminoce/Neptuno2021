using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Producto;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.Servicios.Servicios.Facades
{
    public interface IServicioProductos
    {
        List<ProductoListDto> GetLista(int? categoriaId);
        ProductoEditDto GetProductoPorId(int id);
        void Guardar(ProductoEditDto categoria);
        void Borrar(int categoriaId);
        bool Existe(ProductoEditDto categoria);
        bool EstaRelacionado(Categoria categoria);

    }
}
