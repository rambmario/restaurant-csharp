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
    public partial class frmAbmOpcion_Modificacion : Form
    {
        public frmAbmOpcion_Modificacion()
        {
            InitializeComponent();
        }
        Clase.clsOpcion_Modificacion oOpcion_Modificacion = new Clase.clsOpcion_Modificacion();
        DataTable odt = null;
        private void frmOpcion_Modificacion_Load(object sender, EventArgs e)
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
            odt = oOpcion_Modificacion.GetAll();
            this.dgvOpcionModificacion.DataSource = odt;
            this.dgvOpcionModificacion.Columns[0].Visible = false;
            this.dgvOpcionModificacion.AllowUserToAddRows = false;
        }

        private void dgvOpcionModificacion_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                 bool res = int.TryParse(this.dgvOpcionModificacion[0, this.dgvOpcionModificacion.CurrentRow.Index].Value.ToString(), out Inicio.id_Opcion_Modificacion);
                this.lblid_pk.Text = Convert.ToString(Inicio.id_Opcion_Modificacion);
            }
            catch { }
        }

        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleOpcion_Modificacion frmDetalles = new frmDetalleOpcion_Modificacion();
            btntemp = (Button)sender;

            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.BanderaOpcion_modificacion = 1;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.BanderaOpcion_modificacion = 2;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        this.RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro nro:" + Inicio.id_Opcion_Modificacion,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        oOpcion_Modificacion.pid_opcion_modificacion = Inicio.id_Opcion_Modificacion;
                        oOpcion_Modificacion.Borrar();
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
            Botones_click(sender,e);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Botones_click(sender,e);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Botones_click(sender,e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Botones_click(sender,e);
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
            odt = oOpcion_Modificacion.Buscar(this.txtBuscar.Text);
            this.dgvOpcionModificacion.DataSource = odt;
        }

        private void frmAbmOpcion_Modificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }
}
