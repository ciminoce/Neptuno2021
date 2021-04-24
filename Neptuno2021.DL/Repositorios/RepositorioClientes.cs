using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL.Repositorios.Facades;

namespace Neptuno2021.DL.Repositorios
{
    public class RepositorioClientes:IRepositorioClientes
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IRepositorioPaises _repositorioPaises;
        private readonly IRepositorioCiudades _repositorioCiudades;

        public RepositorioClientes(SqlConnection sqlConnection, IRepositorioPaises repositorioPaises, IRepositorioCiudades repositorioCiudades)
        {
            _sqlConnection = sqlConnection;
            _repositorioPaises = repositorioPaises;
            _repositorioCiudades = repositorioCiudades;
        }

        public RepositorioClientes(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<ClienteListDto> GetLista(int? paisId, int? ciudadId)
        {
            List<ClienteListDto> lista = new List<ClienteListDto>();
            try
            {
                StringBuilder cadenaComando = new StringBuilder();
                cadenaComando.Append("SELECT ClienteId, NombreCompania, NombrePais, NombreCiudad FROM Clientes " +
                                     "INNER JOIN Paises ON Clientes.PaisId=Paises.PaisId "+
                                     "INNER JOIN Ciudades ON Clientes.CiudadId=Ciudades.CiudadId");
                if (paisId!=null)
                {
                    cadenaComando.Append(" WHERE Clientes.PaisId=@paisId ");
                    if (ciudadId!=null)
                    {
                        cadenaComando.Append(" AND Clientes.CiudadId=@ciudadId");
                    }
                }
                SqlCommand comando = new SqlCommand(cadenaComando.ToString(), _sqlConnection);
                if (paisId != null)
                {
                    comando.Parameters.AddWithValue("@paisId", paisId);
                    if (ciudadId != null)
                    {
                        comando.Parameters.AddWithValue("@ciudadId", ciudadId);
                    }
                }

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var clienteListDto = ConstruirClienteListDto(reader);
                    lista.Add(clienteListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los clientes");
            }

        }

        public void Guardar(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Clientes VALUES(@nombre, @dir, @cp, @paisId, @ciudadId, @tel, @mail)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", cliente.NombreCompania);
                    if (cliente.Direccion!=string.Empty)
                    {
                        comando.Parameters.AddWithValue("@dir", cliente.Direccion);
                        
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@dir", DBNull.Value);
                    }
                    if (cliente.CodPostal!=string.Empty)
                    {
                        comando.Parameters.AddWithValue("@cp", cliente.CodPostal);
                        
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@cp", DBNull.Value);
                    }

                    comando.Parameters.AddWithValue("@paisId", cliente.Pais.PaisId);
                    comando.Parameters.AddWithValue("@ciudadId", cliente.Ciudad.CiudadId);
                    if (cliente.Telefono != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@tel", cliente.Telefono);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@tel", DBNull.Value);
                    }
                    if (cliente.Email != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@mail", cliente.Email);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@mail", DBNull.Value);
                    }


                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    cliente.ClienteId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar guardar un cliente");
                }

            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Clientes SET NombreCompania=@nombre, Direccion=@dir, CodPostal=@cp," +
                                           " PaisId=@paisId, CiudadId=@ciudadId, Telefono=@tel, Email=@mail WHERE ClienteId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", cliente.NombreCompania);
                    if (cliente.Direccion != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@dir", cliente.Direccion);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@dir", DBNull.Value);
                    }
                    if (cliente.CodPostal != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@cp", cliente.CodPostal);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@cp", DBNull.Value);
                    }

                    comando.Parameters.AddWithValue("@paisId", cliente.Pais.PaisId);
                    comando.Parameters.AddWithValue("@ciudadId", cliente.Ciudad.CiudadId);
                    if (cliente.Telefono != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@tel", cliente.Telefono);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@tel", DBNull.Value);
                    }
                    if (cliente.Email != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@mail", cliente.Email);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@mail", DBNull.Value);
                    }

                    comando.Parameters.AddWithValue("@id", cliente.ClienteId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar editar un cliente"); 
                }

            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    string cadenaComando = "SELECT * FROM Clientes WHERE NombreCompania=@nomb";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", cliente.NombreCompania);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Clientes WHERE NombreCompania=@nomb AND ClienteId<>@clienteId";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", cliente.NombreCompania);
                    comando.Parameters.AddWithValue("@clienteId", cliente.ClienteId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int clienteId)
        {
            try
            {
                string cadenaComando = "DELETE FROM Clientes WHERE ClienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", clienteId);
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
        public ClienteEditDto GetClientePorId(int clienteId)
        {
            ClienteEditDto cliente = null;
            try
            {
                string cadenaComando =
                    "SELECT ClienteId, NombreCompania, Direccion, CodPostal," +
                    " PaisId, CiudadId, Telefono, Email FROM Clientes WHERE ClienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", clienteId);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    cliente = ConstruirClienteEditDto(reader);
                }
                reader.Close();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer el cliente");
            }

        }

        private ClienteEditDto ConstruirClienteEditDto(SqlDataReader reader)
        {
            var paisEditDto = _repositorioPaises.GetPaisPorId(reader.GetInt32(4));
            var ciudadEditDto = _repositorioCiudades.GetCiudadPorId(reader.GetInt32(5));
            return new ClienteEditDto
            {
                ClienteId = reader.GetInt32(0),
                NombreCompania = reader.GetString(1),
                Direccion = reader[2] != DBNull.Value ? reader.GetString(2) : string.Empty,
                CodPostal = reader[3] != DBNull.Value ? reader.GetString(3) : string.Empty,
                Pais = new PaisListDto {PaisId = paisEditDto.PaisId, NombrePais = paisEditDto.NombrePais},
                Ciudad = new CiudadListDto
                {
                    CiudadId = ciudadEditDto.CiudadId,
                    NombreCiudad = ciudadEditDto.NombreCiudad,
                    NombrePais = ciudadEditDto.Pais.NombrePais
                },
                Telefono = reader[6] != DBNull.Value ? reader.GetString(6) : string.Empty,
                Email = reader[7] != DBNull.Value ? reader.GetString(7) : string.Empty,
            };
        }

        private ClienteListDto ConstruirClienteListDto(SqlDataReader reader)
        {
            return new ClienteListDto
            {
                ClienteId = reader.GetInt32(0),
                NombreCompania = reader.GetString(1),
                Pais = reader.GetString(2),
                Ciudad = reader.GetString(3)
            };
        }
    }
}
