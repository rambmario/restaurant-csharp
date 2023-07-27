using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion_gastronomica.Formularios
{
    public partial class frmAbmUsuario : Form
    {
        public frmAbmUsuario()
        {
            InitializeComponent();
        }
        Clase.clsUsuario oUsuario = new Clase.clsUsuario();
        DataTable odt = null;

        private void frmAbmUsuario_Load(object sender, EventArgs e)
        {
            RefrescarGrilla();
            this.CancelButton = this.btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.txtBuscar.Focus();
        }

        public void RefrescarGrilla()
        {
            DataTable odt = null;
            odt = oUsuario.GetAll_2();
            this.dgvUsuario.DataSource = odt;
            this.dgvUsuario.Columns[0].Visible = false;
            this.dgvUsuario.AllowUserToAddRows = false;
        }

        private void dgvUsuario_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                bool res = int.TryParse(this.dgvUsuario[0, this.dgvUsuario.CurrentRow.Index].Value.ToString(), out Inicio.id_usuario );
                this.lblid_pk.Text = Convert.ToString(Inicio.id_usuario);
            }
            catch { }
        }


        //metodo para identificar el tipo de boton clickeado
        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleUsuario frmDetalles = new frmDetalleUsuario();
            btntemp = (Button)sender;

            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.BanderaUsuario = 1;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.BanderaUsuario = 2;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro Nro:" + Inicio.id_usuario,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        oUsuario.pid_usuario = Inicio.id_usuario;
                        oUsuario.Borrar();
                        RefrescarGrilla();
                        break;

                    case "btnSalir":
                        this.Close();
                        break;
                }//end switch
                this.txtBuscar.Text = "";
                this.txtBuscar.Focus();
            }//end try
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtBuscar.Text))
            {
                this.txtBuscar.Text = "";
            }
            odt = oUsuario.Buscar_2(this.txtBuscar.Text);
            this.dgvUsuario.DataSource = odt;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Environment.NewLine)
            {
                this.btnModificar.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Botones_click(sender, e);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Botones_click(sender, e);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Botones_click(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Botones_click(sender, e);
        }

        private void frmAbmUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

    }
}
