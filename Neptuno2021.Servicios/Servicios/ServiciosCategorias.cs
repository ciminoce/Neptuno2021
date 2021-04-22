using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL;
using Neptuno2021.DL.Repositorios;
using Neptuno2021.DL.Repositorios.Facades;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Servicios.Servicios
{
    public class ServiciosCategorias:IServiciosCategorias
    {
        private ConexionBd _conexionBd;
        private IRepositorioCategorias _repositorio;

        public ServiciosCategorias()
        {
            
        }
        public List<CategoriaListDto> GetLista()
        {
            try
            {
                _conexionBd=new ConexionBd();
                _repositorio=new RepositorioCategorias(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(CategoriaEditDto categoriaEditDto)
        {
            try
            {
                Categoria categoria = new Categoria
                {
                    CategoriaId = categoriaEditDto.CategoriaId,
                    NombreCategoria = categoriaEditDto.NombreCategoria,
                    Descripcion = categoriaEditDto.Descripcion
                };
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCategorias(_conexionBd.AbrirConexion());
                var existe = _repositorio.Existe(categoria);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(CategoriaEditDto categoriaEditDto)
        {
            try
            {
                Categoria categoria = new Categoria
                {
                    CategoriaId = categoriaEditDto.CategoriaId,
                    NombreCategoria = categoriaEditDto.NombreCategoria,
                    Descripcion = categoriaEditDto.Descripcion
                };
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCategorias(_conexionBd.AbrirConexion());
                _repositorio.Guardar(categoria);
                _conexionBd.CerrarConexion();
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int categoriaId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCategorias(_conexionBd.AbrirConexion());
                _repositorio.Borrar(categoriaId);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CategoriaEditDto GetCategoriaPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCategorias(_conexionBd.AbrirConexion());
                var categoriaDto = _repositorio.GetCategoriaPorId(id);
                _conexionBd.CerrarConexion();
                return categoriaDto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
