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
    public partial class frmConsultaProducto : Form
    {
        public frmConsultaProducto()
        {
            InitializeComponent();
            CargarComboGrupoProducto();
            CargarComboTipoProducto();
        }

        Clase.clsProducto oproducto = new Clase.clsProducto();
        Clase.clsTipo_Producto otipo_producto = new Clase.clsTipo_Producto();
        Clase.clsGrupo_Producto ogrupo_producto = new Clase.clsGrupo_Producto();

        private void frmConsultaProducto_Load(object sender, EventArgs e)
        {
            this.cmbGrupo_producto.Text = "";
            this.txtnombre_producto.Focus();
        }

        private void RefrescarGrilla() 
        {
            DataTable odt = null;
            odt = oproducto.GetConsultaMaestra(Convert.ToInt32(this.cmbGrupo_producto.SelectedValue),Convert.ToInt32(this.cmbtipo_producto.SelectedValue), 
                                                this.txtnombre_producto.Text,chkGrupo_producto.Checked,this.chkTipo_producto.Checked);
            this.dgvproducto.DataSource = odt;
            this.dgvproducto.Columns[0].Visible = false;
            this.dgvproducto.AllowUserToAddRows = false;
        }

        private void CargarComboTipoProducto()
        {
            DataTable odt = new DataTable();
            odt = otipo_producto.GetCmb_2(Inicio.id_grupo_Producto);
            cmbtipo_producto.DataSource = odt;
            cmbtipo_producto.DisplayMember = "nombre_tipo_producto";
            cmbtipo_producto.ValueMember = "id_tipo_producto";
            if (this.cmbtipo_producto.SelectedIndex >= 0)
            {
                this.cmbtipo_producto.SelectedIndex = 0;
                Inicio.id_tipo_producto = Convert.ToInt32(cmbtipo_producto.SelectedValue);
            }

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

        private void cmbGrupo_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_grupo_Producto = Convert.ToInt32(this.cmbGrupo_producto.SelectedValue);
                CargarComboTipoProducto();
            }
            catch (Exception)
            {
            }
        }

        private void txtnombre_producto_TextChanged(object sender, EventArgs e)
        {
            this.btnActualizar.PerformClick();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.chkGrupo_producto.Checked == true && Convert.ToInt32(this.cmbGrupo_producto.SelectedValue) == 0 && this.cmbGrupo_producto.SelectedValue.GetType() != Type.GetType("System.Int32"))
                return;
            if (this.chkTipo_producto.Checked == true && Convert.ToInt32(this.cmbtipo_producto.SelectedValue) == 0 && this.cmbtipo_producto.SelectedValue.GetType() != Type.GetType("System.Int32"))
                return;
            if (string.IsNullOrEmpty(this.txtnombre_producto.Text))
                this.txtnombre_producto.Text = "";
            RefrescarGrilla();
        }

        private void dgvproducto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                bool res = int.TryParse(this.dgvproducto[0, this.dgvproducto.CurrentRow.Index].Value.ToString(), out Inicio.id_Producto );
                this.txtProducto.Text = Convert.ToString(this.dgvproducto[1, this.dgvproducto.CurrentRow.Index].Value.ToString());
            }
            catch (Exception)
            {
                Inicio.id_Producto = 0;
                this.txtProducto.Text = "";
            }

        }

        private void dgvproducto_DoubleClick(object sender, EventArgs e)
        {
            if (dgvproducto.RowCount == 0)
                return;
           bool res = int.TryParse(this.dgvproducto[0, this.dgvproducto.CurrentRow.Index].Value.ToString(), out Inicio.id_Producto );
            this.Close();
        }

        private void dgvproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvproducto.RowCount == 0)
                return;
            if (e.KeyCode == Keys.Enter)
            {
                bool res = int.TryParse(this.dgvproducto[0, this.dgvproducto.CurrentRow.Index].Value.ToString(), out Inicio.id_Producto );
                this.Close();
            }
        }

        private void txtnombre_producto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)(Keys.Enter))
                dgvproducto.Focus();
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
