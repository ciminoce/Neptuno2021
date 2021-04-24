
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
            System.Windows.Forms.Label nameLabel;
            this.ClientesComboBox = new System.Windows.Forms.ComboBox();
            this.FechaPedidoDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ClienteCheckBox = new System.Windows.Forms.CheckBox();
            this.FechasCheckBox = new System.Windows.Forms.CheckBox();
            nameLabel = new System.Windows.Forms.Label();
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
            // 
            // FechaPedidoDatePicker
            // 
            this.FechaPedidoDatePicker.Checked = false;
            this.FechaPedidoDatePicker.Enabled = false;
            this.FechaPedidoDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaPedidoDatePicker.Location = new System.Drawing.Point(255, 74);
            this.FechaPedidoDatePicker.Name = "FechaPedidoDatePicker";
            this.FechaPedidoDatePicker.Size = new System.Drawing.Size(122, 20);
            this.FechaPedidoDatePicker.TabIndex = 22;
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(508, 74);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 20);
            this.dateTimePicker1.TabIndex = 22;
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
            // 
            // FrmBuscarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 450);
            this.Controls.Add(this.FechasCheckBox);
            this.Controls.Add(this.ClienteCheckBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.FechaPedidoDatePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClientesComboBox);
            this.Controls.Add(nameLabel);
            this.Name = "FrmBuscarVentas";
            this.Text = "FrmBuscarVentas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ClientesComboBox;
        private System.Windows.Forms.DateTimePicker FechaPedidoDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox ClienteCheckBox;
        private System.Windows.Forms.CheckBox FechasCheckBox;
    }
}