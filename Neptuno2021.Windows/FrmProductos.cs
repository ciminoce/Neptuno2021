using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Producto;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Windows
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private IServicioProductos _servicio;
        private List<ProductoListDto> _lista;
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioProductos();
            try
            {
                _lista = _servicio.GetLista(null);
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
            foreach (var productoListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, productoListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, ProductoListDto productoListDto)
        {
            r.Cells[cmnProducto.Index].Value = productoListDto.NombreProducto;
            r.Cells[cmnCategoria.Index].Value = productoListDto.Categoria;
            r.Cells[cmnPrecio.Index].Value = productoListDto.PrecioUnitario;
            r.Cells[cmnStock.Index].Value = productoListDto.UnidadesEnExistencia;
            r.Cells[cmnSuspendido.Index].Value = productoListDto.Suspendido;

            r.Tag = productoListDto;
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
            FrmProductosAE frm = new FrmProductosAE();
            frm.Text = "Agregar Producto";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {

                ProductoEditDto productoEditDto = frm.GetProducto();
                //Controlar repetido
                if (_servicio.Existe(productoEditDto))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _servicio.Guardar(productoEditDto);
                DataGridViewRow r = ConstruirFila();
                ProductoListDto productoListDto = new ProductoListDto
                {
                    ProductoId = productoEditDto.ProductoId,
                    NombreProducto = productoEditDto.NombreProducto,
                    Categoria = productoEditDto.CategoriaDto.NombreCategoria,
                    PrecioUnitario = productoEditDto.PrecioUnitario,
                    UnidadesEnExistencia = productoEditDto.UnidadesEnExistencia,
                    Suspendido = productoEditDto.Suspendido
                };
                SetearFila(r, productoListDto);
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
            ProductoListDto productoListDto = (ProductoListDto)r.Tag;
            ProductoListDto clienteListDtoAux = (ProductoListDto)productoListDto.Clone();
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el producto {productoListDto.NombreProducto}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(productoListDto.ProductoId);
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
            ProductoListDto productoListDto = (ProductoListDto)r.Tag;
            ProductoListDto productoListDtoAuxiliar = (ProductoListDto)productoListDto.Clone();
            FrmProductosAE frm = new FrmProductosAE();
            ProductoEditDto productoEditDto = _servicio.GetProductoPorId(productoListDto.ProductoId);
            frm.Text = "Editar Cliente";
            frm.SetProducto(productoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                productoEditDto = frm.GetProducto();
                //Controlar repitencia

                if (!_servicio.Existe(productoEditDto))
                {
                    _servicio.Guardar(productoEditDto);
                    productoListDto.ProductoId = productoEditDto.ProductoId;
                    productoListDto.NombreProducto = productoEditDto.NombreProducto;
                    productoListDto.Categoria = productoEditDto.CategoriaDto.NombreCategoria;
                    productoListDto.UnidadesEnExistencia = productoEditDto.UnidadesEnExistencia;
                    productoEditDto.PrecioUnitario = productoEditDto.PrecioUnitario;
                    productoEditDto.Suspendido = productoEditDto.Suspendido;

                    SetearFila(r, productoListDto);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, productoListDtoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, productoListDtoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
