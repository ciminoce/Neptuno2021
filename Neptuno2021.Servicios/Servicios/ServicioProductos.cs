using System;
using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Producto;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL;
using Neptuno2021.DL.Repositorios;
using Neptuno2021.DL.Repositorios.Facades;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Servicios.Servicios
{
    public class ServicioProductos:IServicioProductos
    {
        private IRepositorioProductos _repositorio;
        private ConexionBd _conexionBd;

        public List<ProductoListDto> GetLista(int? caetgoriaId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProductos(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista(caetgoriaId);
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

       

        public ProductoEditDto GetProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(ProductoEditDto categoria)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int categoriaId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(ProductoEditDto categoria)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
