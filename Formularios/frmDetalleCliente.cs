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
    public partial class frmDetalleCliente : Form
    {
        public frmDetalleCliente()
        {
            InitializeComponent();
            CargarComboCondicion_iva();
            CargarComboTipo_dni();
        }
        Clase.clsCliente ocliente = new Clase.clsCliente();
        Clase.clsCondicion_Iva oCondicion_Iva = new Clase.clsCondicion_Iva();
        Clase.clsTipo_dni oTipo_dni = new Clase.clsTipo_dni();



        private void frmDetalleCliente_Load(object sender, EventArgs e)
        {
            if (Inicio.Bandera_Cliente == 1)
                LimpiarControles();
            else
                try
                {
                    ObtenerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);   
                }
                

            this.txtnombre_cliente.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        //definicion de Metodos utiles.

        private void CargarComboCondicion_iva()
        {
            DataTable odt = new DataTable();
            odt = oCondicion_Iva.GetCmb();
            cmbCondicion_iva.DataSource = odt;
            cmbCondicion_iva.DisplayMember = "nombre_condicion_iva";
            cmbCondicion_iva.ValueMember = "id_condicion_iva";
            if (this.cmbCondicion_iva.SelectedIndex >= 0)
            {
                this.cmbCondicion_iva.SelectedIndex = 0;
                Inicio.id_condicion_iva = Convert.ToInt32(cmbCondicion_iva.SelectedValue);
            }

        }

        private void CargarComboTipo_dni()
        {
            DataTable odt = new DataTable();
            odt = oTipo_dni.GetCmb();
            cmbTipo_dni.DataSource = odt;
            cmbTipo_dni.DisplayMember = "nombre_Tipo_dni";
            cmbTipo_dni.ValueMember = "id_Tipo_dni";
            if (this.cmbTipo_dni.SelectedIndex >= 0)
            {
                this.cmbTipo_dni.SelectedIndex = 0;
                Inicio.id_Tipo_dni = Convert.ToInt32(cmbTipo_dni.SelectedValue);
            }

        }

        private void LimpiarControles()
        {
            this.txtnombre_cliente.Text = "";
            this.txtapellido_cliente.Text = "";
            this.txtTelefono_fijo.Text = "-";
            this.txtTelefono_movil.Text = "-";
            this.txtDireccion.Text = "";
            this.txtCorreo.Text = "";
            this.cmbCondicion_iva.Text = "";
            this.cmbTipo_dni.Text = "";
            this.txtNumero_dni_cuit.Text = "";
        }

        private void AsignarDatos()
        {
            ocliente.pnombre = this.txtnombre_cliente.Text;
            ocliente.papellido = this.txtapellido_cliente.Text;
            ocliente.ptelefono_fijo = this.txtTelefono_fijo.Text;
            ocliente.ptelefono_movil = this.txtTelefono_movil.Text;
            ocliente.pdireccion = this.txtDireccion.Text;
            ocliente.pcorreo = this.txtCorreo.Text;
            ocliente.pid_condicion_iva = Convert.ToInt32(this.cmbCondicion_iva.SelectedValue);
            ocliente.pid_tipo_dni= Convert.ToInt32(this.cmbTipo_dni.SelectedValue);
            ocliente.pnumero_dni_cuit = this.txtNumero_dni_cuit.Text;
        }

        private void ObtenerDatos()
        {
            ocliente.GetOne(Inicio.id_cliente);
            this.txtnombre_cliente.Text = ocliente.pnombre;
            this.txtapellido_cliente.Text = ocliente.papellido;
            ocliente.pid_cliente = Inicio.id_cliente;
            this.txtDireccion.Text = ocliente.pdireccion;
            this.txtTelefono_fijo.Text = ocliente.ptelefono_fijo;
            this.txtTelefono_movil.Text = ocliente.ptelefono_movil;
            this.txtCorreo.Text = ocliente.pcorreo;
            this.cmbCondicion_iva.SelectedValue = ocliente.pid_condicion_iva;
            this.cmbTipo_dni.SelectedValue = ocliente.pid_tipo_dni;
            this.txtNumero_dni_cuit.Text = ocliente.pnumero_dni_cuit;
        }
        private void SoloLectura()
        {
            this.txtnombre_cliente.Enabled = false;
            this.txtapellido_cliente.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.txtTelefono_movil.Enabled = false;
            this.txtTelefono_fijo.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtCorreo.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            //validar que las cajas de texto no esten vacias

            if (string.IsNullOrEmpty(txtapellido_cliente.Text) | string.IsNullOrEmpty(txtnombre_cliente.Text)
                    | string.IsNullOrEmpty(this.txtTelefono_movil.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_cliente.Focus();
                return;
            }
            if (Inicio.id_condicion_iva == 0)
            {
                MessageBox.Show("Debe completar el campo condicion iva", "Aletar", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                cmbCondicion_iva.Focus();
                return;
            }

            if (Inicio.id_Tipo_dni == 0)
            {
                MessageBox.Show("Debe completar el campo tipo dni", "Aletar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbTipo_dni.Focus();
                return;
            }

            //creacion o modificacion de la tabla
            try
            {
                this.AsignarDatos();
                if (ocliente.Exist())
                {

                    if (Inicio.Bandera_Cliente == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.Bandera_Cliente == 2)
                        {
                            if (MessageBox.Show("Sr. Usuario: Los Datos que Desea Modificar ya Existen ¿Desea Reemplazarlos?",
                                "MODIFICAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.No)
                            {
                                return;
                            }

                        }
                    }//end else
                }

                switch (Inicio.Bandera_Cliente)
                {
                    //INGRESA UNO NUEVO
                    case 1:
                        ocliente.Insertar();
                        ((frmAbmCliente)this.Owner).RefrescarGrilla();
                        LimpiarControles();
                        this.txtnombre_cliente.Focus();
                        break;
                    //MODIFICA UNO EXISTENTE
                    case 2:
                        ocliente.Modificar();
                        this.Close();
                        break;
                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch    
        }

        private void cmbCondicion_iva_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_condicion_iva = Convert.ToInt32(this.cmbCondicion_iva.SelectedValue);
            }
            catch (Exception)
            {
            }
        }

        private void cmbTipo_dni_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_Tipo_dni = Convert.ToInt32(this.cmbTipo_dni.SelectedValue);
            }
            catch (Exception)
            {
            }
        }

        private void TabularTextBox(object sender, KeyPressEventArgs e)
        {
            //se le asigna la tecla que realizara la accion de tabulacion
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
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

        private void txtnombre_cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void txtapellido_cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }

        private void txtTelefono_fijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }

        private void txtTelefono_movil_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }


        private void txtNumero_dni_cuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }

        private void cmbCondicion_iva_KeyDown_1(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender, e);
        }

        private void cmbTipo_dni_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender, e);
        }
    }
}
