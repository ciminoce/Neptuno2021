using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.DTOs.Pais;
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
        public List<PaisListDto> GetPaises()
        {
            List<PaisListDto> lista = new List<PaisListDto>();
            try
            {
                string cadenaComando = "SELECT PaisId, NombrePais FROM Paises";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    PaisListDto pais = ConstruirPaisListDto(reader);
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

        private PaisListDto ConstruirPaisListDto(SqlDataReader reader)
        {
            return new PaisListDto
            {
                PaisId = reader.GetInt32(0),
                NombrePais = reader.GetString(1)
            };
        }

        public PaisEditDto GetPaisPorId(int id)
        {
            PaisEditDto pais = null;
            try
            {
                string cadenaComando =
                    "SELECT PaisId, NombrePais FROM Paises WHERE PaisId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    pais = ConstruirPaisEditDto(reader);
                }
                reader.Close();
                return pais;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los países");
            }

        }

        private PaisEditDto ConstruirPaisEditDto(SqlDataReader reader)
        {
            return new PaisEditDto
            {
                PaisId = reader.GetInt32(0),
                NombrePais = reader.GetString(1)
            };
        }

        public void Guardar(Pais pais)
        {
            if (pais.PaisId == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Paises VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", pais.NombrePais);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    pais.PaisId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar guardar un registro");
                }

            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Paises SET NombrePais=@nombre WHERE PaisId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", pais.NombrePais);
                    comando.Parameters.AddWithValue("@id", pais.PaisId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar modificar un registro");
                }

            }

        }

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Paises WHERE PaisId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro con datos asociados... Baja denegada");
                }
                throw new Exception(e.Message);
            }

        }

        public bool Existe(Pais pais)
        {
            if (pais.PaisId == 0)
            {
                //Nuevo pais
                string cadenaComando = "SELECT PaisId, NombrePais FROM Paises WHERE NombrePais=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", pais.NombrePais);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                //Edicion de pais
                string cadenaComando = "SELECT PaisId, NombrePais FROM Paises WHERE NombrePais=@nom AND PaisId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", pais.NombrePais);
                comando.Parameters.AddWithValue("@id", pais.PaisId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }

        }
    }
}
