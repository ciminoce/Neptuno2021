using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.Windows.Helpers;

namespace Neptuno2021.Windows
{
    public partial class FrmBuscarVentas : Form
    {
        public FrmBuscarVentas()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private Tuple<ClienteListDto, DateTime, DateTime> paremetros;
        private ClienteListDto clienteDto;
        private DateTime fechaInicial=DateTime.Today.AddYears(-50);
        private DateTime fechaFinal=DateTime.Today;
        public ClienteListDto GetCliente()
        {
            return clienteDto;

        }

        public DateTime GetFechaInicial()
        {
            return fechaInicial;
        }

        public DateTime GetFechaFinal()
        {
            return fechaFinal;
        }

        private void ClienteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClientesComboBox.Enabled = ClienteCheckBox.Checked;
        }

        private void FechasCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FechaInicialDatePicker.Enabled = FechasCheckBox.Checked;
            FechaFinalDatePicker.Enabled = FechasCheckBox.Checked;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (FechasCheckBox.Checked)
                {
                    fechaInicial = FechaInicialDatePicker.Value;
                    fechaFinal = FechaFinalDatePicker.Value;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (ClienteCheckBox.Checked && clienteDto==null)
            {
                valido = false;
                errorProvider1.SetError(ClientesComboBox,"Debe seleccionar un cliente");
            }

            if (FechasCheckBox.Checked)
            {
                if (FechaInicialDatePicker.Value>FechaFinalDatePicker.Value)
                {
                    valido = false;
                    errorProvider1.SetError(FechaInicialDatePicker,"Fecha inicial mayor a la final");
                }
            }

            return valido;
        }

        private void FechaInicialDatePicker_ValueChanged(object sender, EventArgs e)
        {
            FechaFinalDatePicker.Value = FechaInicialDatePicker.Value;
        }

        private void ClientesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClientesComboBox.SelectedIndex>0)
            {
                clienteDto = (ClienteListDto) ClientesComboBox.SelectedItem;
                
            }
            else
            {
                clienteDto = null;
            }
        }

        private void FrmBuscarVentas_Load(object sender, EventArgs e)
        {
            Helper.CargarDatosComboClientes(ref ClientesComboBox);
        }
    }
}
