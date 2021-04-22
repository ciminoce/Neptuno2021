using System;
using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Proveedor;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL;
using Neptuno2021.DL.Repositorios;
using Neptuno2021.DL.Repositorios.Facades;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Servicios.Servicios
{
    public class ServicioProveedores:IServicioProveedores
    {
        private ConexionBd _conexionBd;
        private IRepositorioProveedores _repositorio;
        private IRepositorioPaises _repositorioPaises;
        private IRepositorioCiudades _repositorioCiudades;

        public ServicioProveedores(ConexionBd conexionBd, IRepositorioProveedores repositorio, IRepositorioPaises repositorioPaises, IRepositorioCiudades repositorioCiudades)
        {
            _conexionBd = conexionBd;
            _repositorio = repositorio;
            _repositorioPaises = repositorioPaises;
            _repositorioCiudades = repositorioCiudades;
        }

        public ServicioProveedores()
        {

        }
        public List<ProveedorListDto> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProveedores(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Guardar(ProveedorEditDto proveedorEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProveedores(_conexionBd.AbrirConexion());
                Proveedor proveedor = new Proveedor
                {
                    ProveedorId = proveedorEditDto.ProveedorId,
                    NombreCompania = proveedorEditDto.NombreCompania,
                    Direccion = proveedorEditDto.Direccion,
                    CodPostal = proveedorEditDto.CodPostal,
                    Pais = new Pais()
                    {
                        PaisId = proveedorEditDto.Pais.PaisId,
                        NombrePais = proveedorEditDto.Pais.NombrePais
                    },
                    Ciudad = new Ciudad
                    {
                        CiudadId = proveedorEditDto.Ciudad.CiudadId,
                        NombreCiudad = proveedorEditDto.Ciudad.NombreCiudad,
                        Pais = new Pais()
                        {
                            PaisId = proveedorEditDto.Pais.PaisId,
                            NombrePais = proveedorEditDto.Pais.NombrePais
                        }
                    },
                    Telefono = proveedorEditDto.Telefono,
                    Email = proveedorEditDto.Email

                };


                _repositorio.Guardar(proveedor);

                proveedorEditDto.ProveedorId = proveedor.ProveedorId;
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }

        public bool Existe(ProveedorEditDto proveedorEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProveedores(_conexionBd.AbrirConexion());
                Proveedor proveedor = new Proveedor
                {
                    NombreCompania = proveedorEditDto.NombreCompania,
                    Direccion = proveedorEditDto.Direccion,
                    CodPostal = proveedorEditDto.CodPostal,
                    Pais = new Pais()
                    {
                        PaisId = proveedorEditDto.Pais.PaisId,
                        NombrePais = proveedorEditDto.Pais.NombrePais
                    },
                    Ciudad = new Ciudad
                    {
                        CiudadId = proveedorEditDto.Ciudad.CiudadId,
                        NombreCiudad = proveedorEditDto.Ciudad.NombreCiudad,
                        Pais = new Pais()
                        {
                            PaisId = proveedorEditDto.Pais.PaisId,
                            NombrePais = proveedorEditDto.Pais.NombrePais
                        }
                    },
                    Telefono = proveedorEditDto.Telefono,
                    Email = proveedorEditDto.Email

                };
                var existe = _repositorio.Existe(proveedor);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar ver si existe el proveedor");
            }

        }

        public void Borrar(int proveedorId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioProveedores(_conexionBd.AbrirConexion());
                _repositorio.Borrar(proveedorId);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ProveedorEditDto GetProveedorPorId(int proveedorId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioPaises = new RepositorioPaises(_conexionBd.AbrirConexion());
                _repositorioCiudades = new RepositorioCiudades(_conexionBd.AbrirConexion(), _repositorioPaises);
                _repositorio = new RepositorioProveedores(_conexionBd.AbrirConexion(), _repositorioPaises, _repositorioCiudades);
                var proveedor = _repositorio.GetProveedorPorId(proveedorId);
                _conexionBd.CerrarConexion();
                return proveedor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
