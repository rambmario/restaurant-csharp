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
    public partial class frmDetalleMesa : Form
    {
        public frmDetalleMesa()
        {
            InitializeComponent();
        }
        
        Clase.clsMesa oMesa = new Clase.clsMesa();
        frmAbmMesa FrmAbm = new frmAbmMesa();

        private void frmDetalleMesa_Load(object sender, EventArgs e)
        {
            if (Inicio.BanderaMesa == 1)
            {
                LimpiarControles();
            }
            else 
            {
                ObtenerDatos();
            }
            this.txtCantidad_Persona.Text = "4";
            this.txtnombre_mesa.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void LimpiarControles()
        {
            this.txtnombre_mesa.Text = "";
            this.cmbestado.SelectedItem = null;
        }

        private void AsignarDatos()
        {
            oMesa.pnombre_mesa = this.txtnombre_mesa.Text;
            oMesa.pcantidad_persona = Convert.ToInt32(this.txtCantidad_Persona.Text);
            if (Inicio.BanderaMesa == 1)
            {
                oMesa.pestado = "Libre";
                oMesa.pid_reserva = 0;
                oMesa.pgrupo_mesa = 0;
            }
            else
            {
            }
            //oMesa.pestado = cmbestado.SelectedItem.ToString();
        }

        private void ObtenerDatos() 
        {
            oMesa.GetOne(Inicio.id_mesa);
            this.txtnombre_mesa.Text = oMesa.pnombre_mesa;
            oMesa.pid_mesa = Inicio.id_mesa;
            this.cmbestado.SelectedValue = oMesa.pestado;
            this.txtCantidad_Persona.Text = Convert.ToString(oMesa.pcantidad_persona);
        }
        private void SoloLectura() 
        {
            this.txtnombre_mesa.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.cmbestado.Enabled = false;
        }


        //BOTONES.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar que las cajas de texto no esten vacias
            if (string.IsNullOrEmpty(txtnombre_mesa.Text) | string.IsNullOrEmpty(txtCantidad_Persona.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_mesa.Focus();
                return;
            }
            //validar que el combobox contenga un valor correcto y que no este vacio
            //if (cmbestado.SelectedItem == null)
            //{

            //    MessageBox.Show("Llenar El Combo Con datos Correctos");
            //    cmbestado.Focus();
            //    return;
            //}
            try
            {
                this.AsignarDatos();
                if (oMesa.Exist())
                {

                    if (Inicio.BanderaMesa == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.BanderaMesa == 2)
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

                switch (Inicio.BanderaMesa)
                {
                    case 1:
                        oMesa.Insertar();
                        ((frmAbmMesa)this.Owner).RefrescarGrilla();
                        LimpiarControles();
                        this.txtnombre_mesa.Focus();
                        break;

                    case 2:
                        oMesa.Modificar();
                        this.Close();
                        break;
                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch


                
           
        }//end Boton Guardar

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //metodos de tabulaciones y validaciones...



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


        //implementacion de metodos a sus respectivos sitios...

        private void txtnombre_mesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void cmbestado_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender,e);
        }

        private void txtCantidad_Persona_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

    }
}
