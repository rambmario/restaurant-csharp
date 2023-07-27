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
    public partial class frmAbmGrupo_Producto : Form
    {
        public frmAbmGrupo_Producto()
        {
            InitializeComponent();
        }

        Clase.clsGrupo_Producto ogrupo_producto = new Clase.clsGrupo_Producto();
        DataTable odt = null; 

        private void frmAbmGrupo_Producto_Load(object sender, EventArgs e)
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
            odt = ogrupo_producto.GetAll();
            this.dgvGrupo_Producto.DataSource = odt;
            this.dgvGrupo_Producto.Columns[0].Visible = false;
            this.dgvGrupo_Producto.AllowUserToAddRows = false;
        }

        private void dgvGrupo_Producto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                bool res = int.TryParse(this.dgvGrupo_Producto[0, this.dgvGrupo_Producto.CurrentRow.Index].Value.ToString(), out Inicio.id_grupo_Producto );
                this.lblid_pk.Text = Convert.ToString(Inicio.id_grupo_Producto);
            }
            catch { }
        }

        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleGrupo_Producto frmDetalles = new frmDetalleGrupo_Producto();
            btntemp = (Button)sender;

            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.BanderaGrupo_Producto = 1;
                        this.AddOwnedForm(frmDetalles);
                        //oMesas.InsertarMesa();
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.BanderaGrupo_Producto = 2;
                        this.AddOwnedForm(frmDetalles);
                        //  oMesas.Modificar(Convert.ToInt32(this.lblid_pk.Text));
                        frmDetalles.ShowDialog();
                        this.RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro nro:" + Inicio.id_grupo_Producto,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        ogrupo_producto.pid_grupo_producto = Inicio.id_grupo_Producto;
                        ogrupo_producto.Borrar();
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
            odt = ogrupo_producto.Buscar(this.txtBuscar.Text);
            this.dgvGrupo_Producto.DataSource = odt;
        }

        private void frmAbmGrupo_Producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }
}
