using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion_gastronomica.Formularios
{
    public partial class frmAbmBanco : Form
    {
        public frmAbmBanco()
        {
            InitializeComponent();
        }
        Clase.clsBanco oBanco = new Clase.clsBanco();
        DataTable odt = null;
        private void frmAbmBanco_Load(object sender, EventArgs e)
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
            odt = oBanco.GetAll();
            this.dgvBanco.DataSource = odt;
            this.dgvBanco.Columns[0].Visible = false;
            this.dgvBanco.Columns[1].HeaderText = "Banco";
            this.dgvBanco.AllowUserToAddRows = false;
        }

        private void dgvGrupoUsuario_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                 bool res = int.TryParse(this.dgvBanco[0, this.dgvBanco.CurrentRow.Index].Value.ToString(), out Inicio.id_banco );
                this.lblid_pk.Text = Convert.ToString(Inicio.id_banco);
            }
            catch { }
        }

        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleBanco frmDetalles = new frmDetalleBanco();
            btntemp = (Button)sender;

            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.Bandera_Banco = 1;
                        this.AddOwnedForm(frmDetalles);
                        //oMesas.InsertarMesa();
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.Bandera_Banco = 2;
                        this.AddOwnedForm(frmDetalles);
                        //  oMesas.Modificar(Convert.ToInt32(this.lblid_pk.Text));
                        frmDetalles.ShowDialog();
                        this.RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro nro:" + Inicio.id_banco,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        oBanco.pid_banco = Inicio.id_banco;
                        oBanco.Borrar();
                        this.RefrescarGrilla();
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

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Environment.NewLine)
            {
                this.btnModificar.Focus();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtBuscar.Text))
            {
                this.txtBuscar.Text = "";
            }
            odt = oBanco.Buscar(this.txtBuscar.Text);
            this.dgvBanco.DataSource = odt;
        }

        private void frmAbmBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }
}
