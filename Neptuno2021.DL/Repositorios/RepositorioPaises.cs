using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL.Repositorios.Facades;

namespace Neptuno2021.DL.Repositorios
{
    public class RepositorioPaises:IRepositorioPaises
    {
        private readonly SqlConnection _conexion;

        public RepositorioPaises(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public List<Pais> GetPaises()
        {
            List<Pais> lista = new List<Pais>();
            try
            {
                string cadenaComando = "SELECT PaisId, NombrePais FROM Paises";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pais pais = ConstruirPais(reader);
                    lista.Add(pais);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los países");
            }
        }

        private Pais ConstruirPais(SqlDataReader reader)
        {
            return new Pais
            {
                PaisId = reader.GetInt32(0),
                NombrePais = reader.GetString(1)
            };
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
