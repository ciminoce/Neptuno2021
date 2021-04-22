using System;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.DTOs.DetalleVenta;
using Neptuno2021.BL.DTOs.Producto;
using Neptuno2021.BL.DTOs.Venta;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmVentasAE : Form
    {
        public FrmVentasAE()
        {
            InitializeComponent();
        }
        

        private void FrmVentasAE_Load(object sender, EventArgs e)
        {
            Helper.CargarDatosComboClientes(ref ClientesComboBox);
            Helper.CargarDatosComboCategorias(ref CategoriaComboBox);
            carrito = new CarritoDto();
        }

        private void CategoriaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoriaComboBox.SelectedIndex>0)
            {
                var categoriaDto = (CategoriaListDto) CategoriaComboBox.SelectedItem;
                Helper.CargarDatosComboProductos(ref ProductoComboBox, categoriaDto.CategoriaId);
                ProductoComboBox.Enabled = true;
            }
            else
            {
                ProductoComboBox.DataSource = null;
                ProductoComboBox.Enabled = false;
            }
        }

        private ClienteListDto clienteListDto;
        private void ClientesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClientesComboBox.SelectedIndex>0)
            {
                clienteListDto = (ClienteListDto) ClientesComboBox.SelectedItem;
                //TODO:Habría que definir otro dto clienteDetalleDto y con un método del repo pasar todos los datos
                MostrarDatosCliente(clienteListDto);
            }
        }

        private void MostrarDatosCliente(ClienteListDto listDto)
        {
            PaisTextBox.Text = listDto.Pais;
            CiudadTextBox.Text = listDto.Ciudad;
            //TODO:Como hacer esto

        }

        private ProductoListDto productoDto;
        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductoComboBox.SelectedIndex>0)
            {
                productoDto = (ProductoListDto) ProductoComboBox.SelectedItem;
                MostrarDatosDelProducto(productoDto);
                CantidadUpDown.Enabled = true;
            }
            else
            {
                CantidadUpDown.Enabled = false;
            }
        }

        private void MostrarDatosDelProducto(ProductoListDto productoListDto)
        {
            PrecioUnitTextBox.Text = productoListDto.PrecioUnitario.ToString();
            StockTextBox.Text = productoListDto.UnidadesEnExistencia.ToString();
        }

        private void CantidadUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CantidadUpDown.Value>0)
            {
                PrecioTotalTextoBox.Text = ((decimal) CantidadUpDown.Value * productoDto.PrecioUnitario).ToString();
            }
            else
            {
                PrecioTotalTextoBox.Text = "0";
            }
        }

        private CarritoDto carrito;
        private DetalleVentaEditDto detalleVenta; 
        private void AceptarProductoButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatosProducto())
            {
                if (detalleVenta==null)
                {
                    detalleVenta = new DetalleVentaEditDto();
                }

                detalleVenta.Producto = productoDto;
                detalleVenta.Cantidad = (double) CantidadUpDown.Value;
                detalleVenta.Precio = decimal.Parse(PrecioTotalTextoBox.Text);

                carrito.AgregarAlCarrito(detalleVenta);
                MostrarDatosEnGrilla();
                MostrarTotalDeVenta();
                InicializarControlesItemVenta();
            }
        }

        private bool ValidarDatosProducto()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (CategoriaComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(ProductoComboBox,"Debe seleccionar una categoría");
            }
            if (ProductoComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(ProductoComboBox,"Debe seleccionar un producto");
            }

            if (CantidadUpDown.Value==0)
            {
                valido = false;
                errorProvider1.SetError(CantidadUpDown,"Debe llevar al menos un producto");
            }else if ((double)CantidadUpDown.Value>productoDto.UnidadesEnExistencia)
            {
                valido = false;
                errorProvider1.SetError(CantidadUpDown,"Cantidad superior al stock delproducto");

            }

            return valido;
        }

        private void MostrarTotalDeVenta()
        {
            TotalPedidoTextBox.Text = carrito.InformarTotal().ToString();
        }

        private void InicializarControlesItemVenta()
        {
            CategoriaComboBox.SelectedIndex = 0;
            ProductoComboBox.DataSource=null;
            StockTextBox.Clear();
            PrecioTotalTextoBox.Clear();
            PrecioUnitTextBox.Clear();
            CantidadUpDown.Value = 0;
            productoDto = null;
            detalleVenta = null;

        }

        private void MostrarDatosEnGrilla()
        {
            PedidoDataGridView.Rows.Clear();
            foreach (var item in carrito.GetItems())
            {
                var r = ConstruirFila();
                SetearFila(r, item);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, DetalleVentaEditDto item)
        {
            r.Cells[cmnProducto.Index].Value = item.Producto.NombreProducto;
            r.Cells[cmnCantidad.Index].Value = item.Cantidad;
            r.Cells[cmnPrecioUnitario.Index].Value = item.Precio;
            r.Cells[cmnTotal.Index].Value = item.Total;

            r.Tag = item;

        }

        private void AgregarFila(DataGridViewRow r)
        {
            PedidoDataGridView.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(PedidoDataGridView);
            return r;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (ClientesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(ClientesComboBox,"Debe seleccionar un cliente");
            }

            if (carrito.GetItems().Count==0)
            {
                valido = false;
                errorProvider1.SetError(PedidoDataGridView,"Debe tener al menos un item");
            }
            return valido;
        }

        private void CancelarProductoButton_Click(object sender, EventArgs e)
        {
            InicializarControlesItemVenta();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public VentaEditDto GetVenta()
        {
            return ventaDto;
        }


        private VentaEditDto ventaDto;
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                ventaDto = new VentaEditDto();
                ventaDto.Cliente = clienteListDto;
                ventaDto.FechaVenta = FechaPedidoDatePicker.Value;
                foreach (var item in carrito.GetItems())
                {
                    var itemEditDto = new DetalleVentaEditDto()
                    {
                        Producto = item.Producto,
                        Cantidad = item.Cantidad,
                        Precio = item.Precio,
                    };
                    ventaDto.DetalleVentas.Add(itemEditDto);
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void PedidoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex!=4)
            {
                return;
            }

            var r = PedidoDataGridView.Rows[e.RowIndex];
            var item = (DetalleVentaEditDto) r.Tag;
            DialogResult dr = MessageBox.Show($"Desea quitar el producto {item.Producto.NombreProducto}?",
                "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr==DialogResult.No)
            {
                return;
            }
            carrito.BorrarDelCarrito(item);
            MostrarDatosEnGrilla();
            MostrarTotalDeVenta();
            MessageBox.Show("Item eliminado",
                "Mensaje",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
