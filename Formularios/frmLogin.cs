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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.txtPassword.PasswordChar = '*';
        }

        Clase.clsUsuario usuario = new Clase.clsUsuario();
        Clase.clsCaja ocaja = new Clase.clsCaja();
        frmMain main = new frmMain();
        public int id = 0;
        public string nombre_usuario = "";
        public string password = "";
        public int id_grupo = 0;
        public string mail = "";
       

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario.ppassword_usuario = this.txtPassword.Text;
                usuario.pnombre_usuario = this.txtUsuario.Text;

                if (usuario.Logon() == true)
                {
                    Inicio.parametro_id_usuario_inicio = usuario.LogonID();
                    if (ocaja.UltimoID() == 0)
                    {
                        Primera_Caja();
                        Inicio.parametro_id_caja = ocaja.pid_caja;
                    }
                    else 
                    {
                        Inicio.parametro_id_caja = ocaja.UltimoID();
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else 
                {
                    MessageBox.Show("Usuario o Password Incorrecta");
                    this.txtUsuario.Focus();
                }
                
                

            }
            catch
            {
                MessageBox.Show("Usuario o Password Incorrecta");
                txtUsuario.Focus();
            }
            
        }

       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventArgs ea = new EventArgs();
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
                e.Handled = true;
                btnAceptar_Click(sender,ea);
            }

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }
        private void Primera_Caja()
        {
            //en el caso de que nunca se haya registrado una caja
            DataTable odt_inicial = ocaja.GetAll();
            if (odt_inicial.Rows.Count == 0)
            {
                ocaja.pfecha_caja = DateTime.Now;
                ocaja.pcerrada = false;
                ocaja.pdetalle = "Primera caja Auto Iniciada";
                ocaja.pid_usuario = Inicio.parametro_id_usuario_inicio;
                ocaja.Insertar();
            }
        }
    }
}
