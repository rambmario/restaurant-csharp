namespace Gestion_gastronomica.Formularios
{
    partial class frmModificarPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarPedido));
            this.lblid_cuerpo = new System.Windows.Forms.Label();
            this.dgvCuerpo_producto = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuerpo_producto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblid_cuerpo
            // 
            this.lblid_cuerpo.AutoSize = true;
            this.lblid_cuerpo.BackColor = System.Drawing.Color.Red;
            this.lblid_cuerpo.Location = new System.Drawing.Point(12, 224);
            this.lblid_cuerpo.Name = "lblid_cuerpo";
            this.lblid_cuerpo.Size = new System.Drawing.Size(13, 13);
            this.lblid_cuerpo.TabIndex = 24;
            this.lblid_cuerpo.Text = "0";
            this.lblid_cuerpo.Visible = false;
            // 
            // dgvCuerpo_producto
            // 
            this.dgvCuerpo_producto.AllowUserToDeleteRows = false;
            this.dgvCuerpo_producto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuerpo_producto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCuerpo_producto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCuerpo_producto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuerpo_producto.Location = new System.Drawing.Point(12, 176);
            this.dgvCuerpo_producto.Name = "dgvCuerpo_producto";
            this.dgvCuerpo_producto.ReadOnly = true;
            this.dgvCuerpo_producto.Size = new System.Drawing.Size(665, 207);
            this.dgvCuerpo_producto.TabIndex = 23;
            this.dgvCuerpo_producto.CurrentCellChanged += new System.EventHandler(this.dgvCuerpo_producto_CurrentCellChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(715, 329);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 54);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.Location = new System.Drawing.Point(715, 189);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(71, 54);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modifica";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.Blue;
            this.txtCantidad.Location = new System.Drawing.Point(287, 114);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(241, 36);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProducto.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtNombreProducto.Location = new System.Drawing.Point(167, 38);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(489, 26);
            this.txtNombreProducto.TabIndex = 23;
            this.txtNombreProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmModificarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gestion_gastronomica.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(813, 395);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblid_cuerpo);
            this.Controls.Add(this.dgvCuerpo_producto);
            this.Name = "frmModificarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModificarPedido";
            this.Load += new System.EventHandler(this.frmModificarPedido_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmModificarPedido_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuerpo_producto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblid_cuerpo;
        private System.Windows.Forms.DataGridView dgvCuerpo_producto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtNombreProducto;
    }
}