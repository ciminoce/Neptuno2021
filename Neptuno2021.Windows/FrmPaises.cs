using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.Entidades;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Windows
{
    public partial class FrmPaises : Form
    {
        public FrmPaises()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosPais _servicio;
        private List<Pais> _lista;
        private void FrmPaises_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosPaises();
            try
            {
                _lista = _servicio.GetPaises();
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
            foreach (var pais in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, pais);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Pais pais)
        {
            r.Cells[cmnPais.Index].Value = pais.NombrePais;

            r.Tag = pais;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
    }
}
