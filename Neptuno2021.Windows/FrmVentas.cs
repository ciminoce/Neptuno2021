using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Venta;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        private IServicioVentas _servicio;
        private List<VentaListDto> _lista;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioVentas();
            InicializarGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var ventaListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ventaListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, VentaListDto ventaListDto)
        {
            r.Cells[cmnNroVenta.Index].Value = ventaListDto.VentaId;
            r.Cells[cmnCliente.Index].Value = ventaListDto.Cliente;
            r.Cells[cmnFechaVenta.Index].Value = ventaListDto.FechaVenta.ToShortDateString();
            r.Cells[cmnTotal.Index].Value = ventaListDto.TotalVenta.ToString("C");

            r.Tag = ventaListDto;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;
            }

            try
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                var ventaDto = (VentaListDto) r.Tag;
                //var listaDetalle = _servicio.GetDetalle(ventaDto.VentaId);
                FrmVerDetallePedido frm = new FrmVerDetallePedido();
                frm.Text = $"Detalles del Pedido {ventaDto.VentaId}";
                frm.SetDetalle(ventaDto.ItemsVenta);
                frm.ShowDialog(this);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmVentasAE frm = new FrmVentasAE();
            frm.Text = "Nueva Venta";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    var ventaDto = frm.GetVenta();
                    _servicio.Guardar(ventaDto);
                    var ventaListDto = new VentaListDto
                    {
                        VentaId = ventaDto.VentaId,
                        Cliente = ventaDto.Cliente.NombreCompania,
                        FechaVenta = ventaDto.FechaVenta,
                        ItemsVenta = Helper.ConstruirListaItemsListDto(ventaDto.DetalleVentas)
                        
                    };
                    var r = ConstruirFila();
                    SetearFila(r,ventaListDto);
                    AgregarFila(r);
                    MessageBox.Show("Venta agregada", "Mensaje", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarVentas frm = new FrmBuscarVentas();
            frm.Text = "Parámetros de búsqueda";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    var clienteDto = frm.GetCliente();
                    var fechaInicial = frm.GetFechaInicial();
                    var fechaFinal = frm.GetFechaFinal();
                    if (clienteDto!=null)
                    {
                        _lista = _servicio.GetLista(clienteDto.ClienteId, fechaInicial, fechaFinal);
                        
                    }
                    else
                    {
                        _lista = _servicio.GetLista(null, fechaInicial, fechaFinal);
                        
                    }
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            InicializarGrilla();
        }

        private void InicializarGrilla()
        {
            try
            {
                _lista = _servicio.GetLista(null, DateTime.Today.AddYears(-50), DateTime.Today);
                MostrarDatosEnGrilla();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
