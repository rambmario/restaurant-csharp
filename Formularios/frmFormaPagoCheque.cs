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
    public partial class frmFormaPagoCheque : Form
    {
        public frmFormaPagoCheque()
        {
            InitializeComponent();
            CargarComboBanco();
            CargarComboCliente();
        }
        Clase.clsPago_Pedido opago_pedido = new Clase.clsPago_Pedido();
        Clase.clsBanco obanco = new Clase.clsBanco();
        Clase.clsCliente ocliente = new Clase.clsCliente();

        private void frmFormaPagoCheque_Load(object sender, EventArgs e)
        {
            this.Location = ((frmPago)this.Owner).lbllocalizacion.Location;
            Inicio.id_forma_pago = 7;
            this.txtPago_venta.Focus();
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.MinimizeBox = false;

            //this.BackgroundImage = Properties.Resources.Fondo;

            //dandole color a los botones
            var buttons = this.Controls.OfType<Button>();

            foreach (var button in buttons)
            {
                if (button.Name != "btnBuscarCliente" | button.Name != "btnBanco") 
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
        }

        private void CargarComboBanco()
        {
            DataTable odt = new DataTable();
            odt = obanco.GetCmb();
            cmbBanco.DataSource = odt;
            cmbBanco.DisplayMember = "nombre_banco";
            cmbBanco.ValueMember = "id_banco";
            if (this.cmbBanco.SelectedIndex >= 0)
            {
                this.cmbBanco.SelectedIndex = 0;
                Inicio.id_banco = Convert.ToInt32(cmbBanco.SelectedValue);
            }

        }

        private void CargarComboCliente()
        {
            DataTable odt = new DataTable();
            odt = ocliente.GetCmb_2();
            cmbCliente.DataSource = odt;
            cmbCliente.DisplayMember = "nombre";
            cmbCliente.ValueMember = "id_cliente";
            if (this.cmbCliente.SelectedIndex >= 0)
            {
                this.cmbCliente.SelectedIndex = 0;
                Inicio.id_cliente = Convert.ToInt32(cmbCliente.SelectedValue);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Inicio.id_cliente == 0 | Inicio.id_banco == 0) 
            {
                MessageBox.Show("Debe Llenar los Combos", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbBanco.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPago_venta.Text) | string.IsNullOrEmpty(txtNumero_Cheque.Text)) 
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios", "Advertencia" ,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPago_venta.Focus();
                return;
            }
            double total = Convert.ToDouble(((frmPago)this.Owner).txttotal.Text);
            double pago_parcial = Convert.ToDouble(((frmPago)this.Owner).txtPago.Text);
            double pago_total = Convert.ToDouble(this.txtPago_venta.Text) + pago_parcial;
            if (total < pago_total)
            {
                MessageBox.Show("El pago no puede ser mayor al monto total", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Stop);
                return;
            }
            opago_pedido.pid_forma_pago = Inicio.id_forma_pago;
            opago_pedido.pid_pedido = Inicio.id_pedido;
            opago_pedido.pimporte = Convert.ToDouble(txtPago_venta.Text);
            opago_pedido.pid_banco = Inicio.id_banco;
            opago_pedido.pid_cliente = Inicio.id_cliente;
            opago_pedido.pnro_cheque = this.txtNumero_Cheque.Text;
            opago_pedido.pid_caja = Inicio.parametro_id_caja;
            opago_pedido.Insertar();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBanco_Click(object sender, EventArgs e)
        {
            frmAbmBanco ob = new frmAbmBanco();
            ob.ShowDialog();
            CargarComboBanco();
            Inicio.id_banco = 0;
            this.cmbBanco.Focus();
            this.cmbBanco.Text = "";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmAbmCliente oc = new frmAbmCliente();
            oc.ShowDialog();
            CargarComboCliente();
            Inicio.id_cliente = 0;
            this.cmbCliente.Focus();
            this.cmbCliente.Text = "";
        }

        private void cmbBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_banco = Convert.ToInt32(this.cmbBanco.SelectedValue);
            }
            catch (Exception)
            {
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_cliente = Convert.ToInt32(this.cmbCliente.SelectedValue);
            }
            catch (Exception)
            {
            }
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
        public void TabularCombobox(object sender, KeyEventArgs e)
        {
            //al igual que el textbox solo que en ves de tener un keychar se utiliza el keyvalues
            if (e.KeyValue == (char)(Keys.Enter))
            {
                e.Handled = true;
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

        private void txtPago_venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularDecimales(sender, e);

        }
        private void frmFormaPagoCheque_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
        private void cmbBanco_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender, e);
        }

        private void cmbCliente_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender, e);
        }

        

        private void txtNumero_Cheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
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
    }
}
