using System;
using System.Collections.Generic;
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
        public List<Pais> GetPaises()
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

        public Pais GetPaisPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Pais pais)
        {
            throw new System.NotImplementedException();
        }

        public void Borrar(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(Pais pais)
        {
            throw new System.NotImplementedException();
        }
    }
}
