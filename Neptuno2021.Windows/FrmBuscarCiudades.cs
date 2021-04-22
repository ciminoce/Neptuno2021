using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmBuscarCiudades : Form
    {
        public FrmBuscarCiudades()
        {
            InitializeComponent();
        }

        private void FrmBuscarCiudades_Load(object sender, System.EventArgs e)
        {
            Helper.CargarDatosComboPaises(ref PaisesComboBox);
        }

        private PaisListDto paisDto;
        private void CancelarButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                paisDto =(PaisListDto) PaisesComboBox.SelectedItem;
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
                errorProvider1.SetError(PaisesComboBox,"Debe seleccionar un país");
            }

            return valido;
        }

        public PaisListDto GetPais()
        {
            return paisDto;
        }
    }
}
