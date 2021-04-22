using System;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.Windows
{
    public partial class FrmPaisesAE : Form
    {
        public FrmPaisesAE()
        {
            InitializeComponent();
        }

        private PaisEditDto pais;
        public void SetPais(PaisEditDto pais)
        {
            this.pais = pais;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais != null)
            {
                PaisTextBox.Text = pais.NombrePais;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais == null)
                {
                    pais = new PaisEditDto();
                }

                pais.NombrePais = PaisTextBox.Text;
                DialogResult = DialogResult.OK;
            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(PaisTextBox.Text) || string.IsNullOrWhiteSpace(PaisTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(PaisTextBox, "El nombre del país es requerido");
            }

            return valido;
        }

        public PaisEditDto GetPais()
        {
            return pais;
        }

        private void PaisTextBox_Enter(object sender, EventArgs e)
        {
            PaisTextBox.SelectAll();
        }
    }
}
