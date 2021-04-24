using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.DTOs.Venta;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL.Repositorios.Facades;

namespace Neptuno2021.DL.Repositorios
{
    public class RepositorioVentas:IRepositorioVentas
    {
        private readonly SqlConnection _sqlConnection;
        private SqlTransaction tran;
        private readonly IRepositorioDetalleVentas _repositorioDetalles;

        public RepositorioVentas(SqlConnection sqlConnection, IRepositorioDetalleVentas repositorioDetalles)
        {
            _sqlConnection = sqlConnection;
            _repositorioDetalles = repositorioDetalles;
        }

        public RepositorioVentas(SqlConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;

        }

        public RepositorioVentas(SqlConnection sqlConnection, SqlTransaction tran) : this(sqlConnection)
        {
            this.tran = tran;
        }

        public List<VentaListDto> GetLista()
        {
            List<VentaListDto> lista = new List<VentaListDto>();
            try
            {
                string cadenaComando =
                    "SELECT PedidoId, NombreCompania, FechaPedido FROM Pedidos " +
                    "INNER JOIN Clientes ON Clientes.ClienteId=Pedidos.ClienteId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var ventaListDto = ConstruirVentaListDto(reader);
                    lista.Add(ventaListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las ventas");
            }

        }

        private VentaListDto ConstruirVentaListDto(SqlDataReader reader)
        {
            return new VentaListDto()
            {
                VentaId = reader.GetInt32(0),
                Cliente = reader.GetString(1),
                FechaVenta = reader.GetDateTime(2),
                ItemsVenta = _repositorioDetalles.GetLista(reader.GetInt32(0))
           };
        }

        public void Guardar(Venta venta)
        {
            try
            {
                string cadenaComando = "INSERT INTO Pedidos (ClienteId, FechaPedido) " +
                                       "VALUES (@clienteId, @fecha)";
                var comando = new SqlCommand(cadenaComando, _sqlConnection, tran);
                comando.Parameters.AddWithValue("@clienteId", venta.Cliente.ClienteId);
                comando.Parameters.AddWithValue("@fecha", venta.FechaVenta);

                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, _sqlConnection, tran);
                int id = (int)(decimal)comando.ExecuteScalar();
                venta.VentaId = id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public VentaEditDto GetVentaPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
