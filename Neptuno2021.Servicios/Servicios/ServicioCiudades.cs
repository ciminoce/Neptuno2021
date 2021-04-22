using System;
using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL;
using Neptuno2021.DL.Repositorios;
using Neptuno2021.DL.Repositorios.Facades;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Servicios.Servicios
{
    public class ServicioCiudades:IServicioCiudades
    {
        private  ConexionBd _conexionBd;
        private  IRepositorioCiudades _repositorio;
        private IRepositorioPaises _repositorioPaises;

        public ServicioCiudades()
        {
           
        }
        public List<CiudadListDto> GetLista(PaisListDto paisDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCiudades(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista(paisDto);
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(CiudadEditDto ciudadDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCiudades(_conexionBd.AbrirConexion());
                //_repositorioPaises = new RepositorioPaises(_conexionBd.AbrirConexion());
                Ciudad ciudad = new Ciudad
                {
                    CiudadId = ciudadDto.CiudadId,
                    NombreCiudad = ciudadDto.NombreCiudad,
                    Pais = new Pais
                    {
                        PaisId = ciudadDto.Pais.PaisId,
                        NombrePais = ciudadDto.Pais.NombrePais
                    }
                };
                var existe = _repositorio.Existe(ciudad);
                _conexionBd.CerrarConexion();
                return existe;
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
                _repositorio = new RepositorioCiudades(_conexionBd.AbrirConexion());
                _repositorio.Borrar(id);
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public CiudadEditDto GetCiudadPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioPaises = new RepositorioPaises(_conexionBd.AbrirConexion());
                _repositorio = new RepositorioCiudades(_conexionBd.AbrirConexion(), _repositorioPaises);
                //_repositorio = new RepositorioCiudades(_conexionBd.AbrirConexion());
                var ciudad = _repositorio.GetCiudadPorId(id);
                _conexionBd.CerrarConexion();
                return ciudad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(CiudadEditDto ciudadDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioCiudades(_conexionBd.AbrirConexion());
                Ciudad ciudad = new Ciudad
                {
                    CiudadId = ciudadDto.CiudadId,
                    NombreCiudad = ciudadDto.NombreCiudad,
                    Pais=new Pais
                    {
                        PaisId = ciudadDto.Pais.PaisId,
                        NombrePais = ciudadDto.Pais.NombrePais
                    }
                };

                _repositorio.Guardar(ciudad);

                ciudadDto.CiudadId = ciudad.CiudadId;
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
