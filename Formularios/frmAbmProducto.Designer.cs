namespace Gestion_gastronomica.Formularios
{
    partial class frmAbmProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbmProducto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.lblid_pk = new System.Windows.Forms.Label();
            this.chkFitroGrupo = new System.Windows.Forms.CheckBox();
            this.cmbGrupo_producto = new System.Windows.Forms.ComboBox();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnActualizar_porcentaje = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Location = new System.Drawing.Point(15, 598);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(992, 86);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(848, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 54);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBorrar.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrar.Image")));
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBorrar.Location = new System.Drawing.Point(288, 19);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(71, 54);
            this.btnBorrar.TabIndex = 10;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.Location = new System.Drawing.Point(159, 19);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(71, 54);
            this.btnModificar.TabIndex = 0;
            this.btnModificar.Text = "Modifica";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregar.Location = new System.Drawing.Point(31, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(71, 54);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(70, 561);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(937, 20);
            this.txtBuscar.TabIndex = 23;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Consultar";
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToDeleteRows = false;
            this.dgvProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.Location = new System.Drawing.Point(12, 76);
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            this.dgvProducto.Size = new System.Drawing.Size(995, 469);
            this.dgvProducto.TabIndex = 21;
            this.dgvProducto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducto_CellDoubleClick);
            this.dgvProducto.CurrentCellChanged += new System.EventHandler(this.dgvProducto_CurrentCellChanged);
            this.dgvProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProducto_KeyDown);
            this.dgvProducto.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvProducto_PreviewKeyDown);
            // 
            // lblid_pk
            // 
            this.lblid_pk.AutoSize = true;
            this.lblid_pk.BackColor = System.Drawing.Color.Red;
            this.lblid_pk.Location = new System.Drawing.Point(12, 28);
            this.lblid_pk.Name = "lblid_pk";
            this.lblid_pk.Size = new System.Drawing.Size(13, 13);
            this.lblid_pk.TabIndex = 22;
            this.lblid_pk.Text = "0";
            this.lblid_pk.Visible = false;
            // 
            // chkFitroGrupo
            // 
            this.chkFitroGrupo.AutoSize = true;
            this.chkFitroGrupo.Checked = true;
            this.chkFitroGrupo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFitroGrupo.Location = new System.Drawing.Point(12, 45);
            this.chkFitroGrupo.Name = "chkFitroGrupo";
            this.chkFitroGrupo.Size = new System.Drawing.Size(98, 17);
            this.chkFitroGrupo.TabIndex = 25;
            this.chkFitroGrupo.Text = "Filtar por Grupo";
            this.chkFitroGrupo.UseVisualStyleBackColor = true;
            this.chkFitroGrupo.CheckedChanged += new System.EventHandler(this.chkFitroGrupo_CheckedChanged);
            // 
            // cmbGrupo_producto
            // 
            this.cmbGrupo_producto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbGrupo_producto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGrupo_producto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGrupo_producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupo_producto.FormattingEnabled = true;
            this.cmbGrupo_producto.ItemHeight = 13;
            this.cmbGrupo_producto.Location = new System.Drawing.Point(116, 43);
            this.cmbGrupo_producto.Name = "cmbGrupo_producto";
            this.cmbGrupo_producto.Size = new System.Drawing.Size(372, 21);
            this.cmbGrupo_producto.TabIndex = 26;
            this.cmbGrupo_producto.SelectedIndexChanged += new System.EventHandler(this.cmbGrupo_producto_SelectedIndexChanged);
            this.cmbGrupo_producto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabularCombobox);
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(823, 28);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(100, 20);
            this.txtPorcentaje.TabIndex = 32;
            this.txtPorcentaje.Text = "00";
            this.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(802, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "%";
            // 
            // btnActualizar_porcentaje
            // 
            this.btnActualizar_porcentaje.Image = global::Gestion_gastronomica.Properties.Resources._1471890180_advantage_sale;
            this.btnActualizar_porcentaje.Location = new System.Drawing.Point(929, 12);
            this.btnActualizar_porcentaje.Name = "btnActualizar_porcentaje";
            this.btnActualizar_porcentaje.Size = new System.Drawing.Size(75, 52);
            this.btnActualizar_porcentaje.TabIndex = 31;
            this.btnActualizar_porcentaje.UseVisualStyleBackColor = true;
            this.btnActualizar_porcentaje.Click += new System.EventHandler(this.btnActualizar_porcentaje_Click);
            // 
            // frmAbmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 728);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.btnActualizar_porcentaje);
            this.Controls.Add(this.cmbGrupo_producto);
            this.Controls.Add(this.chkFitroGrupo);
            this.Controls.Add(this.lblid_pk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProducto);
            this.KeyPreview = true;
            this.Name = "frmAbmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.frmAbmProducto_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAbmProducto_KeyPress);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.Label lblid_pk;
        private System.Windows.Forms.CheckBox chkFitroGrupo;
        private System.Windows.Forms.ComboBox cmbGrupo_producto;
        private System.Windows.Forms.Button btnActualizar_porcentaje;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Label label2;
    }
}