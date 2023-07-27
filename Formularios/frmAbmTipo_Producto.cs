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
    public partial class frmAbmTipo_Producto : Form
    {
        public frmAbmTipo_Producto()
        {
            InitializeComponent();
        }

        Clase.clsTipo_Producto oTipo_Producto = new Clase.clsTipo_Producto();
        DataTable odt = null;

        private void frmAbmTipo_Producto_Load(object sender, EventArgs e)
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
            odt = oTipo_Producto.GetAll_2();
            this.dgvTipoProducto.DataSource = odt;
            this.dgvTipoProducto.Columns[0].Visible = false;
            this.dgvTipoProducto.AllowUserToAddRows = false;
        }

        private void dgvTipoProducto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                 bool res = int.TryParse(this.dgvTipoProducto[0, this.dgvTipoProducto.CurrentRow.Index].Value.ToString(), out Inicio.id_tipo_producto );
                this.lblid_pk.Text = Convert.ToString(Inicio.id_tipo_producto);
            }
            catch { }
        }

        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleTipo_Producto frmDetalles = new frmDetalleTipo_Producto();
            btntemp = (Button)sender;

            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.BanderaTipo_Producto = 1;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.BanderaTipo_Producto = 2;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro Nro:" + Inicio.id_tipo_producto,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        oTipo_Producto.pid_tipo_producto = Inicio.id_tipo_producto;
                        oTipo_Producto.Borrar();
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
            odt = oTipo_Producto.Buscar(this.txtBuscar.Text);
            this.dgvTipoProducto.DataSource = odt;
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
            Botones_click(sender,e);
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

        private void frmAbmTipo_Producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }



    }
}
