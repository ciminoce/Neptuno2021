using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.DTOs.Proveedor;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Windows
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServicioProveedores _servicio;
        private List<ProveedorListDto> _lista;
        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioProveedores();
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
            foreach (var proveedorListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, proveedorListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, ProveedorListDto proveedorListDto)
        {
            r.Cells[cmnCompania.Index].Value = proveedorListDto.NombreCompania;
            r.Cells[cmnPais.Index].Value = proveedorListDto.Pais;
            r.Cells[cmnCiudad.Index].Value = proveedorListDto.Ciudad;

            r.Tag = proveedorListDto;
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
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProveedoresAE frm = new FrmProveedoresAE();
            frm.Text = "Agregar Proveedor";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {

                ProveedorEditDto proveedorEditDto = frm.GetProveedor();
                //Controlar repetido
                if (_servicio.Existe(proveedorEditDto))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _servicio.Guardar(proveedorEditDto);
                DataGridViewRow r = ConstruirFila();
                ProveedorListDto proveedorListDto = new ProveedorListDto
                {
                    ProveedorId = proveedorEditDto.ProveedorId,
                    NombreCompania = proveedorEditDto.NombreCompania,
                    Pais = proveedorEditDto.Pais.NombrePais,
                    Ciudad = proveedorEditDto.Ciudad.NombreCiudad
                };
                SetearFila(r, proveedorListDto);
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
            ProveedorListDto proveedorListDto = (ProveedorListDto)r.Tag;
            ProveedorListDto proveedorListDtoAux = (ProveedorListDto)proveedorListDto.Clone();
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al proveedor {proveedorListDto.NombreCompania}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(proveedorListDto.ProveedorId);
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
            ProveedorListDto proveedorListDto = (ProveedorListDto)r.Tag;
            ProveedorListDto proveedorListDtoAuxiliar = (ProveedorListDto)proveedorListDto.Clone();
            FrmProveedoresAE frm = new FrmProveedoresAE();
            ProveedorEditDto proveedorEditDto = _servicio.GetProveedorPorId(proveedorListDto.ProveedorId);
            frm.Text = "Editar Proveedor";
            frm.SetProveedor(proveedorEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                proveedorEditDto = frm.GetProveedor();
                //Controlar repitencia

                if (!_servicio.Existe(proveedorEditDto))
                {
                    _servicio.Guardar(proveedorEditDto);
                    proveedorListDto.ProveedorId = proveedorEditDto.ProveedorId;
                    proveedorListDto.NombreCompania = proveedorEditDto.NombreCompania;
                    proveedorListDto.Pais = proveedorEditDto.Pais.NombrePais;
                    proveedorListDto.Ciudad = proveedorEditDto.Ciudad.NombreCiudad;

                    SetearFila(r, proveedorListDto);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, proveedorListDtoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, proveedorListDtoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
