namespace Gestion_gastronomica.Formularios
{
    partial class frmMultiTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultiTicket));
            this.lstGeneral = new System.Windows.Forms.ListBox();
            this.lstTicket = new System.Windows.Forms.ListBox();
            this.btnVolverTodo = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnPasarTodo = new System.Windows.Forms.Button();
            this.btnpasar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txttotal_lstGeneral = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMesa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.txtdescuento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttotal_lstTicket = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtporcentajedescuento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsubtotal_LstTicket = new System.Windows.Forms.TextBox();
            this.btnimprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstGeneral
            // 
            this.lstGeneral.FormattingEnabled = true;
            this.lstGeneral.Location = new System.Drawing.Point(12, 51);
            this.lstGeneral.Name = "lstGeneral";
            this.lstGeneral.Size = new System.Drawing.Size(249, 329);
            this.lstGeneral.TabIndex = 0;
            // 
            // lstTicket
            // 
            this.lstTicket.FormattingEnabled = true;
            this.lstTicket.Location = new System.Drawing.Point(381, 51);
            this.lstTicket.Name = "lstTicket";
            this.lstTicket.Size = new System.Drawing.Size(251, 329);
            this.lstTicket.TabIndex = 1;
            // 
            // btnVolverTodo
            // 
            this.btnVolverTodo.Location = new System.Drawing.Point(298, 268);
            this.btnVolverTodo.Name = "btnVolverTodo";
            this.btnVolverTodo.Size = new System.Drawing.Size(40, 24);
            this.btnVolverTodo.TabIndex = 35;
            this.btnVolverTodo.Text = "<<";
            this.btnVolverTodo.UseVisualStyleBackColor = true;
            this.btnVolverTodo.Click += new System.EventHandler(this.btnVolverTodo_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(298, 123);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(40, 24);
            this.btnVolver.TabIndex = 34;
            this.btnVolver.Text = "<";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnPasarTodo
            // 
            this.btnPasarTodo.Location = new System.Drawing.Point(298, 226);
            this.btnPasarTodo.Name = "btnPasarTodo";
            this.btnPasarTodo.Size = new System.Drawing.Size(40, 24);
            this.btnPasarTodo.TabIndex = 33;
            this.btnPasarTodo.Text = ">>";
            this.btnPasarTodo.UseVisualStyleBackColor = true;
            this.btnPasarTodo.Click += new System.EventHandler(this.btnPasarTodo_Click);
            // 
            // btnpasar
            // 
            this.btnpasar.Location = new System.Drawing.Point(298, 80);
            this.btnpasar.Name = "btnpasar";
            this.btnpasar.Size = new System.Drawing.Size(40, 24);
            this.btnpasar.TabIndex = 32;
            this.btnpasar.Text = ">";
            this.btnpasar.UseVisualStyleBackColor = true;
            this.btnpasar.Click += new System.EventHandler(this.btnpasar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 36;
            this.label6.Text = "Total";
            // 
            // txttotal_lstGeneral
            // 
            this.txttotal_lstGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txttotal_lstGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal_lstGeneral.Location = new System.Drawing.Point(84, 386);
            this.txttotal_lstGeneral.Name = "txttotal_lstGeneral";
            this.txttotal_lstGeneral.ReadOnly = true;
            this.txttotal_lstGeneral.Size = new System.Drawing.Size(100, 22);
            this.txttotal_lstGeneral.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 39;
            this.label2.Text = "Mesa";
            // 
            // txtMesa
            // 
            this.txtMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMesa.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtMesa.Location = new System.Drawing.Point(310, 3);
            this.txtMesa.Name = "txtMesa";
            this.txtMesa.ReadOnly = true;
            this.txtMesa.Size = new System.Drawing.Size(100, 22);
            this.txtMesa.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Pedido";
            // 
            // txtPedido
            // 
            this.txtPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtPedido.Location = new System.Drawing.Point(84, 3);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.ReadOnly = true;
            this.txtPedido.Size = new System.Drawing.Size(100, 22);
            this.txtPedido.TabIndex = 40;
            // 
            // txtdescuento
            // 
            this.txtdescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtdescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescuento.Location = new System.Drawing.Point(517, 422);
            this.txtdescuento.Name = "txtdescuento";
            this.txtdescuento.ReadOnly = true;
            this.txtdescuento.Size = new System.Drawing.Size(100, 22);
            this.txtdescuento.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(414, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "Total";
            // 
            // txttotal_lstTicket
            // 
            this.txttotal_lstTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txttotal_lstTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal_lstTicket.Location = new System.Drawing.Point(471, 466);
            this.txttotal_lstTicket.Name = "txttotal_lstTicket";
            this.txttotal_lstTicket.ReadOnly = true;
            this.txttotal_lstTicket.Size = new System.Drawing.Size(100, 22);
            this.txttotal_lstTicket.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(376, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 44;
            this.label4.Text = "Descuento";
            // 
            // txtporcentajedescuento
            // 
            this.txtporcentajedescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtporcentajedescuento.ForeColor = System.Drawing.Color.Blue;
            this.txtporcentajedescuento.Location = new System.Drawing.Point(471, 422);
            this.txtporcentajedescuento.Name = "txtporcentajedescuento";
            this.txtporcentajedescuento.Size = new System.Drawing.Size(40, 22);
            this.txtporcentajedescuento.TabIndex = 42;
            this.txtporcentajedescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtporcentajedescuento_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(383, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "Sub Total";
            // 
            // txtsubtotal_LstTicket
            // 
            this.txtsubtotal_LstTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtsubtotal_LstTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubtotal_LstTicket.Location = new System.Drawing.Point(471, 386);
            this.txtsubtotal_LstTicket.Name = "txtsubtotal_LstTicket";
            this.txtsubtotal_LstTicket.ReadOnly = true;
            this.txtsubtotal_LstTicket.Size = new System.Drawing.Size(100, 22);
            this.txtsubtotal_LstTicket.TabIndex = 48;
            // 
            // btnimprimir
            // 
            this.btnimprimir.Enabled = false;
            this.btnimprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnimprimir.Image")));
            this.btnimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnimprimir.Location = new System.Drawing.Point(526, 497);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(75, 23);
            this.btnimprimir.TabIndex = 49;
            this.btnimprimir.Text = "Imprimir";
            this.btnimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnimprimir.UseVisualStyleBackColor = true;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // frmMultiTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 537);
            this.Controls.Add(this.btnimprimir);
            this.Controls.Add(this.txtdescuento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttotal_lstTicket);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtporcentajedescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtsubtotal_LstTicket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMesa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txttotal_lstGeneral);
            this.Controls.Add(this.btnVolverTodo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnPasarTodo);
            this.Controls.Add(this.btnpasar);
            this.Controls.Add(this.lstTicket);
            this.Controls.Add(this.lstGeneral);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(653, 564);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(653, 564);
            this.Name = "frmMultiTicket";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Multi Ticket";
            this.Load += new System.EventHandler(this.frmMultiTicket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstGeneral;
        private System.Windows.Forms.ListBox lstTicket;
        private System.Windows.Forms.Button btnVolverTodo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnPasarTodo;
        private System.Windows.Forms.Button btnpasar;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txttotal_lstGeneral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.TextBox txtdescuento;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txttotal_lstTicket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtporcentajedescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsubtotal_LstTicket;
        private System.Windows.Forms.Button btnimprimir;
    }
}