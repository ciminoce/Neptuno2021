using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL.Repositorios.Facades;

namespace Neptuno2021.DL.Repositorios
{
    public class RepositorioCategorias:IRepositorioCategorias
    {
        private SqlConnection _sqlConnection;

        public RepositorioCategorias(SqlConnection connection)
        {
            _sqlConnection = connection;
        }
        public List<CategoriaListDto> GetLista()
        {
            List<CategoriaListDto> lista = new List<CategoriaListDto>();
            try
            {
                string cadenaComando = "SELECT CategoriaId, NombreCategoria FROM Categorias";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CategoriaListDto categoriaDto = ConstruirCategoriaListDto(reader);
                    lista.Add(categoriaDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las categorías");
            }

        }

        private CategoriaListDto ConstruirCategoriaListDto(SqlDataReader reader)
        {
            return new CategoriaListDto
            {
                CategoriaId = reader.GetInt32(0),
                NombreCategoria = reader.GetString(1)
            };
        }

        public CategoriaEditDto GetCategoriaPorId(int id)
        {
            CategoriaEditDto categoriaDto = null;
            try
            {
                string cadenaComando =
                    "SELECT CategoriaId, NombreCategoria, Descripcion FROM Categorias WHERE CategoriaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    categoriaDto = ConstruirCategoriaEditDto(reader);
                }
                reader.Close();
                return categoriaDto;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer la categoría");
            }
        }

        private CategoriaEditDto ConstruirCategoriaEditDto(SqlDataReader reader)
        {
            return new CategoriaEditDto
            {
                CategoriaId = reader.GetInt32(0),
                NombreCategoria = reader.GetString(1),
                Descripcion = reader.GetString(2)
            };
        }

        public void Guardar(Categoria categoria)
        {
            if (categoria.CategoriaId == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Categorias VALUES(@nombre, @desc)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", categoria.NombreCategoria);
                    comando.Parameters.AddWithValue("@desc", categoria.Descripcion);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    categoria.CategoriaId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar guardar una categoría");
                }

            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Categorias SET NombreCategoria=@nombre, descripcion=@desc WHERE CategoriaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", categoria.NombreCategoria);
                    comando.Parameters.AddWithValue("@desc", categoria.Descripcion);

                    comando.Parameters.AddWithValue("@id", categoria.CategoriaId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar editar una categoría");
                }

            }
        }

        public void Borrar(int categoriaId)
        {
            try
            {
                string cadenaComando = "DELETE FROM Categorias WHERE CategoriaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", categoriaId);
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

        public bool Existe(Categoria categoria)
        {
            try
            {
                if (categoria.CategoriaId == 0)
                {
                    string cadenaComando = "SELECT * FROM Categorias WHERE NombreCategoria=@nomb";
                        
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", categoria.NombreCategoria);
                    comando.Parameters.AddWithValue("@id", categoria.CategoriaId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Categorias WHERE NombreCategoria=@nomb AND CategoriaId!=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", categoria.NombreCategoria);
                    comando.Parameters.AddWithValue("@id", categoria.CategoriaId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Categoria categoria)
        {
            //TODO Ver este método
            throw new System.NotImplementedException();
        }
    }
}
