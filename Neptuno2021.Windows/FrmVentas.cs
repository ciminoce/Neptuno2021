using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Venta;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;

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
            try
            {
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
                var listaDetalle = _servicio.GetDetalle(ventaDto.VentaId);
                FrmVerDetallePedido frm = new FrmVerDetallePedido();
                frm.Text = $"Detalles del Pedido {ventaDto.VentaId}";
                frm.SetDetalle(listaDetalle);
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
                        FechaVenta = ventaDto.FechaVenta
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
    }
}
