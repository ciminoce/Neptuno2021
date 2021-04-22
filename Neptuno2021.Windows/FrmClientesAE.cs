using System;
using System.Windows.Forms;
using CrystalDecisions.ReportAppServer;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmClientesAE : Form
    {
        public FrmClientesAE()
        {
            InitializeComponent();
        }

        private ClienteEditDto clienteEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboPaises(ref PaisesComboBox);
            if (clienteEditDto != null)
            {
                CompaniaTextBox.Text = clienteEditDto.NombreCompania;
                CalleTextBox.Text = clienteEditDto.Direccion;
                CodPostalTextBox.Text = clienteEditDto.CodPostal;
                TelefonoTextBox.Text = clienteEditDto.Telefono;
                EmailTextBox.Text = clienteEditDto.Email;
                PaisesComboBox.SelectedValue = clienteEditDto.Pais.PaisId;
                Helper.CargarDatosComboCiudades(ref CiudadesComboBox, clienteEditDto.Pais);
                CiudadesComboBox.SelectedValue = clienteEditDto.Ciudad.CiudadId;
            }

        }

        private void CancelarButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaisesComboBox.SelectedIndex!=0)
            {
                PaisListDto paisListDto = (PaisListDto) PaisesComboBox.SelectedItem;
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
                if (clienteEditDto==null)
                {
                    clienteEditDto = new ClienteEditDto();
                }

                clienteEditDto.NombreCompania = CompaniaTextBox.Text;
                clienteEditDto.Direccion = CalleTextBox.Text;
                clienteEditDto.CodPostal = CodPostalTextBox.Text;
                clienteEditDto.Pais = (PaisListDto) PaisesComboBox.SelectedItem;
                clienteEditDto.Ciudad = (CiudadListDto) CiudadesComboBox.SelectedItem;
                clienteEditDto.Telefono = TelefonoTextBox.Text;
                clienteEditDto.Email = EmailTextBox.Text;

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
                errorProvider1.SetError(CompaniaTextBox,"El nombre de la compañía es requerido");
            }

            if (PaisesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox,"Debe seleccionar un país");
            }

            if (CiudadesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(CiudadesComboBox,"Debe seleccionar una ciudad");
            }

            return valido;
        }

        public ClienteEditDto GetCliente()
        {
            return clienteEditDto;
        }

        public void SetCliente(ClienteEditDto clienteEditDto)
        {
            this.clienteEditDto = clienteEditDto;
        }
    }
}
