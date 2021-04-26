
namespace Neptuno2021.Windows
{
    partial class FrmBuscarVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            this.ClientesComboBox = new System.Windows.Forms.ComboBox();
            this.FechaInicialDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FechaFinalDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ClienteCheckBox = new System.Windows.Forms.CheckBox();
            this.FechasCheckBox = new System.Windows.Forms.CheckBox();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(175, 40);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(42, 13);
            nameLabel.TabIndex = 20;
            nameLabel.Text = "Cliente:";
            // 
            // ClientesComboBox
            // 
            this.ClientesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientesComboBox.Enabled = false;
            this.ClientesComboBox.FormattingEnabled = true;
            this.ClientesComboBox.Location = new System.Drawing.Point(255, 37);
            this.ClientesComboBox.Name = "ClientesComboBox";
            this.ClientesComboBox.Size = new System.Drawing.Size(375, 21);
            this.ClientesComboBox.TabIndex = 19;
            this.ClientesComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientesComboBox_SelectedIndexChanged);
            // 
            // FechaInicialDatePicker
            // 
            this.FechaInicialDatePicker.Checked = false;
            this.FechaInicialDatePicker.Enabled = false;
            this.FechaInicialDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDatePicker.Location = new System.Drawing.Point(255, 74);
            this.FechaInicialDatePicker.Name = "FechaInicialDatePicker";
            this.FechaInicialDatePicker.Size = new System.Drawing.Size(122, 20);
            this.FechaInicialDatePicker.TabIndex = 22;
            this.FechaInicialDatePicker.ValueChanged += new System.EventHandler(this.FechaInicialDatePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fecha Inicial:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fecha Final:";
            // 
            // FechaFinalDatePicker
            // 
            this.FechaFinalDatePicker.Checked = false;
            this.FechaFinalDatePicker.Enabled = false;
            this.FechaFinalDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDatePicker.Location = new System.Drawing.Point(508, 74);
            this.FechaFinalDatePicker.Name = "FechaFinalDatePicker";
            this.FechaFinalDatePicker.Size = new System.Drawing.Size(122, 20);
            this.FechaFinalDatePicker.TabIndex = 22;
            // 
            // ClienteCheckBox
            // 
            this.ClienteCheckBox.AutoSize = true;
            this.ClienteCheckBox.Location = new System.Drawing.Point(39, 40);
            this.ClienteCheckBox.Name = "ClienteCheckBox";
            this.ClienteCheckBox.Size = new System.Drawing.Size(58, 17);
            this.ClienteCheckBox.TabIndex = 23;
            this.ClienteCheckBox.Text = "Cliente";
            this.ClienteCheckBox.UseVisualStyleBackColor = true;
            this.ClienteCheckBox.CheckedChanged += new System.EventHandler(this.ClienteCheckBox_CheckedChanged);
            // 
            // FechasCheckBox
            // 
            this.FechasCheckBox.AutoSize = true;
            this.FechasCheckBox.Location = new System.Drawing.Point(39, 74);
            this.FechasCheckBox.Name = "FechasCheckBox";
            this.FechasCheckBox.Size = new System.Drawing.Size(61, 17);
            this.FechasCheckBox.TabIndex = 23;
            this.FechasCheckBox.Text = "Fechas";
            this.FechasCheckBox.UseVisualStyleBackColor = true;
            this.FechasCheckBox.CheckedChanged += new System.EventHandler(this.FechasCheckBox_CheckedChanged);
            // 
            // CancelarButton
            // 
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Image = global::Neptuno2021.Windows.Properties.Resources.Cancelar;
            this.CancelarButton.Location = new System.Drawing.Point(495, 146);
            this.CancelarButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(135, 63);
            this.CancelarButton.TabIndex = 135;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Image = global::Neptuno2021.Windows.Properties.Resources.Aceptar;
            this.GuardarButton.Location = new System.Drawing.Point(39, 146);
            this.GuardarButton.Margin = new System.Windows.Forms.Padding(4);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(135, 63);
            this.GuardarButton.TabIndex = 134;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmBuscarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 231);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.FechasCheckBox);
            this.Controls.Add(this.ClienteCheckBox);
            this.Controls.Add(this.FechaFinalDatePicker);
            this.Controls.Add(this.FechaInicialDatePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClientesComboBox);
            this.Controls.Add(nameLabel);
            this.Name = "FrmBuscarVentas";
            this.Text = "FrmBuscarVentas";
            this.Load += new System.EventHandler(this.FrmBuscarVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ClientesComboBox;
        private System.Windows.Forms.DateTimePicker FechaInicialDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaFinalDatePicker;
        private System.Windows.Forms.CheckBox ClienteCheckBox;
        private System.Windows.Forms.CheckBox FechasCheckBox;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}