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
    public partial class frmFormaPagoTarjeta : Form
    {
        public frmFormaPagoTarjeta()
        {
            InitializeComponent();
        }
        Clase.clsPago_Pedido opago_pedido = new Clase.clsPago_Pedido();
        private void frmFormaPagoTarjeta_Load(object sender, EventArgs e)
        {
            this.Location = ((frmPago)this.Owner).lbllocalizacion.Location;
            this.txtpago_venta.Focus();
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

        private void txtpago_venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularDecimales(sender, e);
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            
            if(this.txtpago_venta.Text == "")
            {
                return;
            }
            if (Inicio.id_forma_pago == 0) 
            {
                return;
            }

            double total = Convert.ToDouble(((frmPago)this.Owner).txttotal.Text);
            double pago_parcial = Convert.ToDouble(((frmPago)this.Owner).txtPago.Text);
            double pago_total =Convert.ToDouble(this.txtpago_venta.Text) + pago_parcial;
            if(total < pago_total)
            {
                MessageBox.Show("El pago no puede ser mayor al monto total", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Stop);
                return;
            }

            opago_pedido.pid_forma_pago = Inicio.id_forma_pago;
            opago_pedido.pid_pedido = Inicio.id_pedido;
            opago_pedido.pimporte = Convert.ToDouble(txtpago_venta.Text);
            opago_pedido.pid_caja = Inicio.parametro_id_caja;
            opago_pedido.Insertar();
            this.Close();
            
        }


        private void Botones_Click(object sender, EventArgs e)
        {
            Button btntemp = new Button();
            btntemp = (Button)sender;

            switch(btntemp.Name)
            {
                case "btnVisa":
                    Inicio.id_forma_pago = 9;
                    this.txttarjeta.Text = "Visa";
                    this.txtpago_venta.Focus();
                    break;
                case "btnOtrasTarjetas":
                    Inicio.id_forma_pago = 13;
                    this.txttarjeta.Text = "Otras Tarjetas";
                    this.txtpago_venta.Focus();
                    break;
                case "btnNativa":
                    Inicio.id_forma_pago = 11;
                    this.txttarjeta.Text = "Nativa";
                    this.txtpago_venta.Focus();
                    break;
                case "btnNaranja":
                    Inicio.id_forma_pago = 3;
                    this.txttarjeta.Text = "Naranaja";
                    this.txtpago_venta.Focus();
                    break;
                case "btnMasterCard":
                    Inicio.id_forma_pago = 10;
                    this.txttarjeta.Text = "MasterCard";
                    this.txtpago_venta.Focus();
                    break;
                case "btnKadicard":
                    Inicio.id_forma_pago = 8;
                    this.txttarjeta.Text = "Kadicard";
                    this.txtpago_venta.Focus();
                    break;
                case "btnDebito":
                    Inicio.id_forma_pago = 12;
                    this.txttarjeta.Text = "Debito";
                    this.txtpago_venta.Focus();
                    break;
                case "btnCordobesa":
                    Inicio.id_forma_pago = 4;
                    this.txttarjeta.Text = "Cordobesa";
                    this.txtpago_venta.Focus();
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNaranja_Click(object sender, EventArgs e)
        {
            Botones_Click(sender, e);
        }

        private void btnKadicard_Click(object sender, EventArgs e)
        {
            Botones_Click(sender, e);
        }

        private void btnCordobesa_Click(object sender, EventArgs e)
        {
            Botones_Click(sender, e);
        }

        private void btnVisa_Click(object sender, EventArgs e)
        {
            Botones_Click(sender, e);

        }

        private void btnDebito_Click(object sender, EventArgs e)
        {
            Botones_Click(sender, e);
        }

        private void btnOtrasTarjetas_Click(object sender, EventArgs e)
        {
            Botones_Click(sender, e);
        }

        private void btnNativa_Click(object sender, EventArgs e)
        {
            Botones_Click(sender, e);
        }

        private void btnMasterCard_Click(object sender, EventArgs e)
        {
            Botones_Click(sender, e);
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

        private void frmFormaPagoTarjeta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) 
            {
                this.Close();
            }
            if (e.KeyData == Keys.F4) 
            {
                Inicio.id_forma_pago = 9;
                this.txttarjeta.Text = "Visa";
                this.txtpago_venta.Focus();
            }
            if (e.KeyData == Keys.F8)
            {
                Inicio.id_forma_pago = 13;
                this.txttarjeta.Text = "Otras Tarjetas";
                this.txtpago_venta.Focus();
            }
            if (e.KeyData == Keys.F6)
            {
                Inicio.id_forma_pago = 11;
                this.txttarjeta.Text = "Nativa";
                this.txtpago_venta.Focus();
            }
            if (e.KeyData == Keys.F1)
            {
                Inicio.id_forma_pago = 3;
                this.txttarjeta.Text = "Naranaja";
                this.txtpago_venta.Focus();
            }
            if (e.KeyData == Keys.F7)
            {
                 Inicio.id_forma_pago = 10;
                    this.txttarjeta.Text = "MasterCard";
                    this.txtpago_venta.Focus();
            }
            if (e.KeyData == Keys.F2)
            {
                Inicio.id_forma_pago = 8;
                this.txttarjeta.Text = "Kadicard";
                this.txtpago_venta.Focus();
            }
            if (e.KeyData == Keys.F5)
            {
                Inicio.id_forma_pago = 12;
                this.txttarjeta.Text = "Debito";
                this.txtpago_venta.Focus();
            }
            if (e.KeyData == Keys.F3)
            {
                Inicio.id_forma_pago = 4;
                this.txttarjeta.Text = "Cordobesa";
                this.txtpago_venta.Focus();
            }
        }
    }
}