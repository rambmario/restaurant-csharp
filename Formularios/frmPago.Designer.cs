namespace Gestion_gastronomica.Formularios
{
    partial class frmPago
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
            this.btnContado = new System.Windows.Forms.Button();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.btnCheque = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMesa = new System.Windows.Forms.TextBox();
            this.btnanularpago = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtporcentajedescuento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtvuelto = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtdescuento = new System.Windows.Forms.TextBox();
            this.txtIDEfectivo = new System.Windows.Forms.TextBox();
            this.txtefectivo = new System.Windows.Forms.TextBox();
            this.txtNoEfectivo = new System.Windows.Forms.TextBox();
            this.txtTicket = new System.Windows.Forms.TextBox();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.dgvPago_pedido = new System.Windows.Forms.DataGridView();
            this.lbllocalizacion = new System.Windows.Forms.Label();
            this.lblMulti_Ticket = new System.Windows.Forms.Label();
            this.chkFacturar = new System.Windows.Forms.CheckBox();
            this.txtNombre_cliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblid_cliente = new System.Windows.Forms.Label();
            this.btnBuscaCliente = new System.Windows.Forms.Button();
            this.lblid_condicion_iva = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPago_pedido)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContado
            // 
            this.btnContado.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnContado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnContado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnContado.Location = new System.Drawing.Point(12, 303);
            this.btnContado.Name = "btnContado";
            this.btnContado.Size = new System.Drawing.Size(75, 23);
            this.btnContado.TabIndex = 0;
            this.btnContado.Text = "Efectivo";
            this.btnContado.UseVisualStyleBackColor = true;
            this.btnContado.Click += new System.EventHandler(this.btnContado_Click);
            // 
            // txtPedido
            // 
            this.txtPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtPedido.Location = new System.Drawing.Point(165, 10);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.ReadOnly = true;
            this.txtPedido.Size = new System.Drawing.Size(100, 22);
            this.txtPedido.TabIndex = 28;
            this.txtPedido.TextChanged += new System.EventHandler(this.txtPedido_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pedido";
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnTarjeta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTarjeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTarjeta.Location = new System.Drawing.Point(12, 332);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(75, 23);
            this.btnTarjeta.TabIndex = 4;
            this.btnTarjeta.Text = "Tarjeta";
            this.btnTarjeta.UseVisualStyleBackColor = true;
            this.btnTarjeta.Click += new System.EventHandler(this.btnTarjeta_Click);
            // 
            // btnCheque
            // 
            this.btnCheque.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCheque.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCheque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCheque.Location = new System.Drawing.Point(12, 361);
            this.btnCheque.Name = "btnCheque";
            this.btnCheque.Size = new System.Drawing.Size(75, 23);
            this.btnCheque.TabIndex = 5;
            this.btnCheque.Text = "Cheque";
            this.btnCheque.UseVisualStyleBackColor = true;
            this.btnCheque.Click += new System.EventHandler(this.btnCheque_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mesa";
            // 
            // txtMesa
            // 
            this.txtMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMesa.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtMesa.Location = new System.Drawing.Point(336, 10);
            this.txtMesa.Name = "txtMesa";
            this.txtMesa.ReadOnly = true;
            this.txtMesa.Size = new System.Drawing.Size(100, 22);
            this.txtMesa.TabIndex = 29;
            // 
            // btnanularpago
            // 
            this.btnanularpago.Location = new System.Drawing.Point(12, 404);
            this.btnanularpago.Name = "btnanularpago";
            this.btnanularpago.Size = new System.Drawing.Size(75, 23);
            this.btnanularpago.TabIndex = 8;
            this.btnanularpago.Text = "Borrar Pago";
            this.btnanularpago.UseVisualStyleBackColor = true;
            this.btnanularpago.Click += new System.EventHandler(this.btnanularpago_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(263, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Descuento";
            // 
            // txtporcentajedescuento
            // 
            this.txtporcentajedescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtporcentajedescuento.ForeColor = System.Drawing.Color.Blue;
            this.txtporcentajedescuento.Location = new System.Drawing.Point(358, 133);
            this.txtporcentajedescuento.Name = "txtporcentajedescuento";
            this.txtporcentajedescuento.Size = new System.Drawing.Size(40, 22);
            this.txtporcentajedescuento.TabIndex = 4;
            this.txtporcentajedescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtporcentajedescuento_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sub Total";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubtotal.Location = new System.Drawing.Point(404, 94);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            this.txtsubtotal.Size = new System.Drawing.Size(100, 22);
            this.txtsubtotal.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(346, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Pago";
            // 
            // txtPago
            // 
            this.txtPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPago.ForeColor = System.Drawing.Color.Red;
            this.txtPago.Location = new System.Drawing.Point(404, 221);
            this.txtPago.Name = "txtPago";
            this.txtPago.ReadOnly = true;
            this.txtPago.Size = new System.Drawing.Size(100, 22);
            this.txtPago.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(347, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total";
            // 
            // txttotal
            // 
            this.txttotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.Location = new System.Drawing.Point(404, 174);
            this.txttotal.Name = "txttotal";
            this.txttotal.ReadOnly = true;
            this.txttotal.Size = new System.Drawing.Size(100, 22);
            this.txttotal.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(339, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Vuelto";
            // 
            // txtvuelto
            // 
            this.txtvuelto.BackColor = System.Drawing.Color.Red;
            this.txtvuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvuelto.ForeColor = System.Drawing.Color.Blue;
            this.txtvuelto.Location = new System.Drawing.Point(404, 262);
            this.txtvuelto.Name = "txtvuelto";
            this.txtvuelto.ReadOnly = true;
            this.txtvuelto.Size = new System.Drawing.Size(100, 22);
            this.txtvuelto.TabIndex = 22;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Location = new System.Drawing.Point(383, 409);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Location = new System.Drawing.Point(263, 409);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtdescuento
            // 
            this.txtdescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtdescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescuento.Location = new System.Drawing.Point(404, 133);
            this.txtdescuento.Name = "txtdescuento";
            this.txtdescuento.ReadOnly = true;
            this.txtdescuento.Size = new System.Drawing.Size(100, 22);
            this.txtdescuento.TabIndex = 25;
            // 
            // txtIDEfectivo
            // 
            this.txtIDEfectivo.Location = new System.Drawing.Point(0, 500);
            this.txtIDEfectivo.Name = "txtIDEfectivo";
            this.txtIDEfectivo.Size = new System.Drawing.Size(40, 20);
            this.txtIDEfectivo.TabIndex = 22;
            this.txtIDEfectivo.Visible = false;
            // 
            // txtefectivo
            // 
            this.txtefectivo.Location = new System.Drawing.Point(46, 500);
            this.txtefectivo.Name = "txtefectivo";
            this.txtefectivo.Size = new System.Drawing.Size(40, 20);
            this.txtefectivo.TabIndex = 23;
            this.txtefectivo.Visible = false;
            // 
            // txtNoEfectivo
            // 
            this.txtNoEfectivo.Location = new System.Drawing.Point(276, 500);
            this.txtNoEfectivo.Name = "txtNoEfectivo";
            this.txtNoEfectivo.Size = new System.Drawing.Size(40, 20);
            this.txtNoEfectivo.TabIndex = 24;
            this.txtNoEfectivo.Visible = false;
            // 
            // txtTicket
            // 
            this.txtTicket.Location = new System.Drawing.Point(230, 500);
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.Size = new System.Drawing.Size(40, 20);
            this.txtTicket.TabIndex = 25;
            this.txtTicket.Visible = false;
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(184, 500);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(40, 20);
            this.txtCheque.TabIndex = 26;
            this.txtCheque.Visible = false;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(138, 500);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(40, 20);
            this.txtTarjeta.TabIndex = 27;
            this.txtTarjeta.Visible = false;
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(92, 500);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(40, 20);
            this.txtCC.TabIndex = 28;
            this.txtCC.Visible = false;
            // 
            // dgvPago_pedido
            // 
            this.dgvPago_pedido.AllowUserToAddRows = false;
            this.dgvPago_pedido.AllowUserToDeleteRows = false;
            this.dgvPago_pedido.AllowUserToResizeColumns = false;
            this.dgvPago_pedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPago_pedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPago_pedido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPago_pedido.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPago_pedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPago_pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPago_pedido.Location = new System.Drawing.Point(0, 50);
            this.dgvPago_pedido.Name = "dgvPago_pedido";
            this.dgvPago_pedido.ReadOnly = true;
            this.dgvPago_pedido.RowHeadersVisible = false;
            this.dgvPago_pedido.Size = new System.Drawing.Size(224, 176);
            this.dgvPago_pedido.TabIndex = 29;
            this.dgvPago_pedido.CurrentCellChanged += new System.EventHandler(this.dgvPago_pedido_CurrentCellChanged_1);
            // 
            // lbllocalizacion
            // 
            this.lbllocalizacion.AutoSize = true;
            this.lbllocalizacion.Location = new System.Drawing.Point(386, 361);
            this.lbllocalizacion.Name = "lbllocalizacion";
            this.lbllocalizacion.Size = new System.Drawing.Size(13, 13);
            this.lbllocalizacion.TabIndex = 30;
            this.lbllocalizacion.Text = "L";
            this.lbllocalizacion.Visible = false;
            // 
            // lblMulti_Ticket
            // 
            this.lblMulti_Ticket.AutoSize = true;
            this.lblMulti_Ticket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMulti_Ticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMulti_Ticket.ForeColor = System.Drawing.Color.Blue;
            this.lblMulti_Ticket.Location = new System.Drawing.Point(123, 409);
            this.lblMulti_Ticket.Name = "lblMulti_Ticket";
            this.lblMulti_Ticket.Size = new System.Drawing.Size(123, 13);
            this.lblMulti_Ticket.TabIndex = 31;
            this.lblMulti_Ticket.Text = "Generar Multi Ticket";
            this.lblMulti_Ticket.Click += new System.EventHandler(this.lblMulti_Ticket_Click);
            // 
            // chkFacturar
            // 
            this.chkFacturar.AutoSize = true;
            this.chkFacturar.Location = new System.Drawing.Point(264, 380);
            this.chkFacturar.Name = "chkFacturar";
            this.chkFacturar.Size = new System.Drawing.Size(114, 17);
            this.chkFacturar.TabIndex = 32;
            this.chkFacturar.Text = "Facturar Ticket CF";
            this.chkFacturar.UseVisualStyleBackColor = true;
            // 
            // txtNombre_cliente
            // 
            this.txtNombre_cliente.Location = new System.Drawing.Point(175, 308);
            this.txtNombre_cliente.Name = "txtNombre_cliente";
            this.txtNombre_cliente.ReadOnly = true;
            this.txtNombre_cliente.Size = new System.Drawing.Size(283, 20);
            this.txtNombre_cliente.TabIndex = 33;
            this.txtNombre_cliente.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(115, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 34;
            this.label8.Text = "Cliente";
            // 
            // lblid_cliente
            // 
            this.lblid_cliente.AutoSize = true;
            this.lblid_cliente.BackColor = System.Drawing.Color.Transparent;
            this.lblid_cliente.Location = new System.Drawing.Point(558, 308);
            this.lblid_cliente.Name = "lblid_cliente";
            this.lblid_cliente.Size = new System.Drawing.Size(13, 13);
            this.lblid_cliente.TabIndex = 35;
            this.lblid_cliente.Text = "0";
            this.lblid_cliente.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnBuscaCliente
            // 
            this.btnBuscaCliente.Location = new System.Drawing.Point(466, 308);
            this.btnBuscaCliente.Name = "btnBuscaCliente";
            this.btnBuscaCliente.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaCliente.TabIndex = 36;
            this.btnBuscaCliente.Text = "Cambiar";
            this.btnBuscaCliente.UseVisualStyleBackColor = true;
            this.btnBuscaCliente.Click += new System.EventHandler(this.btnBuscaCliente_Click);
            // 
            // lblid_condicion_iva
            // 
            this.lblid_condicion_iva.AutoSize = true;
            this.lblid_condicion_iva.BackColor = System.Drawing.Color.Transparent;
            this.lblid_condicion_iva.Location = new System.Drawing.Point(558, 337);
            this.lblid_condicion_iva.Name = "lblid_condicion_iva";
            this.lblid_condicion_iva.Size = new System.Drawing.Size(13, 13);
            this.lblid_condicion_iva.TabIndex = 59;
            this.lblid_condicion_iva.Text = "0";
            // 
            // frmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(584, 457);
            this.ControlBox = false;
            this.Controls.Add(this.lblid_condicion_iva);
            this.Controls.Add(this.btnBuscaCliente);
            this.Controls.Add(this.lblid_cliente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombre_cliente);
            this.Controls.Add(this.chkFacturar);
            this.Controls.Add(this.lblMulti_Ticket);
            this.Controls.Add(this.lbllocalizacion);
            this.Controls.Add(this.dgvPago_pedido);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.txtCheque);
            this.Controls.Add(this.txtTicket);
            this.Controls.Add(this.txtNoEfectivo);
            this.Controls.Add(this.txtefectivo);
            this.Controls.Add(this.txtIDEfectivo);
            this.Controls.Add(this.txtdescuento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtvuelto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtporcentajedescuento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.btnanularpago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMesa);
            this.Controls.Add(this.btnCheque);
            this.Controls.Add(this.btnTarjeta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.btnContado);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(600, 495);
            this.MinimumSize = new System.Drawing.Size(479, 495);
            this.Name = "frmPago";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago";
            this.Load += new System.EventHandler(this.frmPago_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPago_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPago_pedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContado;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTarjeta;
        private System.Windows.Forms.Button btnCheque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMesa;
        private System.Windows.Forms.Button btnanularpago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtporcentajedescuento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtvuelto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtdescuento;
        private System.Windows.Forms.TextBox txtIDEfectivo;
        private System.Windows.Forms.TextBox txtefectivo;
        private System.Windows.Forms.TextBox txtNoEfectivo;
        private System.Windows.Forms.TextBox txtTicket;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.DataGridView dgvPago_pedido;
        public System.Windows.Forms.Label lbllocalizacion;
        public System.Windows.Forms.TextBox txtPago;
        public System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label lblMulti_Ticket;
        private System.Windows.Forms.CheckBox chkFacturar;
        private System.Windows.Forms.TextBox txtNombre_cliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblid_cliente;
        private System.Windows.Forms.Button btnBuscaCliente;
        private System.Windows.Forms.Label lblid_condicion_iva;
    }
}