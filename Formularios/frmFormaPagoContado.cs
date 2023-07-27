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
    public partial class frmFormaPagoContado : Form
    {
        public frmFormaPagoContado()
        {
            InitializeComponent();
        }
        Clase.clsPago_Pedido opago_pedido = new Clase.clsPago_Pedido();
        private void frmFormaPagoContado_Load(object sender, EventArgs e)
        {
            this.Location = ((frmPago)this.Owner).lbllocalizacion.Location;
            Inicio.id_forma_pago = 2;
            this.txtPago_venta.Focus();
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.MinimizeBox = false;
                
            //this.BackgroundImage = Properties.Resources.Fondo;

            //dandole color a los botones
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtPago_venta.Text == "") 
            {
                return;
            }
            opago_pedido.pid_forma_pago = Inicio.id_forma_pago;
            opago_pedido.pid_pedido = Inicio.id_pedido;
            opago_pedido.pimporte = Convert.ToDouble(this.txtPago_venta.Text);
            opago_pedido.pid_caja = Inicio.parametro_id_caja;
            opago_pedido.Insertar();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPago_venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularDecimales(sender,e);
        
        }
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
                    SendKeys.Send("{END}");
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

        private void frmFormaPagoContado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
 
    }
}
