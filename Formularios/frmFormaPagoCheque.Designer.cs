namespace Gestion_gastronomica.Formularios
{
    partial class frmFormaPagoCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormaPagoCheque));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPago_venta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumero_Cheque = new System.Windows.Forms.TextBox();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.btnBanco = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Location = new System.Drawing.Point(341, 163);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPago_venta
            // 
            this.txtPago_venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPago_venta.ForeColor = System.Drawing.Color.Red;
            this.txtPago_venta.Location = new System.Drawing.Point(149, 113);
            this.txtPago_venta.Name = "txtPago_venta";
            this.txtPago_venta.Size = new System.Drawing.Size(267, 22);
            this.txtPago_venta.TabIndex = 8;
            this.txtPago_venta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPago_venta_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Pago";
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Location = new System.Drawing.Point(245, 163);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Banco";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Nro de Cheque";
            // 
            // txtNumero_Cheque
            // 
            this.txtNumero_Cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero_Cheque.ForeColor = System.Drawing.Color.Blue;
            this.txtNumero_Cheque.Location = new System.Drawing.Point(149, 81);
            this.txtNumero_Cheque.Name = "txtNumero_Cheque";
            this.txtNumero_Cheque.Size = new System.Drawing.Size(267, 22);
            this.txtNumero_Cheque.TabIndex = 7;
            this.txtNumero_Cheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_Cheque_KeyPress);
            // 
            // cmbBanco
            // 
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(149, 14);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(267, 21);
            this.cmbBanco.TabIndex = 5;
            this.cmbBanco.SelectedIndexChanged += new System.EventHandler(this.cmbBanco_SelectedIndexChanged);
            this.cmbBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBanco_KeyDown);
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(149, 47);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(267, 21);
            this.cmbCliente.TabIndex = 6;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            this.cmbCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCliente_KeyDown);
            // 
            // btnBanco
            // 
            this.btnBanco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBanco.Image = ((System.Drawing.Image)(resources.GetObject("btnBanco.Image")));
            this.btnBanco.Location = new System.Drawing.Point(422, 14);
            this.btnBanco.Name = "btnBanco";
            this.btnBanco.Size = new System.Drawing.Size(38, 21);
            this.btnBanco.TabIndex = 22;
            this.btnBanco.UseVisualStyleBackColor = true;
            this.btnBanco.Click += new System.EventHandler(this.btnBanco_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.Image")));
            this.btnBuscarCliente.Location = new System.Drawing.Point(422, 47);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(38, 21);
            this.btnBuscarCliente.TabIndex = 23;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // frmFormaPagoCheque
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(468, 198);
            this.ControlBox = false;
            this.Controls.Add(this.btnBanco);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.cmbBanco);
            this.Controls.Add(this.txtNumero_Cheque);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtPago_venta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(476, 230);
            this.MinimumSize = new System.Drawing.Size(476, 230);
            this.Name = "frmFormaPagoCheque";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pagos con Cheques";
            this.Load += new System.EventHandler(this.frmFormaPagoCheque_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmFormaPagoCheque_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtPago_venta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumero_Cheque;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Button btnBanco;
        private System.Windows.Forms.Button btnBuscarCliente;
    }
}