using System;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.DTOs.Producto;
using Neptuno2021.BL.DTOs.Proveedor;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmProductosAE : Form
    {
        public FrmProductosAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboCategorias(ref CategoriaComboBox);
            Helper.CargarDatosComboProveedores(ref ProveedorComboBox);


        }

        public void SetProducto(ProductoEditDto productoEditDto)
        {
            this.productoDto = productoEditDto;
        }

        private ProductoEditDto productoDto;
        public ProductoEditDto GetProducto()
        {
            return productoDto;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (productoDto == null)
                {
                    productoDto = new ProductoEditDto();
                }

                productoDto.NombreProducto = ProductoTextBox.Text;
                productoDto.CategoriaDto =(CategoriaListDto) CategoriaComboBox.SelectedItem;
                productoDto.ProveedorDto = (ProveedorListDto) ProveedorComboBox.SelectedItem;
                productoDto.PrecioUnitario = decimal.Parse(PrecioTextBox.Text);
                productoDto.UnidadesEnExistencia = double.Parse(StockTextBox.Text);
                productoDto.UnidadesEnPedido = double.Parse(EnPedidoTextBox.Text);
                productoDto.Suspendido = SuspendidoCheckBox.Checked;
                

                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(ProductoTextBox.Text)
                || string.IsNullOrWhiteSpace(ProductoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ProductoTextBox, "El nombre es requerido");
            }

            if (CategoriaComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CategoriaComboBox, "Debe seleccionar una categoría");
            }

            if (ProveedorComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProveedorComboBox, "Debe seleccionar un proveedor");
            }

            if (!double.TryParse(StockTextBox.Text, out double stock))
            {
                valido = false;
                errorProvider1.SetError(StockTextBox,"Stock mal ingresado");
            }else if (stock<0 || stock>int.MaxValue)
            {
                valido = false;
                errorProvider1.SetError(StockTextBox,"Stock fuera del rango permitido");
            }
            if (!double.TryParse(EnPedidoTextBox.Text, out double enPedido))
            {
                valido = false;
                errorProvider1.SetError(EnPedidoTextBox, "Unidades en Pedido mal ingresado");
            }
            else if (enPedido < 0 || enPedido > int.MaxValue)
            {
                valido = false;
                errorProvider1.SetError(EnPedidoTextBox, "Unidades en Pedido fuera del rango permitido");
            }

            return valido;
        }
    }
}
