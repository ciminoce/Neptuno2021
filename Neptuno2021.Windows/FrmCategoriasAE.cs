using System;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Categoria;

namespace Neptuno2021.Windows
{
    public partial class FrmCategoriasAE : Form
    {
        public FrmCategoriasAE()
        {
            InitializeComponent();
        }

        private CategoriaEditDto categoriaDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (categoriaDto!=null)
            {
                CategoriaTextBox.Text = categoriaDto.NombreCategoria;
                DescripcionTextBox.Text = categoriaDto.Descripcion;
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoriaDto==null)
                {
                    categoriaDto=new CategoriaEditDto();
                }
                categoriaDto.NombreCategoria = CategoriaTextBox.Text;
                categoriaDto.Descripcion = DescripcionTextBox.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        { 
                
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(CategoriaTextBox.Text) || 
                string.IsNullOrWhiteSpace(CategoriaTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(CategoriaTextBox,"Nombre de categoría requerido");
            }

            return valido;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public CategoriaEditDto GetCategoria()
        {
            return categoriaDto;
        }

        public void SetCategoria(CategoriaEditDto categoriaEditDto)
        {
            categoriaDto = categoriaEditDto;
        }
    }
}
