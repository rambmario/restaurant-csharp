namespace Gestion_gastronomica.Formularios
{
    partial class frmDetalleUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleUsuario));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarGrupoUsuario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbgrupo_usuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtnombre_usuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNumero_4 = new System.Windows.Forms.TextBox();
            this.txtNumero_8 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 231);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnBuscarGrupoUsuario
            // 
            this.btnBuscarGrupoUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarGrupoUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarGrupoUsuario.Image")));
            this.btnBuscarGrupoUsuario.Location = new System.Drawing.Point(534, 178);
            this.btnBuscarGrupoUsuario.Name = "btnBuscarGrupoUsuario";
            this.btnBuscarGrupoUsuario.Size = new System.Drawing.Size(38, 21);
            this.btnBuscarGrupoUsuario.TabIndex = 22;
            this.btnBuscarGrupoUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarGrupoUsuario.Click += new System.EventHandler(this.btnBuscarGrupoUsuario_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Grupo Usuario";
            // 
            // cmbgrupo_usuario
            // 
            this.cmbgrupo_usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbgrupo_usuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbgrupo_usuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbgrupo_usuario.FormattingEnabled = true;
            this.cmbgrupo_usuario.ItemHeight = 13;
            this.cmbgrupo_usuario.Location = new System.Drawing.Point(139, 178);
            this.cmbgrupo_usuario.Name = "cmbgrupo_usuario";
            this.cmbgrupo_usuario.Size = new System.Drawing.Size(389, 21);
            this.cmbgrupo_usuario.TabIndex = 8;
            this.cmbgrupo_usuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbgrupo_usuario_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mail";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(139, 92);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(389, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtnombre_usuario
            // 
            this.txtnombre_usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtnombre_usuario.Location = new System.Drawing.Point(139, 54);
            this.txtnombre_usuario.Name = "txtnombre_usuario";
            this.txtnombre_usuario.Size = new System.Drawing.Size(389, 20);
            this.txtnombre_usuario.TabIndex = 5;
            this.txtnombre_usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_usuario_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // txtmail
            // 
            this.txtmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtmail.Location = new System.Drawing.Point(139, 136);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(389, 20);
            this.txtmail.TabIndex = 7;
            this.txtmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmail_KeyPress);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(483, 271);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 56);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(363, 271);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 56);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNumero_4
            // 
            this.txtNumero_4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero_4.Location = new System.Drawing.Point(12, 307);
            this.txtNumero_4.Name = "txtNumero_4";
            this.txtNumero_4.Size = new System.Drawing.Size(38, 20);
            this.txtNumero_4.TabIndex = 12;
            this.txtNumero_4.Visible = false;
            this.txtNumero_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_4_KeyPress);
            // 
            // txtNumero_8
            // 
            this.txtNumero_8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero_8.Location = new System.Drawing.Point(113, 307);
            this.txtNumero_8.Name = "txtNumero_8";
            this.txtNumero_8.Size = new System.Drawing.Size(45, 20);
            this.txtNumero_8.TabIndex = 13;
            this.txtNumero_8.Visible = false;
            this.txtNumero_8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_8_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "4";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "8";
            this.label6.Visible = false;
            // 
            // frmDetalleUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 359);
            this.Controls.Add(this.btnBuscarGrupoUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumero_8);
            this.Controls.Add(this.txtNumero_4);
            this.Controls.Add(this.cmbgrupo_usuario);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtnombre_usuario);
            this.Controls.Add(this.txtmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmDetalleUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga de Usuarios";
            this.Load += new System.EventHandler(this.frmDetalleUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtnombre_usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscarGrupoUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNumero_4;
        private System.Windows.Forms.TextBox txtNumero_8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbgrupo_usuario;
    }
}