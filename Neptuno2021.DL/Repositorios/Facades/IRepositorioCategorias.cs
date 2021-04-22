using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.DL.Repositorios.Facades
{
    public interface IRepositorioCategorias
    {
        List<CategoriaListDto> GetLista();
        CategoriaEditDto GetCategoriaPorId(int id);
        void Guardar(Categoria categoria);
        void Borrar(int categoriaId);
        bool Existe(Categoria categoria);
        bool EstaRelacionado(Categoria categoria);
    }
}
