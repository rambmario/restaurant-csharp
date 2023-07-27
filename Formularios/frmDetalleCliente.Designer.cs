namespace Gestion_gastronomica.Formularios
{
    partial class frmDetalleCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleCliente));
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono_fijo = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombre_cliente = new System.Windows.Forms.TextBox();
            this.txtapellido_cliente = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCondicion_iva = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefono_movil = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.btnCondicion_iva = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipo_dni = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumero_dni_cuit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Telefono Fijo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Telefono Movil";
            // 
            // txtTelefono_fijo
            // 
            this.txtTelefono_fijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono_fijo.Location = new System.Drawing.Point(118, 151);
            this.txtTelefono_fijo.Name = "txtTelefono_fijo";
            this.txtTelefono_fijo.Size = new System.Drawing.Size(282, 29);
            this.txtTelefono_fijo.TabIndex = 8;
            this.txtTelefono_fijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTelefono_fijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_fijo_KeyPress);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(528, 425);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 56);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(447, 425);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 56);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Nombre";
            // 
            // txtnombre_cliente
            // 
            this.txtnombre_cliente.Location = new System.Drawing.Point(118, 35);
            this.txtnombre_cliente.Name = "txtnombre_cliente";
            this.txtnombre_cliente.Size = new System.Drawing.Size(372, 20);
            this.txtnombre_cliente.TabIndex = 5;
            this.txtnombre_cliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_cliente_KeyPress);
            // 
            // txtapellido_cliente
            // 
            this.txtapellido_cliente.Location = new System.Drawing.Point(118, 74);
            this.txtapellido_cliente.Name = "txtapellido_cliente";
            this.txtapellido_cliente.Size = new System.Drawing.Size(372, 20);
            this.txtapellido_cliente.TabIndex = 6;
            this.txtapellido_cliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtapellido_cliente_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 405);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // cmbCondicion_iva
            // 
            this.cmbCondicion_iva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCondicion_iva.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCondicion_iva.FormattingEnabled = true;
            this.cmbCondicion_iva.ItemHeight = 13;
            this.cmbCondicion_iva.Location = new System.Drawing.Point(118, 284);
            this.cmbCondicion_iva.Name = "cmbCondicion_iva";
            this.cmbCondicion_iva.Size = new System.Drawing.Size(372, 21);
            this.cmbCondicion_iva.TabIndex = 11;
            this.cmbCondicion_iva.SelectedIndexChanged += new System.EventHandler(this.cmbCondicion_iva_SelectedIndexChanged);
            this.cmbCondicion_iva.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCondicion_iva_KeyDown_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Direccion";
            // 
            // txtTelefono_movil
            // 
            this.txtTelefono_movil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono_movil.Location = new System.Drawing.Point(118, 199);
            this.txtTelefono_movil.Name = "txtTelefono_movil";
            this.txtTelefono_movil.Size = new System.Drawing.Size(282, 29);
            this.txtTelefono_movil.TabIndex = 9;
            this.txtTelefono_movil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTelefono_movil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_movil_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(118, 246);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(372, 20);
            this.txtDireccion.TabIndex = 10;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(31, 122);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 13);
            this.label25.TabIndex = 38;
            this.label25.Text = "Email";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(118, 115);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(372, 20);
            this.txtCorreo.TabIndex = 7;
            this.txtCorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorreo_KeyPress);
            // 
            // btnCondicion_iva
            // 
            this.btnCondicion_iva.Image = ((System.Drawing.Image)(resources.GetObject("btnCondicion_iva.Image")));
            this.btnCondicion_iva.Location = new System.Drawing.Point(496, 284);
            this.btnCondicion_iva.Name = "btnCondicion_iva";
            this.btnCondicion_iva.Size = new System.Drawing.Size(38, 21);
            this.btnCondicion_iva.TabIndex = 42;
            this.btnCondicion_iva.UseVisualStyleBackColor = true;
            this.btnCondicion_iva.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 289);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Condicion Iva";
            // 
            // cmbTipo_dni
            // 
            this.cmbTipo_dni.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipo_dni.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipo_dni.FormattingEnabled = true;
            this.cmbTipo_dni.ItemHeight = 13;
            this.cmbTipo_dni.Location = new System.Drawing.Point(118, 325);
            this.cmbTipo_dni.Name = "cmbTipo_dni";
            this.cmbTipo_dni.Size = new System.Drawing.Size(198, 21);
            this.cmbTipo_dni.TabIndex = 12;
            this.cmbTipo_dni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipo_dni_KeyDown);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(496, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 21);
            this.button1.TabIndex = 45;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Tipo Documento";
            // 
            // txtNumero_dni_cuit
            // 
            this.txtNumero_dni_cuit.Location = new System.Drawing.Point(118, 365);
            this.txtNumero_dni_cuit.Name = "txtNumero_dni_cuit";
            this.txtNumero_dni_cuit.Size = new System.Drawing.Size(198, 20);
            this.txtNumero_dni_cuit.TabIndex = 13;
            this.txtNumero_dni_cuit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_dni_cuit_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "N° DNI-Cuit";
            // 
            // frmDetalleCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 505);
            this.Controls.Add(this.txtNumero_dni_cuit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTipo_dni);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCondicion_iva);
            this.Controls.Add(this.btnCondicion_iva);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTelefono_movil);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono_fijo);
            this.Controls.Add(this.txtnombre_cliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtapellido_cliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDetalleCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Cliente";
            this.Load += new System.EventHandler(this.frmDetalleCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefono_fijo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombre_cliente;
        private System.Windows.Forms.TextBox txtapellido_cliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelefono_movil;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button btnCondicion_iva;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCondicion_iva;
        private System.Windows.Forms.ComboBox cmbTipo_dni;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumero_dni_cuit;
        private System.Windows.Forms.Label label7;
    }
}