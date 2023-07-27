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
    public partial class frmAbmGrupo_Usuario : Form
    {
        public frmAbmGrupo_Usuario()
        {
            InitializeComponent();
        }
        Clase.clsGrupo_Usuario ogrupousuario = new Clase.clsGrupo_Usuario();
        DataTable odt = null;
        private void frmAbmGrupo_Usuario_Load(object sender, EventArgs e)
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
            odt = ogrupousuario.GetAll();
            this.dgvGrupoUsuario.DataSource = odt;
            this.dgvGrupoUsuario.Columns[0].Visible = false;
            this.dgvGrupoUsuario.AllowUserToAddRows = false;
        }

        private void dgvGrupoUsuario_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                bool res = int.TryParse(this.dgvGrupoUsuario[0, this.dgvGrupoUsuario.CurrentRow.Index].Value.ToString(), out Inicio.id_grupo_usuario );
                this.lblid_pk.Text = Convert.ToString(Inicio.id_grupo_usuario);
            }
            catch { }
        }

        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleGrupo_Usuario frmDetalles = new frmDetalleGrupo_Usuario();
            btntemp = (Button)sender;

            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.BanderaGrupo_Usuario = 1;
                        this.AddOwnedForm(frmDetalles);
                        //oMesas.InsertarMesa();
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.BanderaGrupo_Usuario = 2;
                        this.AddOwnedForm(frmDetalles);
                        //  oMesas.Modificar(Convert.ToInt32(this.lblid_pk.Text));
                        frmDetalles.ShowDialog();
                        this.RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro nro:" + Inicio.id_grupo_usuario,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        ogrupousuario.pid_usuario = Inicio.id_grupo_usuario;
                        ogrupousuario.Borrar();
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
            odt = ogrupousuario.Buscar(this.txtBuscar.Text);
            this.dgvGrupoUsuario.DataSource = odt;
        }

        private void frmAbmGrupo_Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }


    }//end inicio
}
