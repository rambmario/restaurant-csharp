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
    public partial class frmDetalleUsuario : Form
    {
        public frmDetalleUsuario()
        {
            InitializeComponent();
            CargarComboGrupoUsuario();
        }

        Clase.clsUsuario ousuario = new Clase.clsUsuario();
        Clase.clsGrupo_Usuario ogrupoUsuario = new Clase.clsGrupo_Usuario();
        frmAbmUsuario frmabm = new frmAbmUsuario();
        

        private void frmDetalleUsuario_Load(object sender, EventArgs e)
        {
            if (Inicio.BanderaUsuario == 1)
            {
                LimpiarControles();
            }
            else
            {
                ObtenerDatos();
            }
            this.txtnombre_usuario.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }




        //definicion de Metodos utiles.



        //metodo para obtener los valores de Grupo Usuario
        private void CargarComboGrupoUsuario() 
        {
            DataTable odt = new DataTable();
            odt = ogrupoUsuario.GetCmb();
            cmbgrupo_usuario.DataSource = odt;
            cmbgrupo_usuario.DisplayMember = "nombre_grupo_usuario";
            cmbgrupo_usuario.ValueMember = "id_grupo_usuario";

        }
        
        private void LimpiarControles()
        {
            this.txtnombre_usuario.Text = "";
            this.txtmail.Text = "";
            this.txtPassword.Text = "";
            this.cmbgrupo_usuario.SelectedItem = null;
        }

        private void AsignarDatos()
        {
            ousuario.pnombre_usuario = this.txtnombre_usuario.Text;
            ousuario.ppassword_usuario = this.txtPassword.Text;
            ousuario.pmail = this.txtmail.Text;
            ousuario.pid_grupo_usuario = Convert.ToInt32(cmbgrupo_usuario.SelectedValue);
        }

        private void ObtenerDatos()
        {
            ousuario.GetOne(Inicio.id_usuario);
            this.txtnombre_usuario.Text = ousuario.pnombre_usuario;
            ousuario.pid_usuario = Inicio.id_usuario;
            this.txtmail.Text = ousuario.pmail;
            this.txtPassword.Text = ousuario.ppassword_usuario;
            cmbgrupo_usuario.SelectedValue = ousuario.pid_grupo_usuario;
        }
        private void SoloLectura()
        {
            this.txtnombre_usuario.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.txtPassword.Enabled = false;
            this.txtmail.Enabled = false;
            this.cmbgrupo_usuario.Enabled = false;
        }



        //Eventos y acciones

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validaciones.
            //validar que el combobox contenga un valor correcto y que no este vacio
            if (cmbgrupo_usuario.SelectedItem == null)
            {

                MessageBox.Show("Llenar El Combo Con datos Correctos");
                cmbgrupo_usuario.Focus();
                return;
            }
            //validar que las cajas de texto no esten vacias
            if (string.IsNullOrEmpty(txtnombre_usuario.Text) | string.IsNullOrEmpty(txtmail.Text) | string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_usuario.Focus();
                return;
            }



            //creacion o modificacion de la tabla
            try
            {
                this.AsignarDatos();
                if (ousuario.Exist())
                {

                    if (Inicio.BanderaUsuario == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.BanderaUsuario == 2)
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

                switch (Inicio.BanderaUsuario)
                {
                        //INGRESA UNO NUEVO
                    case 1:
                        ousuario.Insertar();
                        ((frmAbmUsuario)this.Owner).RefrescarGrilla();
                        LimpiarControles();
                        this.txtnombre_usuario.Focus();
                        break;
                        //MODIFICA UNO EXISTENTE
                    case 2:
                        ousuario.Modificar();
                        this.Close();
                        break;
                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch        
               
            
        }

        private void btnBuscarGrupoUsuario_Click(object sender, EventArgs e)
        {
            frmAbmGrupo_Usuario frmgrupo = new frmAbmGrupo_Usuario();
            frmgrupo.ShowDialog();
            CargarComboGrupoUsuario();
            this.cmbgrupo_usuario.Focus();
            this.cmbgrupo_usuario.Text = "";
        }



        //Tabulaciones y Validaciones (metodos)


        //valida si esta ingresando numeros y ademas que solo tenga una unica coma.
        public void TabularDecimales(object sender, KeyPressEventArgs e) 
        {
            TextBox txttemp = new TextBox();
            txttemp = (TextBox)sender;

            //pregunta si se presiono la tecla "."
            if (e.KeyChar.ToString() == ".")
            {
                //pregunta si ya contiene alguna coma. si la contiene no deja ingresar otra
                if (txttemp.Text.Contains(','))
                {
                    e.Handled = false;
                }
                //de lo contrario si no la contiene y se presiono punto. cambia el punto por coma
                // y lo muestra
                else 
                {
                    e.Handled = true;
                    txttemp.Text += ",";
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                
            }
            if (txttemp.Text.Contains(',') || txttemp.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                
            }
            
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == ',' || e.KeyChar == '\b' || e.KeyChar == '.')
                {
                    e.Handled = false;
                }
            }
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }




        //metodo que permite validar si es un numero y ademas colocarle a el 4,8
        public void TabularNumeros(object sender, KeyPressEventArgs e) 
        {
            //ValidarNumero(sender,e);
            TextBox txttemp = new TextBox();
            txttemp = (TextBox)sender;

            //if encargado de validar numero unicamente
            string cadena = "0123456789";
            if (!cadena.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
            //if encargado de poder utilizar Back Space
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)(Keys.Enter))
            {
                switch (txttemp.Name)
                {
                    case "txtNumero_4":
                        this.txtNumero_4.Text = Inicio.CompletarCeros(this.txtNumero_4.Text, 4);
                        txttemp.MaxLength = 4;
                        break;

                    case "txtNumero_8":
                        this.txtNumero_8.Text = Inicio.CompletarCeros(this.txtNumero_8.Text, 8);
                        txttemp.MaxLength = 8;
                        break;
                }

                this.SelectNextControl(this.ActiveControl, true, true, true, true);

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


        //implementacion de los metodos en sus respectivos lugares.



        //el metodo de tabulacion de combo debe ser implementado personalmente a cada combo
        //debido a que si ambos codigos estan a nivel formulario la tabulacion funciona erroneamente
        public void TabularCombobox(object sender, KeyEventArgs e)
        {
            //al igual que el textbox solo que en ves de tener un keychar se utiliza el keyvalues
            if (e.KeyValue == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtnombre_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //por motivos de que si se tabulaba en el formulario. las cajas de 4,8 no llenaban con 0
            //dado que primero tabulaba con el metodo a nivel formulario entonces nunca entraba a preguntar
            //por los ceros a completar.
            TabularTextBox(sender,e);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);     
        }

        private void txtmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void txtNumero_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularNumeros(sender, e);
        }

        
        private void cmbgrupo_usuario_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender, e);
        }

        private void txtNumero_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularNumeros(sender,e);
        }

        ////forma de implementar la tabulacion a todo los Textbox sin necesidad de llamarlos uno por uno
        ////se ingresa un metodo que trabaje con keypress pero a nivel Formulario
        //private void frmDetalleUsuario_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //se le asigna la tecla que realizara la accion de tabulacion
        //    //if (e.KeyChar == (char)(Keys.Enter))
        //    //{
        //    //    //se asigna el valor y la funcion que va a tomar esa tecla.
        //    //    e.Handled = true;
        //    //    this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    //}

        //}
        //private bool ValidarTextBox()
        //{
        //    //Valida si los Textbox esta con datos
        //    bool bandera = false;
        //    //pregunta si txtnombremesa esta vacia, es null o solo esta 
        //    //compuesta por espacios en blanco.
        //    if (!string.IsNullOrEmpty(txtnombre_usuario.Text) | !string.IsNullOrEmpty(txtmail.Text) | !string.IsNullOrEmpty(txtPassword.Text))
        //    {
        //        bandera = true;
        //    }
        //    else { bandera = false; }
        //    return bandera;
        //}

        
    }
}
