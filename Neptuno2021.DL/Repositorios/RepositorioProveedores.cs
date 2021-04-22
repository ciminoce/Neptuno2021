using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.DTOs.Proveedor;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL.Repositorios.Facades;

namespace Neptuno2021.DL.Repositorios
{
    public class RepositorioProveedores:IRepositorioProveedores
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IRepositorioPaises _repositorioPaises;
        private readonly IRepositorioCiudades _repositorioCiudades;

        public RepositorioProveedores(SqlConnection sqlConnection, IRepositorioPaises repositorioPaises, IRepositorioCiudades repositorioCiudades)
        {
            _sqlConnection = sqlConnection;
            _repositorioPaises = repositorioPaises;
            _repositorioCiudades = repositorioCiudades;
        }
        public RepositorioProveedores(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<ProveedorListDto> GetLista()
        {
            List<ProveedorListDto> lista = new List<ProveedorListDto>();
            try
            {
                string cadenaComando =
                    "SELECT ProveedorId, NombreCompania, NombrePais, NombreCiudad FROM Proveedores " +
                    "INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId " +
                    "INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var proveedorListDto = ConstruirProveedorListDto(reader);
                    lista.Add(proveedorListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los proveedores");
            }

        }

        private ProveedorListDto ConstruirProveedorListDto(SqlDataReader reader)
        {
            return new ProveedorListDto
            {
                ProveedorId = reader.GetInt32(0),
                NombreCompania = reader.GetString(1),
                Pais = reader.GetString(2),
                Ciudad = reader.GetString(3)
            };
        }

        public void Guardar(Proveedor proveedor)
        {
            if (proveedor.ProveedorId == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Proveedores VALUES(@nombre, @dir, @cp, @paisId, @ciudadId, @tel, @mail)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", proveedor.NombreCompania);
                    if (proveedor.Direccion != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@dir", proveedor.Direccion);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@dir", DBNull.Value);
                    }
                    if (proveedor.CodPostal != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@cp", proveedor.CodPostal);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@cp", DBNull.Value);
                    }

                    comando.Parameters.AddWithValue("@paisId", proveedor.Pais.PaisId);
                    comando.Parameters.AddWithValue("@ciudadId", proveedor.Ciudad.CiudadId);
                    if (proveedor.Telefono != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@tel", proveedor.Telefono);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@tel", DBNull.Value);
                    }
                    if (proveedor.Email != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@mail", proveedor.Email);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@mail", DBNull.Value);
                    }


                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    proveedor.ProveedorId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar guardar un proveedor");
                }

            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Proveedores SET NombreCompania=@nombre, Direccion=@dir, CodPostal=@cp," +
                                           " PaisId=@paisId, CiudadId=@ciudadId, Telefono=@tel, Email=@mail WHERE ProveedorId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", proveedor.NombreCompania);
                    if (proveedor.Direccion != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@dir", proveedor.Direccion);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@dir", DBNull.Value);
                    }
                    if (proveedor.CodPostal != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@cp", proveedor.CodPostal);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@cp", DBNull.Value);
                    }

                    comando.Parameters.AddWithValue("@paisId", proveedor.Pais.PaisId);
                    comando.Parameters.AddWithValue("@ciudadId", proveedor.Ciudad.CiudadId);
                    if (proveedor.Telefono != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@tel", proveedor.Telefono);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@tel", DBNull.Value);
                    }
                    if (proveedor.Email != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@mail", proveedor.Email);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@mail", DBNull.Value);
                    }

                    comando.Parameters.AddWithValue("@id", proveedor.ProveedorId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar editar un proveedor");
                }

            }
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                if (proveedor.ProveedorId == 0)
                {
                    string cadenaComando = "SELECT * FROM Proveedores WHERE NombreCompania=@nomb";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", proveedor.NombreCompania);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Proveedores WHERE NombreCompania=@nomb AND ProveedorId<>@proveedorId";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", proveedor.NombreCompania);
                    comando.Parameters.AddWithValue("@proveedorId", proveedor.ProveedorId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int proveedorId)
        {
            try
            {
                string cadenaComando = "DELETE FROM Proveedores WHERE ProveedorId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", proveedorId);
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
        public ProveedorEditDto GetProveedorPorId(int clienteId)
        {
            ProveedorEditDto cliente = null;
            try
            {
                string cadenaComando =
                    "SELECT ProveedorId, NombreCompania, Direccion, CodPostal," +
                    " PaisId, CiudadId, Telefono, Email FROM Proveedores WHERE ProveedorId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", clienteId);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    cliente = ConstruirProveedorEditDto(reader);
                }
                reader.Close();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer el proveedor");
            }

        }

        private ProveedorEditDto ConstruirProveedorEditDto(SqlDataReader reader)
        {
            var paisEditDto = _repositorioPaises.GetPaisPorId(reader.GetInt32(4));
            var ciudadEditDto = _repositorioCiudades.GetCiudadPorId(reader.GetInt32(5));
            return new ProveedorEditDto()
            {
                ProveedorId = reader.GetInt32(0),
                NombreCompania = reader.GetString(1),
                Direccion = reader[2] != DBNull.Value ? reader.GetString(2) : string.Empty,
                CodPostal = reader[3] != DBNull.Value ? reader.GetString(3) : string.Empty,
                Pais = new PaisListDto { PaisId = paisEditDto.PaisId, NombrePais = paisEditDto.NombrePais },
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


    }
}
