namespace Gestion_gastronomica.Formularios
{
    partial class frmGestion_caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestion_caja));
            this.gbCaja = new System.Windows.Forms.GroupBox();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.txtTotal_Egreso_efectivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbEgreso = new System.Windows.Forms.GroupBox();
            this.txtDetalle_egreso = new System.Windows.Forms.TextBox();
            this.txtEfectivo_egreso = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre_usuario = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtsaldo_inicial = new System.Windows.Forms.TextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.lblNro_caja_texto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtnro_caja = new System.Windows.Forms.TextBox();
            this.ttGeneral = new System.Windows.Forms.ToolTip(this.components);
            this.gbCaja.SuspendLayout();
            this.gbEgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCaja
            // 
            this.gbCaja.Controls.Add(this.txtCheque);
            this.gbCaja.Controls.Add(this.txtTotal_Egreso_efectivo);
            this.gbCaja.Controls.Add(this.label4);
            this.gbCaja.Controls.Add(this.label8);
            this.gbCaja.Controls.Add(this.txtTarjeta);
            this.gbCaja.Controls.Add(this.label3);
            this.gbCaja.Controls.Add(this.txtTotal);
            this.gbCaja.Controls.Add(this.label5);
            this.gbCaja.Location = new System.Drawing.Point(12, 12);
            this.gbCaja.Name = "gbCaja";
            this.gbCaja.Size = new System.Drawing.Size(486, 562);
            this.gbCaja.TabIndex = 2;
            this.gbCaja.TabStop = false;
            this.gbCaja.Text = "Caja Abierta";
            // 
            // txtCheque
            // 
            this.txtCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.ForeColor = System.Drawing.Color.Blue;
            this.txtCheque.Location = new System.Drawing.Point(135, 390);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.ReadOnly = true;
            this.txtCheque.Size = new System.Drawing.Size(205, 26);
            this.txtCheque.TabIndex = 53;
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal_Egreso_efectivo
            // 
            this.txtTotal_Egreso_efectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTotal_Egreso_efectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal_Egreso_efectivo.ForeColor = System.Drawing.Color.Blue;
            this.txtTotal_Egreso_efectivo.Location = new System.Drawing.Point(135, 266);
            this.txtTotal_Egreso_efectivo.Name = "txtTotal_Egreso_efectivo";
            this.txtTotal_Egreso_efectivo.ReadOnly = true;
            this.txtTotal_Egreso_efectivo.Size = new System.Drawing.Size(205, 26);
            this.txtTotal_Egreso_efectivo.TabIndex = 54;
            this.txtTotal_Egreso_efectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cheque";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Total Egresos";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.ForeColor = System.Drawing.Color.Blue;
            this.txtTarjeta.Location = new System.Drawing.Point(135, 358);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.ReadOnly = true;
            this.txtTarjeta.Size = new System.Drawing.Size(205, 26);
            this.txtTarjeta.TabIndex = 52;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tarjeta";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Blue;
            this.txtTotal.Location = new System.Drawing.Point(229, 304);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(205, 26);
            this.txtTotal.TabIndex = 55;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(169, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total";
            // 
            // gbEgreso
            // 
            this.gbEgreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gbEgreso.Controls.Add(this.txtDetalle_egreso);
            this.gbEgreso.Controls.Add(this.txtEfectivo_egreso);
            this.gbEgreso.Controls.Add(this.label7);
            this.gbEgreso.Controls.Add(this.btnSave);
            this.gbEgreso.Controls.Add(this.label6);
            this.gbEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEgreso.ForeColor = System.Drawing.Color.Blue;
            this.gbEgreso.Location = new System.Drawing.Point(30, 70);
            this.gbEgreso.Name = "gbEgreso";
            this.gbEgreso.Size = new System.Drawing.Size(455, 131);
            this.gbEgreso.TabIndex = 1;
            this.gbEgreso.TabStop = false;
            this.gbEgreso.Text = "Registrar Egreso";
            // 
            // txtDetalle_egreso
            // 
            this.txtDetalle_egreso.Location = new System.Drawing.Point(133, 63);
            this.txtDetalle_egreso.Multiline = true;
            this.txtDetalle_egreso.Name = "txtDetalle_egreso";
            this.txtDetalle_egreso.Size = new System.Drawing.Size(303, 52);
            this.txtDetalle_egreso.TabIndex = 3;
            this.txtDetalle_egreso.Text = "Egreso en efectivo";
            // 
            // txtEfectivo_egreso
            // 
            this.txtEfectivo_egreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtEfectivo_egreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo_egreso.ForeColor = System.Drawing.Color.Blue;
            this.txtEfectivo_egreso.Location = new System.Drawing.Point(133, 31);
            this.txtEfectivo_egreso.Name = "txtEfectivo_egreso";
            this.txtEfectivo_egreso.Size = new System.Drawing.Size(205, 26);
            this.txtEfectivo_egreso.TabIndex = 1;
            this.txtEfectivo_egreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo_egreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabularDecimales);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Detalles Egreso";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(357, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 26);
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "Monto";
            // 
            // btnTerminar
            // 
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTerminar.Location = new System.Drawing.Point(329, 508);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(75, 57);
            this.btnTerminar.TabIndex = 30;
            this.btnTerminar.Text = "Cerrar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Detalles";
            // 
            // lblNombre_usuario
            // 
            this.lblNombre_usuario.AutoSize = true;
            this.lblNombre_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre_usuario.Location = new System.Drawing.Point(34, 35);
            this.lblNombre_usuario.Name = "lblNombre_usuario";
            this.lblNombre_usuario.Size = new System.Drawing.Size(51, 16);
            this.lblNombre_usuario.TabIndex = 6;
            this.lblNombre_usuario.Text = "label1";
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(410, 508);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 57);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtsaldo_inicial
            // 
            this.txtsaldo_inicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtsaldo_inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsaldo_inicial.ForeColor = System.Drawing.Color.Blue;
            this.txtsaldo_inicial.Location = new System.Drawing.Point(147, 210);
            this.txtsaldo_inicial.Name = "txtsaldo_inicial";
            this.txtsaldo_inicial.Size = new System.Drawing.Size(205, 26);
            this.txtsaldo_inicial.TabIndex = 50;
            this.txtsaldo_inicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtsaldo_inicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsaldo_inicial_KeyPress);
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label123.Location = new System.Drawing.Point(40, 210);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(94, 16);
            this.label123.TabIndex = 26;
            this.label123.Text = "Saldo Inicial";
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(133, 450);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(330, 52);
            this.txtDetalle.TabIndex = 4;
            // 
            // lblNro_caja_texto
            // 
            this.lblNro_caja_texto.AutoSize = true;
            this.lblNro_caja_texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro_caja_texto.Location = new System.Drawing.Point(348, 22);
            this.lblNro_caja_texto.Name = "lblNro_caja_texto";
            this.lblNro_caja_texto.Size = new System.Drawing.Size(68, 13);
            this.lblNro_caja_texto.TabIndex = 12;
            this.lblNro_caja_texto.Text = "Nº de Caja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Efectivo";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.ForeColor = System.Drawing.Color.Blue;
            this.txtEfectivo.Location = new System.Drawing.Point(147, 246);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.ReadOnly = true;
            this.txtEfectivo.Size = new System.Drawing.Size(205, 26);
            this.txtEfectivo.TabIndex = 51;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtnro_caja
            // 
            this.txtnro_caja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtnro_caja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnro_caja.ForeColor = System.Drawing.Color.Blue;
            this.txtnro_caja.Location = new System.Drawing.Point(351, 38);
            this.txtnro_caja.Name = "txtnro_caja";
            this.txtnro_caja.ReadOnly = true;
            this.txtnro_caja.Size = new System.Drawing.Size(100, 26);
            this.txtnro_caja.TabIndex = 100;
            this.txtnro_caja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmGestion_caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 586);
            this.ControlBox = false;
            this.Controls.Add(this.gbEgreso);
            this.Controls.Add(this.txtnro_caja);
            this.Controls.Add(this.lblNro_caja_texto);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsaldo_inicial);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label123);
            this.Controls.Add(this.lblNombre_usuario);
            this.Controls.Add(this.gbCaja);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(517, 613);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(517, 613);
            this.Name = "frmGestion_caja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.frmGestion_caja_Load);
            this.gbCaja.ResumeLayout(false);
            this.gbCaja.PerformLayout();
            this.gbEgreso.ResumeLayout(false);
            this.gbEgreso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCaja;
        private System.Windows.Forms.TextBox txtnro_caja;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label lblNombre_usuario;
        private System.Windows.Forms.Label lblNro_caja_texto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.TextBox txtsaldo_inicial;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip ttGeneral;
        private System.Windows.Forms.GroupBox gbEgreso;
        private System.Windows.Forms.TextBox txtEfectivo_egreso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDetalle_egreso;
        private System.Windows.Forms.TextBox txtTotal_Egreso_efectivo;
        private System.Windows.Forms.Label label8;
    }
}