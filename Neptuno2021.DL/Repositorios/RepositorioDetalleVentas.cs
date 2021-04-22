using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.DTOs.DetalleVenta;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL.Repositorios.Facades;

namespace Neptuno2021.DL.Repositorios
{
    public class RepositorioDetalleVentas:IRepositorioDetalleVentas
    {
        private readonly SqlConnection _sqlConnection;
        private SqlTransaction _tran;

        public RepositorioDetalleVentas(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public RepositorioDetalleVentas(SqlConnection sqlConnection, SqlTransaction tran) : this(sqlConnection)
        {
            this._tran = tran;
        }

        public List<DetalleVentaListDto> GetLista(int ventaId)
        {
            List<DetalleVentaListDto> lista = new List<DetalleVentaListDto>();
            try
            {
                string cadenaComando =
                    "SELECT DetallePedidoId, NombreProducto, DetallesPedidos.PrecioUnitario, Cantidad FROM DetallesPedidos " +
                    "INNER JOIN Productos ON Productos.ProductoId=DetallesPedidos.ProductoId " +
                    "WHERE PedidoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", ventaId);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var detalleListDto = ConstruirDetalleListDto(reader);
                    lista.Add(detalleListDto);
                }
                reader.Close();
                return lista;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private DetalleVentaListDto ConstruirDetalleListDto(SqlDataReader reader)
        {
            return new DetalleVentaListDto()
            {
                DetalleVentaId = reader.GetInt32(0),
                Producto = reader.GetString(1),
                PrecioUnitario = reader.GetDecimal(2),
                Cantidad = reader.GetDouble(3)
            };
        }

        public void Guardar(DetalleVenta detalle)
        {
            try
            {
                string cadenaComando = "INSERT INTO DetallesPedidos (ProductoId, PrecioUnitario, Cantidad, PedidoId) " +
                                       "VALUES (@prod, @pUnit, @cant, @ped)";
                var comando = new SqlCommand(cadenaComando, _sqlConnection, _tran);
                comando.Parameters.AddWithValue("@prod", detalle.Producto.ProductoId);
                comando.Parameters.AddWithValue("@pUnit", detalle.Precio);
                comando.Parameters.AddWithValue("@cant", detalle.Cantidad);
                comando.Parameters.AddWithValue("@ped", detalle.Venta.VentaId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al intentar guardar un detalle de venta");
            }

        }
    }
}
