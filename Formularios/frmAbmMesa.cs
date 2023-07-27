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
    public partial class frmAbmMesa : Form
    {
        public frmAbmMesa()
        {
            InitializeComponent();
        }
        //Entidades.entMesa oMesa = new Entidades.entMesa();
        Clase.clsMesa oMesa = new Clase.clsMesa();
        //Conexion conex = new Conexion();
        DataTable odt = null;
        //public static int Inicio.id_mesa = 0;
        //public string nombre_mesa = "";
        //public static int BanderaMesa = 0;

        private void frmAbmMesa_Load(object sender, EventArgs e)
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
            odt = oMesa.GetAll();
            this.dgvMesa.DataSource = odt;
            this.dgvMesa.Columns[0].Visible = false;
            this.dgvMesa.Columns["id_reserva"].Visible = false;
            this.dgvMesa.Columns["grupo_mesa"].Visible = false;
            this.dgvMesa.Columns["cantidad_persona"].HeaderText = "Cantidad";
            this.dgvMesa.AllowUserToAddRows = false;
        }

        private void dgvMesa_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                 bool res = int.TryParse(this.dgvMesa[0, this.dgvMesa.CurrentRow.Index].Value.ToString(), out Inicio.id_mesa );
                this.lblID_PK.Text = Convert.ToString(Inicio.id_mesa);
            }
            catch { }
        }


        //metodo para identificar el tipo de boton clickeado
        private void Botones_click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            frmDetalleMesa frmDetalles = new frmDetalleMesa();
            btntemp = (Button)sender;
          
            try
            {
                switch (btntemp.Name)
                {
                    case "btnAgregar":
                        Inicio.BanderaMesa = 1;
                        this.AddOwnedForm(frmDetalles);
                        //oMesas.InsertarMesa();
                        frmDetalles.ShowDialog();
                        break;

                    case "btnModificar":
                        Inicio.BanderaMesa = 2;
                        this.AddOwnedForm(frmDetalles);
                        //  oMesas.Modificar(Convert.ToInt32(this.lblid_pk.Text));
                        frmDetalles.ShowDialog();
                        RefrescarGrilla();
                        break;

                    case "btnBorrar":
                        if (MessageBox.Show("Desea Realmente Eliminar el Registro nro:" + Inicio.id_mesa,
                            "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                        oMesa.pid_mesa = Inicio.id_mesa;
                        oMesa.Borrar();
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
            odt = oMesa.Buscar(this.txtBuscar.Text);
            this.dgvMesa.DataSource = odt;
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

        private void frmAbmMesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }
}
