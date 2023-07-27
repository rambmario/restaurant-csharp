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
    public partial class frmAbmProducto : Form
    {
        public frmAbmProducto()
        {
            InitializeComponent();
            CargarComboGrupoProducto();
        }

        Clase.clsProducto oproducto = new Clase.clsProducto();
        Clase.clsGrupo_Producto ogrupo_producto = new Clase.clsGrupo_Producto();
        DataTable odt = null;

        private void frmAbmProducto_Load(object sender, EventArgs e)
        {
            RefrescarGrilla();
            this.CancelButton = this.btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.txtBuscar.Focus();
        }

        private void CargarComboGrupoProducto()
        {
            DataTable odt = new DataTable();
            odt = ogrupo_producto.GetCmb();
            cmbGrupo_producto.DataSource = odt;
            cmbGrupo_producto.DisplayMember = "nombre_grupo_producto";
            cmbGrupo_producto.ValueMember = "id_grupo_producto";
            if (this.cmbGrupo_producto.SelectedIndex > 0)
            {
                cmbGrupo_producto.SelectedIndex = 0;
                Inicio.id_grupo_Producto = Convert.ToInt32(cmbGrupo_producto.SelectedValue);
            }

        }

        public void RefrescarGrilla()
        {
            DataTable odt = null;
            if (this.chkFitroGrupo.Checked)
                odt = oproducto.GetAll_Grupo(Inicio.id_grupo_Producto);
            else
                odt = oproducto.GetAll_2();
            
            this.dgvProducto.DataSource = odt;
            this.dgvProducto.Columns[0].Visible = false;
            this.dgvProducto.AllowUserToAddRows = false;
        }

        private void dgvProducto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Boolean a = int.TryParse(this.dgvProducto[0, this.dgvProducto.CurrentRow.Index].Value.ToString(), out Inicio.id_Producto);
                this.lblid_pk.Text = Convert.ToString(Inicio.id_Producto);
            }
            catch { }
        }

        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleProducto frmDetalles = new frmDetalleProducto();
            btntemp = (Button)sender;
            int i = 0;
            try
            {
                 i = this.dgvProducto.CurrentRow.Index;
            }
            catch (Exception)
            {

                 i = 0;
            }
            
            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.BanderaProducto = 1;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.BanderaProducto = 2;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        RefrescarGrilla();
                        this.dgvProducto.CurrentCell = this.dgvProducto.Rows[i].Cells[1];
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro Nro:" + Inicio.id_Producto,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        oproducto.pid_producto = Inicio.id_Producto;
                        oproducto.Borrar();
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
            odt = oproducto.Buscar_2(this.txtBuscar.Text);
            this.dgvProducto.DataSource = odt;
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

        private void frmAbmProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        public void TabularCombobox(object sender, KeyEventArgs e)
        {
            //al igual que el textbox solo que en ves de tener un keychar se utiliza el keyvalues
            if (e.KeyValue == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void cmbGrupo_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_grupo_Producto = Convert.ToInt32(this.cmbGrupo_producto.SelectedValue);
                RefrescarGrilla();
            }
            catch (Exception)
            {
            }
        }

        private void chkFitroGrupo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFitroGrupo.Checked)
                this.cmbGrupo_producto.Enabled = true;
            else
                this.cmbGrupo_producto.Enabled = false;
            RefrescarGrilla();
        }

        private void TabularTextBox(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
            //se le asigna la tecla que realizara la accion de tabulacion
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducto.CurrentCell.ColumnIndex == 6)
            {
                int i = this.dgvProducto.CurrentRow.Index;

                frmActualizarPrecioProducto var = new frmActualizarPrecioProducto(Convert.ToDouble(dgvProducto.Rows[e.RowIndex].Cells[6].Value.ToString()));
                var.ShowDialog();
                RefrescarGrilla();
                this.dgvProducto.CurrentCell = this.dgvProducto.Rows[i].Cells["Precio"];
            }
        }

        private void btnActualizar_porcentaje_Click(object sender, EventArgs e)
        {
            if (this.txtPorcentaje.Text == "")
                return;
            foreach (DataGridViewRow item in dgvProducto.Rows)
            {
                //Monto * (100 + porcentaje) / 100 
                oproducto.GetOne(Convert.ToInt32(item.Cells[0].Value));
                oproducto.pid_producto = Convert.ToInt32(item.Cells[0].Value);
                oproducto.pprecio = oproducto.pprecio * (100 + Convert.ToInt32(this.txtPorcentaje.Text)) / 100;
                oproducto.Modificar();
            }
            RefrescarGrilla();
        }

        private void dgvProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = this.dgvProducto.CurrentRow.Index;

                frmActualizarPrecioProducto var = new frmActualizarPrecioProducto(Convert.ToDouble(dgvProducto.Rows[i].Cells[6].Value.ToString()));
                var.ShowDialog();
                RefrescarGrilla();
                this.dgvProducto.CurrentCell = this.dgvProducto.Rows[i].Cells["Precio"];
            }
        }

        private void dgvProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        //private void dgvProducto_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgvProducto.CurrentCell.ColumnIndex == 6)
        //    {
        //
        //    }
        //}



    }
}
