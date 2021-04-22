using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno2021.BL.DTOs.DetalleVenta;
using Neptuno2021.BL.DTOs.Venta;
using Neptuno2021.BL.Entidades;
using Neptuno2021.DL;
using Neptuno2021.DL.Repositorios;
using Neptuno2021.DL.Repositorios.Facades;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Servicios.Servicios
{
    public class ServicioVentas:IServicioVentas
    {
        private ConexionBd _conexionBd;
        private IRepositorioVentas _repositorio;
        private IRepositorioDetalleVentas _repositorioDetalle;
        private IRepositorioProductos _repositorioProductos;

        public List<VentaListDto> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioVentas(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Guardar(VentaEditDto ventaDto)
        {
            #region Pasar de Dto a Entidad

            var listaDetalles = new List<DetalleVenta>();
            foreach (var itemDto in ventaDto.DetalleVentas)
            {
                var item = new DetalleVenta()
                {
                    DetalleVentaId = itemDto.DetalleVentaId,
                    Producto = new Producto
                    {
                        ProductoId = itemDto.Producto.ProductoId,
                        NombreProducto = itemDto.Producto.NombreProducto
                    },
                    Cantidad = itemDto.Cantidad,
                    Precio = itemDto.Precio
                };
                listaDetalles.Add(item);
            }

            var venta = new Venta
            {
                VentaId = ventaDto.VentaId,
                Cliente = new Cliente
                {
                    ClienteId = ventaDto.Cliente.ClienteId,
                    NombreCompania = ventaDto.Cliente.NombreCompania
                },
                FechaVenta = ventaDto.FechaVenta,
                DetalleVentas = listaDetalles

            };


            #endregion

            #region Guardar la Venta

            _conexionBd = new ConexionBd();
            SqlTransaction tran = null;
            try
            {
                SqlConnection cn = _conexionBd.AbrirConexion();
                tran = cn.BeginTransaction();//Comienza la transacción
                _repositorio = new RepositorioVentas(cn, tran);
                _repositorioProductos = new RepositorioProductos(cn, tran);
                _repositorioDetalle = new RepositorioDetalleVentas(cn, tran);

                _repositorio.Guardar(venta);
                #region Recorrer los detalles de la venta

                foreach (var detalleVenta in venta.DetalleVentas)
                {
                    detalleVenta.Venta = venta;
                    _repositorioDetalle.Guardar(detalleVenta);
                    _repositorioProductos.ActualizarStock(detalleVenta.Producto,
                        -detalleVenta.Cantidad);

                }
                #endregion
                tran.Commit();//Confirma la persistencia de los datos
                ventaDto.VentaId = venta.VentaId;
            }
            catch (Exception e)
            {
                tran.Rollback();//Tira para atrás toda la transacción si no se completa
                throw new Exception(e.Message);
            }
            

            #endregion
        }

        public VentaEditDto GetVentaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<DetalleVentaListDto> GetDetalle(int ventaDtoVentaId)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioDetalle = new RepositorioDetalleVentas(_conexionBd.AbrirConexion());
                var lista = _repositorioDetalle.GetLista(ventaDtoVentaId);
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
