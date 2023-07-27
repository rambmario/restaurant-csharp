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
    public partial class frmPasswordControl : Form
    {
        public frmPasswordControl()
        {
            InitializeComponent();
            this.txtPassword.PasswordChar = '*';
        }
        Clase.clsUsuario usuario = new Clase.clsUsuario();
        private void frmPasswordControl_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            var buttons = this.Controls.OfType<Button>();

            foreach (var button in buttons)
            {
                button.MouseDown += btn_MouseDown;
                button.MouseEnter += btn_MouseEnter;
                button.MouseLeave += btn_MouseLeave;
                button.MouseUp += btn_MouseUp;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackgroundImage = Properties.Resources._1button;
                //el resto
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

        #region -> Metodos Pintar Botones
        //dandole color a los botones
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources._1button_click;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources._1button_hover;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources._1button;
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources._1button_hover;
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario.ppassword_usuario = this.txtPassword.Text;

                if (usuario.PasswordMaster() == true)
                {
                    Inicio.parametro_PasswordMaster = 1;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password Incorrecta");
                    this.txtPassword.Focus();
                }



            }
            catch
            {
                MessageBox.Show("Password Incorrecta");
                txtPassword.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }
    }
}
