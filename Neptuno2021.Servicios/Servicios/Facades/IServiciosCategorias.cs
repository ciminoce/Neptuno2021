using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Categoria;

namespace Neptuno2021.Servicios.Servicios.Facades
{
    public interface IServiciosCategorias
    {
        List<CategoriaListDto> GetLista();
        bool Existe(CategoriaEditDto categoriaEditDto);
        void Guardar(CategoriaEditDto categoriaEditDto);
        void Borrar(int categoriaId);
        CategoriaEditDto GetCategoriaPorId(int id);
    }
}
