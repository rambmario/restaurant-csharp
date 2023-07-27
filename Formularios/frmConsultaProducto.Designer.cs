namespace Gestion_gastronomica.Formularios
{
    partial class frmConsultaProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaProducto));
            this.dgvproducto = new System.Windows.Forms.DataGridView();
            this.cmbGrupo_producto = new System.Windows.Forms.ComboBox();
            this.txtnombre_producto = new System.Windows.Forms.TextBox();
            this.cmbtipo_producto = new System.Windows.Forms.ComboBox();
            this.chkGrupo_producto = new System.Windows.Forms.CheckBox();
            this.chkTipo_producto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvproducto
            // 
            this.dgvproducto.AllowUserToAddRows = false;
            this.dgvproducto.AllowUserToDeleteRows = false;
            this.dgvproducto.AllowUserToResizeColumns = false;
            this.dgvproducto.AllowUserToResizeRows = false;
            this.dgvproducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvproducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvproducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvproducto.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvproducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvproducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvproducto.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvproducto.Location = new System.Drawing.Point(12, 190);
            this.dgvproducto.MultiSelect = false;
            this.dgvproducto.Name = "dgvproducto";
            this.dgvproducto.ReadOnly = true;
            this.dgvproducto.RowHeadersVisible = false;
            this.dgvproducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvproducto.Size = new System.Drawing.Size(801, 413);
            this.dgvproducto.TabIndex = 32;
            this.dgvproducto.CurrentCellChanged += new System.EventHandler(this.dgvproducto_CurrentCellChanged);
            this.dgvproducto.DoubleClick += new System.EventHandler(this.dgvproducto_DoubleClick);
            this.dgvproducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvproducto_KeyDown);
            // 
            // cmbGrupo_producto
            // 
            this.cmbGrupo_producto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGrupo_producto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGrupo_producto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGrupo_producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupo_producto.FormattingEnabled = true;
            this.cmbGrupo_producto.ItemHeight = 13;
            this.cmbGrupo_producto.Location = new System.Drawing.Point(155, 26);
            this.cmbGrupo_producto.Name = "cmbGrupo_producto";
            this.cmbGrupo_producto.Size = new System.Drawing.Size(531, 21);
            this.cmbGrupo_producto.TabIndex = 40;
            this.cmbGrupo_producto.SelectedIndexChanged += new System.EventHandler(this.cmbGrupo_producto_SelectedIndexChanged);
            // 
            // txtnombre_producto
            // 
            this.txtnombre_producto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnombre_producto.Location = new System.Drawing.Point(155, 122);
            this.txtnombre_producto.Name = "txtnombre_producto";
            this.txtnombre_producto.Size = new System.Drawing.Size(531, 20);
            this.txtnombre_producto.TabIndex = 1;
            this.txtnombre_producto.TextChanged += new System.EventHandler(this.txtnombre_producto_TextChanged);
            this.txtnombre_producto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnombre_producto_KeyDown);
            // 
            // cmbtipo_producto
            // 
            this.cmbtipo_producto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbtipo_producto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbtipo_producto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbtipo_producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipo_producto.FormattingEnabled = true;
            this.cmbtipo_producto.ItemHeight = 13;
            this.cmbtipo_producto.Location = new System.Drawing.Point(155, 72);
            this.cmbtipo_producto.Name = "cmbtipo_producto";
            this.cmbtipo_producto.Size = new System.Drawing.Size(531, 21);
            this.cmbtipo_producto.TabIndex = 41;
            // 
            // chkGrupo_producto
            // 
            this.chkGrupo_producto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGrupo_producto.AutoSize = true;
            this.chkGrupo_producto.Location = new System.Drawing.Point(44, 31);
            this.chkGrupo_producto.Name = "chkGrupo_producto";
            this.chkGrupo_producto.Size = new System.Drawing.Size(101, 17);
            this.chkGrupo_producto.TabIndex = 42;
            this.chkGrupo_producto.Text = "Grupo Producto";
            this.chkGrupo_producto.UseVisualStyleBackColor = true;
            // 
            // chkTipo_producto
            // 
            this.chkTipo_producto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTipo_producto.AutoSize = true;
            this.chkTipo_producto.Location = new System.Drawing.Point(44, 77);
            this.chkTipo_producto.Name = "chkTipo_producto";
            this.chkTipo_producto.Size = new System.Drawing.Size(93, 17);
            this.chkTipo_producto.TabIndex = 43;
            this.chkTipo_producto.Text = "Tipo Producto";
            this.chkTipo_producto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Producto";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(738, 109);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(34, 33);
            this.btnActualizar.TabIndex = 622;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(23, 166);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(94, 15);
            this.Label2.TabIndex = 624;
            this.Label2.Text = "Seleccionado";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProducto
            // 
            this.txtProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(123, 163);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(671, 21);
            this.txtProducto.TabIndex = 623;
            this.txtProducto.TabStop = false;
            // 
            // frmConsultaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 635);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTipo_producto);
            this.Controls.Add(this.chkGrupo_producto);
            this.Controls.Add(this.cmbGrupo_producto);
            this.Controls.Add(this.txtnombre_producto);
            this.Controls.Add(this.cmbtipo_producto);
            this.Controls.Add(this.dgvproducto);
            this.KeyPreview = true;
            this.Name = "frmConsultaProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Producto";
            this.Load += new System.EventHandler(this.frmConsultaProducto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvproducto;
        private System.Windows.Forms.ComboBox cmbGrupo_producto;
        private System.Windows.Forms.TextBox txtnombre_producto;
        private System.Windows.Forms.ComboBox cmbtipo_producto;
        private System.Windows.Forms.CheckBox chkGrupo_producto;
        private System.Windows.Forms.CheckBox chkTipo_producto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        protected System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox txtProducto;
    }
}