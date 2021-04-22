using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.DTOs.Producto;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL.Repositorios.Facades;

namespace Neptuno2021.DL.Repositorios
{
    public class RepositorioProductos:IRepositorioProductos
    {
        private readonly SqlConnection _sqlConnection;
        private SqlTransaction _tran;

        public RepositorioProductos(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public RepositorioProductos(SqlConnection sqlConnection, SqlTransaction tran) : this(sqlConnection)
        {
            this._tran = tran;
        }

        public List<ProductoListDto> GetLista(int? categoriaId)
        {
            List<ProductoListDto> lista=new List<ProductoListDto>();
            try
            {
                string cadenaComando;
                SqlCommand comando;
                if (categoriaId==null)
                {
                     cadenaComando =
                        "SELECT ProductoId, NombreProducto, NombreCategoria, PrecioUnitario, UnidadesEnExistencia, Suspendido FROM Productos " +
                        "INNER JOIN Categorias ON Productos.CategoriaId=Categorias.CategoriaId";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    
                }
                else
                {
                 cadenaComando =
                    "SELECT ProductoId, NombreProducto, NombreCategoria, PrecioUnitario, UnidadesEnExistencia, Suspendido FROM Productos " +
                    "INNER JOIN Categorias ON Productos.CategoriaId=Categorias.CategoriaId WHERE Productos.CategoriaId=@id";
                 comando = new SqlCommand(cadenaComando, _sqlConnection);
                 comando.Parameters.AddWithValue("@id", categoriaId);

                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var productoListDto = ConstruirProductoListDto(reader);
                    lista.Add(productoListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los productos");
            }
        }

        private ProductoListDto ConstruirProductoListDto(SqlDataReader reader)
        {
            return new ProductoListDto
            {
                ProductoId = reader.GetInt32(0),
                NombreProducto = reader.GetString(1),
                Categoria = reader.GetString(2),
                PrecioUnitario = reader.GetDecimal(3),
                UnidadesEnExistencia = reader.GetDouble(4),
                Suspendido = reader.GetBoolean(5)
            };
        }

        public ProductoEditDto GetProductoPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public void Borrar(int categoriaId)
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public bool EstaRelacionado(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public void ActualizarStock(Producto producto, double cantidad)
        {
            try
            {
                string cadenaComando = "UPDATE Productos SET UnidadesEnExistencia=UnidadesEnExistencia-@cant WHERE ProductoId=@id";
                var comando = new SqlCommand(cadenaComando, _sqlConnection, _tran);
                comando.Parameters.AddWithValue("@cant", cantidad);
                comando.Parameters.AddWithValue("@id", producto.ProductoId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al actualizar el stock de un producto");
            }
        }
    }
}
