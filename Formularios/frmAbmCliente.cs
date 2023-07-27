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
    public partial class frmAbmCliente : Form
    {
        public frmAbmCliente()
        {
            InitializeComponent();
        }
        Clase.clsCliente ocliente = new Clase.clsCliente();
        DataTable odt = null;
        private void frmAbmCliente_Load(object sender, EventArgs e)
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
            odt = ocliente.GetAll_2();
            this.dgvcliente.DataSource = odt;
            this.dgvcliente.Columns[0].Visible = false;
            this.dgvcliente.AllowUserToAddRows = false;
        }

        private void dgvOpcionModificacionProducto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                bool res = int.TryParse(this.dgvcliente[0, this.dgvcliente.CurrentRow.Index].Value.ToString(), out Inicio.id_cliente );
                this.lblid_pk.Text = Convert.ToString(Inicio.id_cliente);
                this.txtNombre_cliente.Text = Convert.ToString(this.dgvcliente["apellido" , this.dgvcliente.CurrentRow.Index].Value) + " " + Convert.ToString(this.dgvcliente["nombre", this.dgvcliente.CurrentRow.Index].Value.ToString());

            }
            catch { }
        }
        //metodo para identificar el tipo de boton clickeado
        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleCliente frmDetalles = new frmDetalleCliente();
            btntemp = (Button)sender;

            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.Bandera_Cliente = 1;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.Bandera_Cliente = 2;
                        this.AddOwnedForm(frmDetalles);
                        frmDetalles.ShowDialog();
                        RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro Nro:" + Inicio.id_cliente,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        ocliente.pid_cliente = Inicio.id_cliente;
                        ocliente.Borrar();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtBuscar.Text))
            {
                this.txtBuscar.Text = "";
            }
            odt = ocliente.Find_2(this.txtBuscar.Text);
            this.dgvcliente.DataSource = odt;
        }

        private void frmAbmCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Environment.NewLine)
            {
                this.btnModificar.Focus();
            }
        }

        private void dgvcliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Inicio.Bandera_id_cliente = Convert.ToInt32(this.lblid_pk.Text);
            Inicio.Bandera_nombre_cliente = txtNombre_cliente.Text;
            this.Close();
        }
    }
}
