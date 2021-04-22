using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Windows
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private IServiciosCategorias _servicio;
        private List<CategoriaListDto> _lista;
        private void FrmCatagorias_Load(object sender, EventArgs e)
        {
            _servicio=new ServiciosCategorias();
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
            foreach (var categoria in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, categoria);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, CategoriaListDto categoriaDto)
        {
            r.Cells[cmnNombre.Index].Value = categoriaDto.NombreCategoria;

            r.Tag = categoriaDto;
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
            FrmCategoriasAE frm = new FrmCategoriasAE();
            frm.Text = "Agregar Categoría";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    CategoriaEditDto categoriaEditDto = frm.GetCategoria();
                    //Controlar repitencia

                    if (!_servicio.Existe(categoriaEditDto))
                    {
                        _servicio.Guardar(categoriaEditDto);
                        CategoriaListDto categoriaListDto = new CategoriaListDto
                        {
                            CategoriaId = categoriaEditDto.CategoriaId,
                            NombreCategoria = categoriaEditDto.NombreCategoria,
                        };
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, categoriaListDto);
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
            CategoriaListDto categoriaListDto = (CategoriaListDto)r.Tag;
            DialogResult dr =
                MessageBox
                    .Show($@"¿Desea borrar el registro seleccionado de la categoría {categoriaListDto.NombreCategoria}?",
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
                _servicio.Borrar(categoriaListDto.CategoriaId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            CategoriaListDto categoriaDto = (CategoriaListDto)r.Tag;
            CategoriaListDto categoriaDtoAux = categoriaDto.Clone() as CategoriaListDto;
            FrmCategoriasAE frm = new FrmCategoriasAE();
            CategoriaEditDto categoriaEditDto = _servicio.GetCategoriaPorId(categoriaDto.CategoriaId);
            frm.Text = "Editar Categoría";
            frm.SetCategoria(categoriaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                categoriaEditDto = frm.GetCategoria();
                //Controlar repitencia

                if (!_servicio.Existe(categoriaEditDto))
                {
                    _servicio.Guardar(categoriaEditDto);
                    categoriaDto = new CategoriaListDto
                    {
                        CategoriaId = categoriaEditDto.CategoriaId,
                        NombreCategoria = categoriaEditDto.NombreCategoria,
                    };
                    SetearFila(r, categoriaDto);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, categoriaDto);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, categoriaDtoAux);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
