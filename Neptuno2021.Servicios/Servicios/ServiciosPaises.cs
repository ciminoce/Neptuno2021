using System;
using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL;
using Neptuno2021.DL.Repositorios;
using Neptuno2021.DL.Repositorios.Facades;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Servicios.Servicios
{
    public class ServiciosPaises:IServiciosPais
    {
        private IRepositorioPaises _repositorio;
        private ConexionBd _conexionBd;

        public ServiciosPaises()
        {
        }
        public List<PaisListDto> GetPaises()
        {
            try
            {
                 _conexionBd = new ConexionBd();
                 _repositorio = new RepositorioPaises(_conexionBd.AbrirConexion());
                 var lista = _repositorio.GetPaises();
                 _conexionBd.CerrarConexion();
                 return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public PaisEditDto GetPaisPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioPaises(_conexionBd.AbrirConexion());
                var pais = _repositorio.GetPaisPorId(id);
                _conexionBd.CerrarConexion();
                return pais;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Guardar(PaisEditDto paisDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioPaises(_conexionBd.AbrirConexion());
                var pais = new Pais
                {
                    PaisId = paisDto.PaisId,
                    NombrePais = paisDto.NombrePais
                };
                _repositorio.Guardar(pais);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }

        public void Borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioPaises(_conexionBd.AbrirConexion());
                _repositorio.Borrar(id);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool Existe(PaisEditDto paisDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioPaises(_conexionBd.AbrirConexion());
                var pais = new Pais
                {
                    PaisId = paisDto.PaisId,
                    NombrePais = paisDto.NombrePais
                };

                var existe = _repositorio.Existe(pais);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
