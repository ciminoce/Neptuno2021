using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.DetalleVenta;

namespace Neptuno2021.Windows
{
    public partial class FrmVerDetallePedido : Form
    {
        public FrmVerDetallePedido()
        {
            InitializeComponent();
        }

        private List<DetalleVentaListDto> _lista;
        public void SetDetalle(List<DetalleVentaListDto> listaDetalle)
        {
            _lista=listaDetalle;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgPedido.Rows.Clear();
            MostrarDatosEnGrilla();
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            /*  Utilizando Linq obtengo el total
             de la venta sumando el producto de las cantidades 
            por el precio de cada producto*/
            txtTotalPedido.Text = _lista.Sum(i => i.PrecioUnitario *(decimal) i.Cantidad).ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            dgPedido.Rows.Clear();
            foreach (var detalleVentaListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, detalleVentaListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, DetalleVentaListDto detalleVentaListDto)
        {
            r.Cells[cmnProducto.Index].Value = detalleVentaListDto.Producto;
            r.Cells[cmnPrecioUnitario.Index].Value = detalleVentaListDto.PrecioUnitario;
            r.Cells[cmnCantidad.Index].Value = detalleVentaListDto.Cantidad;
            r.Cells[cmnTotal.Index].Value = detalleVentaListDto.Total;

            r.Tag = detalleVentaListDto;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgPedido.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgPedido);
            return r;
        }
    }
}
