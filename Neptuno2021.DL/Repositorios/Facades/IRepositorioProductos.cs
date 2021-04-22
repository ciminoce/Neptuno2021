using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.BL.DTOs.Producto;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.DL.Repositorios.Facades
{
    public interface IRepositorioProductos
    {
        List<ProductoListDto> GetLista(int? caetgoriaId);
        ProductoEditDto GetProductoPorId(int id);
        void Guardar(Categoria categoria);
        void Borrar(int categoriaId);
        bool Existe(Categoria categoria);
        bool EstaRelacionado(Categoria categoria);

        void ActualizarStock(Producto detalleo, double cantidad);
    }
}
