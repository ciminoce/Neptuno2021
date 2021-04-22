using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL.Repositorios.Facades;

namespace Neptuno2021.DL.Repositorios
{
    public class RepositorioCiudades:IRepositorioCiudades
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IRepositorioPaises _repositorioPaises;

        public RepositorioCiudades(SqlConnection sqlConnection, IRepositorioPaises repositorioPaises)
        {
            _sqlConnection = sqlConnection;
            _repositorioPaises = repositorioPaises;
        }
        public RepositorioCiudades(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<CiudadListDto> GetLista(PaisListDto paisDto)
        {
            List<CiudadListDto> lista = new List<CiudadListDto>();
            try
            {
                string cadenaComando;
                SqlCommand comando;
                SqlDataReader reader;
                if (paisDto==null)
                {
                    cadenaComando =
                "SELECT CiudadId, NombreCiudad, NombrePais FROM Ciudades " +
                "INNER JOIN Paises ON Ciudades.PaisId=Paises.PaisId";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    reader = comando.ExecuteReader();

                }
                else
                {
                    cadenaComando =
                        "SELECT CiudadId, NombreCiudad, NombrePais FROM Ciudades " +
                        "INNER JOIN Paises ON Ciudades.PaisId=Paises.PaisId WHERE Ciudades.PaisId=@paisId";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@paisId", paisDto.PaisId);
                    reader = comando.ExecuteReader();

                }
                while (reader.Read())
                {
                    var ciudadDto = ConstruirCiudadDto(reader);
                    lista.Add(ciudadDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las ciudades");
            }
        }

        public void Guardar(Ciudad ciudad)
        {
            if (ciudad.CiudadId == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Ciudades VALUES(@nombre, @paisId)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", ciudad.NombreCiudad);
                    comando.Parameters.AddWithValue("@paisId", ciudad.Pais.PaisId);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    ciudad.CiudadId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar guardar una ciudad");
                }

            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Ciudades SET NombreCiudad=@nombre, PaisId=@paisId WHERE CiudadId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", ciudad.NombreCiudad);
                    comando.Parameters.AddWithValue("@paisId", ciudad.Pais.PaisId);

                    comando.Parameters.AddWithValue("@id", ciudad.CiudadId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al editar una ciudad");
                }

            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                if (ciudad.CiudadId == 0)
                {
                    string cadenaComando = "SELECT * FROM Ciudades WHERE NombreCiudad=@nomb AND PaisId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", ciudad.NombreCiudad);
                    comando.Parameters.AddWithValue("@id", ciudad.Pais.PaisId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Ciudades WHERE NombreCiudad=@nomb AND PaisId=@id AND CiudadId<>@ciudadId";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", ciudad.NombreCiudad);
                    comando.Parameters.AddWithValue("@id", ciudad.Pais.PaisId);
                    comando.Parameters.AddWithValue("@ciudadId", ciudad.CiudadId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

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
                string cadenaComando = "DELETE FROM Ciudades WHERE CiudadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
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

        public CiudadEditDto GetCiudadPorId(int id)
        {
            CiudadEditDto ciudad = null;
            try
            {
                string cadenaComando =
                    "SELECT CiudadId, NombreCiudad, PaisId FROM Ciudades WHERE CiudadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ciudad = ConstruirCiudad(reader);
                }
                reader.Close();
                return ciudad;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer la ciudad");
            }
        }

        private CiudadEditDto ConstruirCiudad(SqlDataReader reader)
        {
            var ciudad = new CiudadEditDto();
            ciudad.CiudadId = reader.GetInt32(0);
            ciudad.NombreCiudad = reader.GetString(1);
            var paisEditDto=_repositorioPaises.GetPaisPorId(reader.GetInt32(2));
            ciudad.Pais = new PaisListDto
            {
                PaisId = paisEditDto.PaisId,
                NombrePais = paisEditDto.NombrePais
            };
            return ciudad;
        }

        private CiudadListDto ConstruirCiudadDto(SqlDataReader reader)
        {
            CiudadListDto ciudadDto = new CiudadListDto();
            ciudadDto.CiudadId = reader.GetInt32(0);
            ciudadDto.NombreCiudad = reader.GetString(1);
            ciudadDto.NombrePais = reader.GetString(2);
            return ciudadDto;
        }
    }
}
