﻿
namespace Neptuno2021.Windows
{
    partial class FrmProveedoresAE
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
            this.CancelarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TelefonoTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CiudadesComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PaisesComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CodPostalTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CalleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CompaniaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelarButton
            // 
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Image = global::Neptuno2021.Windows.Properties.Resources.Cancelar;
            this.CancelarButton.Location = new System.Drawing.Point(470, 359);
            this.CancelarButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(135, 63);
            this.CancelarButton.TabIndex = 139;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Image = global::Neptuno2021.Windows.Properties.Resources.Aceptar;
            this.GuardarButton.Location = new System.Drawing.Point(204, 359);
            this.GuardarButton.Margin = new System.Windows.Forms.Padding(4);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(135, 63);
            this.GuardarButton.TabIndex = 138;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EmailTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TelefonoTextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(43, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 97);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(67, 54);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(625, 20);
            this.EmailTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email:";
            // 
            // TelefonoTextBox
            // 
            this.TelefonoTextBox.Location = new System.Drawing.Point(67, 16);
            this.TelefonoTextBox.MaxLength = 20;
            this.TelefonoTextBox.Name = "TelefonoTextBox";
            this.TelefonoTextBox.Size = new System.Drawing.Size(259, 20);
            this.TelefonoTextBox.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Teléfono:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CiudadesComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.PaisesComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CodPostalTextBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.CalleTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(43, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 147);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Dirección ";
            // 
            // CiudadesComboBox
            // 
            this.CiudadesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CiudadesComboBox.FormattingEnabled = true;
            this.CiudadesComboBox.Location = new System.Drawing.Point(67, 95);
            this.CiudadesComboBox.Name = "CiudadesComboBox";
            this.CiudadesComboBox.Size = new System.Drawing.Size(259, 21);
            this.CiudadesComboBox.TabIndex = 123;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 122;
            this.label7.Text = "Ciudad:";
            // 
            // PaisesComboBox
            // 
            this.PaisesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PaisesComboBox.FormattingEnabled = true;
            this.PaisesComboBox.Location = new System.Drawing.Point(67, 53);
            this.PaisesComboBox.Name = "PaisesComboBox";
            this.PaisesComboBox.Size = new System.Drawing.Size(259, 21);
            this.PaisesComboBox.TabIndex = 4;
            this.PaisesComboBox.SelectedIndexChanged += new System.EventHandler(this.PaisesComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "País:";
            // 
            // CodPostalTextBox
            // 
            this.CodPostalTextBox.Location = new System.Drawing.Point(424, 53);
            this.CodPostalTextBox.Name = "CodPostalTextBox";
            this.CodPostalTextBox.Size = new System.Drawing.Size(137, 20);
            this.CodPostalTextBox.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(386, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "C.P.:";
            // 
            // CalleTextBox
            // 
            this.CalleTextBox.Location = new System.Drawing.Point(67, 16);
            this.CalleTextBox.MaxLength = 150;
            this.CalleTextBox.Name = "CalleTextBox";
            this.CalleTextBox.Size = new System.Drawing.Size(565, 20);
            this.CalleTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Calle:";
            // 
            // CompaniaTextBox
            // 
            this.CompaniaTextBox.Location = new System.Drawing.Point(105, 29);
            this.CompaniaTextBox.MaxLength = 50;
            this.CompaniaTextBox.Name = "CompaniaTextBox";
            this.CompaniaTextBox.Size = new System.Drawing.Size(548, 20);
            this.CompaniaTextBox.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 137;
            this.label1.Text = "Compañía:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmProveedoresAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CompaniaTextBox);
            this.Controls.Add(this.label1);
            this.Name = "FrmProveedoresAE";
            this.Text = "FrmProveedoresAE";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TelefonoTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CiudadesComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox PaisesComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CodPostalTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox CalleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CompaniaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}