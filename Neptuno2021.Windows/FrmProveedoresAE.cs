using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.DTOs.Proveedor;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmProveedoresAE : Form
    {
        public FrmProveedoresAE()
        {
            InitializeComponent();
        }

        public void SetProveedor(ProveedorEditDto proveedorEditDto)
        {
            proveedorDto = proveedorEditDto;
        }

        private ProveedorEditDto proveedorDto;
        public ProveedorEditDto GetProveedor()
        {
            return proveedorDto;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboPaises(ref PaisesComboBox);
            if (proveedorDto == null) return;
            CompaniaTextBox.Text = proveedorDto.NombreCompania;
            CalleTextBox.Text = proveedorDto.Direccion;
            CodPostalTextBox.Text = proveedorDto.CodPostal;
            TelefonoTextBox.Text = proveedorDto.Telefono;
            EmailTextBox.Text = proveedorDto.Email;
            PaisesComboBox.SelectedValue = proveedorDto.Pais.PaisId;
            Helper.CargarDatosComboCiudades(ref CiudadesComboBox, proveedorDto.Pais);
            CiudadesComboBox.SelectedValue = proveedorDto.Ciudad.CiudadId;

        }


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaisesComboBox.SelectedIndex != 0)
            {
                PaisListDto paisListDto = (PaisListDto)PaisesComboBox.SelectedItem;
                Helper.CargarDatosComboCiudades(ref CiudadesComboBox, paisListDto);
            }
            else
            {
                CiudadesComboBox.DataSource = null;
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedorDto == null)
                {
                    proveedorDto = new ProveedorEditDto();
                }

                proveedorDto.NombreCompania = CompaniaTextBox.Text;
                proveedorDto.Direccion = CalleTextBox.Text;
                proveedorDto.CodPostal = CodPostalTextBox.Text;
                proveedorDto.Pais = (PaisListDto)PaisesComboBox.SelectedItem;
                proveedorDto.Ciudad = (CiudadListDto)CiudadesComboBox.SelectedItem;
                proveedorDto.Telefono = TelefonoTextBox.Text;
                proveedorDto.Email = EmailTextBox.Text;

                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(CompaniaTextBox.Text)
                || string.IsNullOrWhiteSpace(CompaniaTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(CompaniaTextBox, "El nombre de la compañía es requerido");
            }

            if (PaisesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox, "Debe seleccionar un país");
            }

            if (CiudadesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CiudadesComboBox, "Debe seleccionar una ciudad");
            }

            return valido;
        }
    }
}
