using System;
using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL;
using Neptuno2021.DL.Repositorios;
using Neptuno2021.DL.Repositorios.Facades;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Servicios.Servicios
{
    public class ServicioClientes:IServicioClientes
    {
        private ConexionBd _conexionBd;
        private IRepositorioClientes _repositorio;
        private IRepositorioCiudades _repositorioCiudades;
        private IRepositorioPaises _repositorioPaises;

        public ServicioClientes()
        {
            
        }
        public List<ClienteListDto> GetLista(int? paisId, int? ciudadId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista(paisId, ciudadId);
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Guardar(ClienteEditDto clienteEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                Cliente cliente = new Cliente
                {
                    ClienteId = clienteEditDto.ClienteId,
                    NombreCompania = clienteEditDto.NombreCompania,
                    Direccion = clienteEditDto.Direccion,
                    CodPostal = clienteEditDto.CodPostal,
                    Pais = new Pais()
                    {
                        PaisId = clienteEditDto.Pais.PaisId,
                        NombrePais = clienteEditDto.Pais.NombrePais
                    },
                    Ciudad = new Ciudad
                    {
                        CiudadId = clienteEditDto.Ciudad.CiudadId,
                        NombreCiudad = clienteEditDto.Ciudad.NombreCiudad,
                        Pais = new Pais()
                        {
                            PaisId = clienteEditDto.Pais.PaisId,
                            NombrePais = clienteEditDto.Pais.NombrePais
                        }
                    },
                    Telefono = clienteEditDto.Telefono,
                    Email = clienteEditDto.Email

                };


                _repositorio.Guardar(cliente);

                clienteEditDto.ClienteId = cliente.ClienteId;
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }

        public bool Existe(ClienteEditDto clienteEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                //_repositorioPaises = new RepositorioPaises(_conexionBd.AbrirConexion());
                Cliente cliente = new Cliente
                {
                    ClienteId = clienteEditDto.ClienteId,
                    NombreCompania = clienteEditDto.NombreCompania,
                    Direccion = clienteEditDto.Direccion,
                    CodPostal = clienteEditDto.CodPostal,
                    Pais = new Pais()
                    {
                        PaisId = clienteEditDto.Pais.PaisId,
                        NombrePais = clienteEditDto.Pais.NombrePais
                    },
                    Ciudad = new Ciudad
                    {
                        CiudadId = clienteEditDto.Ciudad.CiudadId,
                        NombreCiudad = clienteEditDto.Ciudad.NombreCiudad,
                        Pais = new Pais()
                        {
                            PaisId = clienteEditDto.Pais.PaisId,
                            NombrePais = clienteEditDto.Pais.NombrePais
                        }
                    },
                    Telefono = clienteEditDto.Telefono,
                    Email = clienteEditDto.Email

                };
                var existe = _repositorio.Existe(cliente);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar ver si existe la ciudad");
            }

        }

        public void Borrar(int clienteId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion());
                _repositorio.Borrar(clienteId);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ClienteEditDto GetClientePorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioPaises = new RepositorioPaises(_conexionBd.AbrirConexion());
                _repositorioCiudades = new RepositorioCiudades(_conexionBd.AbrirConexion(), _repositorioPaises);
                _repositorio = new RepositorioClientes(_conexionBd.AbrirConexion(),_repositorioPaises, _repositorioCiudades);
                var cliente = _repositorio.GetClientePorId(id);
                _conexionBd.CerrarConexion();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
