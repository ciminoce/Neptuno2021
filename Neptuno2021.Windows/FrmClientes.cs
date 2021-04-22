using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Windows
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private IServicioClientes _servicio;
        private List<ClienteListDto> _lista;

        private void FrmClientes_Load(object sender, EventArgs e)
        {
                 _servicio = new ServicioClientes();
           try
            {
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var clienteListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, clienteListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, ClienteListDto clienteListDto)
        {
            r.Cells[cmnCompania.Index].Value = clienteListDto.NombreCompania;
            r.Cells[cmnPais.Index].Value = clienteListDto.Pais;
            r.Cells[cmnCiudad.Index].Value = clienteListDto.Ciudad;

            r.Tag = clienteListDto;
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

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmClientesAE frm = new FrmClientesAE();
            frm.Text = "Agregar Cliente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {

                ClienteEditDto clienteEditDto = frm.GetCliente();
                //Controlar repetido
                if (_servicio.Existe(clienteEditDto))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _servicio.Guardar(clienteEditDto);
                DataGridViewRow r = ConstruirFila();
                ClienteListDto clienteListDto = new ClienteListDto
                {
                    ClienteId = clienteEditDto.ClienteId,
                    NombreCompania = clienteEditDto.NombreCompania,
                    Pais = clienteEditDto.Pais.NombrePais,
                    Ciudad = clienteEditDto.Ciudad.NombreCiudad
                };
                SetearFila(r, clienteListDto);
                AgregarFila(r);
                MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            ClienteListDto clienteListDto = (ClienteListDto) r.Tag;
            ClienteListDto clienteListDtoAux = (ClienteListDto) clienteListDto.Clone();
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al cliente {clienteListDto.NombreCompania}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(clienteListDto.ClienteId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            ClienteListDto clienteListDto = (ClienteListDto)r.Tag;
            ClienteListDto clienteListDtoAuxiliar =(ClienteListDto) clienteListDto.Clone();
            FrmClientesAE frm = new FrmClientesAE();
            ClienteEditDto clienteEditDto = _servicio.GetClientePorId(clienteListDto.ClienteId);
            frm.Text = "Editar Cliente";
            frm.SetCliente(clienteEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                clienteEditDto = frm.GetCliente();
                //Controlar repitencia

                if (!_servicio.Existe(clienteEditDto))
                {
                    _servicio.Guardar(clienteEditDto);
                    clienteListDto.ClienteId = clienteEditDto.ClienteId;
                    clienteListDto.NombreCompania = clienteEditDto.NombreCompania;
                    clienteListDto.Pais = clienteEditDto.Pais.NombrePais;
                    clienteListDto.Ciudad = clienteEditDto.Ciudad.NombreCiudad;

                    SetearFila(r, clienteListDto);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, clienteListDtoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, clienteListDtoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
