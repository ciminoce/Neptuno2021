using System;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmCiudadesAE : Form
    {
        public FrmCiudadesAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboPaises(ref PaisesComboBox);
            if (ciudad != null)
            {
                CiudadTextBox.Text = ciudad.NombreCiudad;
                PaisesComboBox.SelectedValue = ciudad.Pais.PaisId;
            }
        }


        private CiudadEditDto ciudad;

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidadDatos())
            {
                if (ciudad == null)
                {
                    ciudad = new CiudadEditDto();
                }

                ciudad.NombreCiudad = CiudadTextBox.Text;
                ciudad.Pais = (PaisListDto) PaisesComboBox.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidadDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(CiudadTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(CiudadTextBox,"La ciudad es requerida");
            }

            if (PaisesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox,"Debe seleccionar un país");
            }

            return valido;
        }

        public void SetCiudad(CiudadEditDto ciudad)
        {
            this.ciudad = ciudad;
        }

        public CiudadEditDto GetCiudad()
        {
            return ciudad;
        }

    }
}
