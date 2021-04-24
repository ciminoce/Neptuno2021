using System;
using System.Web.ModelBinding;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmBuscarCliente : Form
    {
        public FrmBuscarCliente()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (PaisesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox,"Debe seleccioar al un país");
            }

            return valido;
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            Helper.CargarDatosComboPaises(ref PaisesComboBox);
        }

        private PaisListDto paisListDto;
        private CiudadListDto ciudadListDto;
        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaisesComboBox.SelectedIndex != 0)
            {
                paisListDto = (PaisListDto)PaisesComboBox.SelectedItem;
                Helper.CargarDatosComboCiudades(ref CiudadesComboBox, paisListDto);
            }
            else
            {
                CiudadesComboBox.DataSource = null;
                ciudadListDto = null;
                paisListDto = null;
            }

        }

        private void CiudadesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CiudadesComboBox.SelectedIndex>0)
            {
                ciudadListDto = (CiudadListDto) CiudadesComboBox.SelectedItem;
            }
            else
            {
                ciudadListDto = null;
            }
        }

        public PaisListDto GetPais()
        {
            return paisListDto;
        }

        public CiudadListDto GetCiudad()
        {
            return ciudadListDto;
        }
    }
}
