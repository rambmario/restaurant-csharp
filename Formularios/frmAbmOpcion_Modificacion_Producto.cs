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
    public partial class frmAbmOpcion_Modificacion_Producto : Form
    {
        public frmAbmOpcion_Modificacion_Producto()
        {
            InitializeComponent();
        }
        Clase.clsOpcion_Modificacion_Producto oopcion_modificacion_producto = new Clase.clsOpcion_Modificacion_Producto();
        DataTable odt = null;
        private void frmAbmOpcion_Modificacion_Producto_Load(object sender, EventArgs e)
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
            odt = oopcion_modificacion_producto.GetAll_2();
            this.dgvOpcionModificacionProducto.DataSource = odt;
            this.dgvOpcionModificacionProducto.Columns[0].Visible = false;
            this.dgvOpcionModificacionProducto.AllowUserToAddRows = false;
        }

        private void dgvOpcionModificacionProducto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                 bool res = int.TryParse(this.dgvOpcionModificacionProducto[0, this.dgvOpcionModificacionProducto.CurrentRow.Index].Value.ToString(), out Inicio.id_Opcion_Modificacion_producto );
                this.lblid_pk.Text = Convert.ToString(Inicio.id_Opcion_Modificacion_producto);
            }
            catch { }
        }

        //metodo para identificar el tipo de boton clickeado
        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleOpcion_Modificacion_Producto frmDetalles = new frmDetalleOpcion_Modificacion_Producto();
            btntemp = (Button)sender;

            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.BanderaOpcion_modificacion_producto = 1;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.BanderaOpcion_modificacion_producto = 2;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro Nro:" + Inicio.id_Opcion_Modificacion_producto,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        oopcion_modificacion_producto.pid_opcion_modificacion_producto = Inicio.id_Opcion_Modificacion_producto;
                        oopcion_modificacion_producto.Borrar();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtBuscar.Text))
            {
                this.txtBuscar.Text = "";
            }
            odt = oopcion_modificacion_producto.Buscar_2(this.txtBuscar.Text);
            this.dgvOpcionModificacionProducto.DataSource = odt;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Environment.NewLine)
            {
                this.btnModificar.Focus();
            }
        }

        private void frmAbmOpcion_Modificacion_Producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }
}
