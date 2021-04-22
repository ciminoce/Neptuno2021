using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Windows
{
    public partial class FrmCiudades : Form
    {
        public FrmCiudades()
        {
            InitializeComponent();
        }

        private IServicioCiudades _servicio;
        private List<CiudadListDto> lista;
        private void FrmCiudades_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioCiudades();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                lista = _servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var ciudadListDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ciudadListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, CiudadListDto ciudadListDto)
        {
            r.Cells[cmnCiudad.Index].Value = ciudadListDto.NombreCiudad;
            r.Cells[cmnPais.Index].Value = ciudadListDto.NombrePais;

            r.Tag = ciudadListDto;
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
            FrmCiudadesAE frm = new FrmCiudadesAE();
            frm.Text = "Agregar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    CiudadEditDto ciudadEditDto = frm.GetCiudad();
                    //Controlar repitencia

                    if (!_servicio.Existe(ciudadEditDto))
                    {
                        _servicio.Guardar(ciudadEditDto);
                        CiudadListDto ciudadListDto = new CiudadListDto();

                        ciudadListDto.CiudadId = ciudadEditDto.CiudadId;
                        ciudadListDto.NombreCiudad = ciudadEditDto.NombreCiudad;
                        ciudadListDto.NombrePais = ciudadEditDto.Pais.NombrePais;
                        

                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, ciudadListDto);
                        AgregarFila(r);
                        MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            CiudadListDto ciudadDto = (CiudadListDto)r.Tag;
            DialogResult dr =
                MessageBox
                    .Show($@"¿Desea borrar el registro seleccionado de la ciudad {ciudadDto.NombreCiudad}?",
                        "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2
                    );
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                //Controlar relaciones 
                _servicio.Borrar(ciudadDto.CiudadId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            CiudadListDto ciudadListDto = (CiudadListDto)r.Tag;
            CiudadListDto ciudadListDtoAuxiliar = ciudadListDto.Clone() as CiudadListDto;
            FrmCiudadesAE frm = new FrmCiudadesAE();
            CiudadEditDto ciudadEditDto = _servicio.GetCiudadPorId(ciudadListDto.CiudadId);
            frm.Text = "Editar Ciudad";
            frm.SetCiudad(ciudadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                ciudadEditDto = frm.GetCiudad();
                //Controlar repitencia

                if (!_servicio.Existe(ciudadEditDto))
                {
                    _servicio.Guardar(ciudadEditDto);
                    ciudadListDto.CiudadId = ciudadEditDto.CiudadId;
                    ciudadListDto.NombreCiudad = ciudadEditDto.NombreCiudad;
                    ciudadListDto.NombrePais = ciudadEditDto.Pais.NombrePais;
               
                    SetearFila(r, ciudadListDto);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, ciudadListDtoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, ciudadListDtoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCiudades frm = new FrmBuscarCiudades();
            frm.Text = "Seleccionar País";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            try
            {
                PaisListDto paisDto = frm.GetPais();
                lista = _servicio.GetLista(paisDto);
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}

