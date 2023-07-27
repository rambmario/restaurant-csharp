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
    public partial class frmGestion_caja : Form
    {
        public frmGestion_caja()
        {
            InitializeComponent();
        }
        Clase.clsUsuario oUsuario = new Clase.clsUsuario();
        Clase.clsCaja oCaja = new Clase.clsCaja();
        Clase.clsPago_Pedido oPago_Pedido = new Clase.clsPago_Pedido();
        Clase.clsEgreso_efectivo oEgreso_efectivo = new Clase.clsEgreso_efectivo();

        private void frmGestion_caja_Load(object sender, EventArgs e)
        {
            ttGeneral.SetToolTip(this.btnSave, "Guardar el saldo inicial de caja");
            this.txtEfectivo_egreso.Text = "0";
            Primera_Caja();
            Acomodar_frm();
        }
        private void Primera_Caja() 
        {
            //en el caso de que nunca se haya registrado una caja
            DataTable odt_inicial = oCaja.GetAll();
            if (odt_inicial.Rows.Count == 0)
            {
                oCaja.pfecha_caja = DateTime.Now;
                oCaja.pcerrada = false;
                oCaja.pdetalle = "Primera caja Auto Iniciada";
                oCaja.pid_usuario = Inicio.parametro_id_usuario_inicio;
                oCaja.Insertar();
            }
        }
        private void Acomodar_frm() 
        {
            oCaja.GetOne(oCaja.UltimoID());
            oCaja.pid_caja = oCaja.UltimoID();
            oUsuario.GetOne(Inicio.parametro_id_usuario_inicio);
            this.lblNombre_usuario.Text = "Usuario: " + oUsuario.pnombre_usuario;
            if (oCaja.pcerrada == false)
            {
                this.gbCaja.Text = "Caja Abierta";
                this.lblNro_caja_texto.Text = "Nº De Caja";
                this.txtnro_caja.Text = oCaja.pid_caja.ToString();
                DataTable odt_saldos = oPago_Pedido.SaldoPorCaja(oCaja.pid_caja);
                this.txtTotal_Egreso_efectivo.Text = oEgreso_efectivo.EfectivoxCaja(oCaja.pid_caja).ToString();
                this.txtEfectivo.Text = odt_saldos.Rows[0]["Efectivo"].ToString();
                this.txtCheque.Text = odt_saldos.Rows[0]["Cheque"].ToString();
                this.txtTarjeta.Text = odt_saldos.Rows[0]["Tarjeta"].ToString();
                double total = (double.Parse(txtEfectivo.Text) + oCaja.psaldo_inicial) - double.Parse(this.txtTotal_Egreso_efectivo.Text);
                this.txtTotal.Text = total.ToString();
                this.txtDetalle.Text = oCaja.pdetalle;
                this.txtsaldo_inicial.Text = oCaja.psaldo_inicial.ToString();
                this.txtDetalle.Enabled = true;
                this.btnSave.Visible = true;
                this.txtsaldo_inicial.ReadOnly = false;
                this.gbEgreso.Enabled = true;
                this.btnTerminar.Text = "Cerrar";
                this.btnTerminar.Image = Properties.Resources.Candado_Cerrado;
            }
            else
            {
                this.gbCaja.Text = "Caja Cerrada";
                this.lblNro_caja_texto.Text = "Nº Ultima Caja";
                this.txtnro_caja.Text = oCaja.pid_caja.ToString();
                this.txtTotal_Egreso_efectivo.Text = oEgreso_efectivo.EfectivoxCaja(oCaja.pid_caja).ToString();
                this.txtEfectivo.Text = oCaja.psaldo_efectivo.ToString();
                this.txtCheque.Text = oCaja.psaldo_cheque.ToString();
                this.txtTarjeta.Text = oCaja.psaldo_tarjeta.ToString();
                this.txtTotal.Text = ((oCaja.psaldo_efectivo + oCaja.psaldo_inicial) - double.Parse(this.txtTotal_Egreso_efectivo.Text)).ToString();
                this.txtDetalle.Text = oCaja.pdetalle;
                this.txtsaldo_inicial.Text = oCaja.psaldo_inicial.ToString();
                this.txtDetalle.Enabled = false;
                this.btnSave.Visible = false;
                this.txtsaldo_inicial.ReadOnly = true;
                this.gbEgreso.Enabled = false;
                this.btnTerminar.Text = "Abrir";
                this.btnTerminar.Image = Properties.Resources.Candado_Abierto;
            }

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Inicio.parametro_id_caja = oCaja.pid_caja;
            this.Close();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            oCaja.GetOne(oCaja.UltimoID());
            oCaja.pid_caja = oCaja.UltimoID();
            if (oCaja.pcerrada == false)
            {
                oCaja.pcerrada = true;
                if(this.txtDetalle.Text == "")
                {
                    oCaja.pdetalle = "Cierre de Caja";
                }
                oCaja.pdetalle = this.txtDetalle.Text;
                oCaja.psaldo_tarjeta = Convert.ToDouble(this.txtTarjeta.Text);
                oCaja.psaldo_efectivo = Convert.ToDouble(this.txtEfectivo.Text);
                oCaja.psaldo_cheque = Convert.ToDouble(this.txtCheque.Text);
                oCaja.psaldo_inicial = Convert.ToDouble(this.txtsaldo_inicial.Text);
                oCaja.Modificar();
                MessageBox.Show("Cierre de caja EXITOSO", "Cierre de caja", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else 
            {
                oCaja.pfecha_caja = DateTime.Now;
                oCaja.pid_usuario = Inicio.parametro_id_usuario_inicio;
                oCaja.pcerrada = false;
                oCaja.pdetalle = "";
                oCaja.psaldo_inicial = (oCaja.psaldo_inicial + oCaja.psaldo_efectivo) - oEgreso_efectivo.EfectivoxCaja(oCaja.pid_caja);
                oCaja.psaldo_cheque = 0;
                oCaja.psaldo_efectivo = 0;
                oCaja.psaldo_tarjeta = 0;
                oCaja.Insertar();
                MessageBox.Show("La caja se abrio de forma correcta", "Caja", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            Acomodar_frm();
            Inicio.parametro_id_caja = oCaja.pid_caja;
            ((frmPedido)this.Owner).Color_Caja();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtEfectivo_egreso.Text == "" || this.txtEfectivo_egreso.Text == "0")
                return;
            if ((double.Parse(this.txtsaldo_inicial.Text) + double.Parse(this.txtEfectivo.Text)) < double.Parse(this.txtEfectivo_egreso.Text))
            {
                MessageBox.Show("El monto ingresado supera al dinero que hay en caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            oEgreso_efectivo.pid_caja = Inicio.parametro_id_caja;

            if (this.txtDetalle_egreso.Text == "") //Para dejar siempre una descripcion por las consultas de la caja
                oEgreso_efectivo.pdetalle_egreso_efectivo = "Egreso en efectivo";
            else
                oEgreso_efectivo.pdetalle_egreso_efectivo = this.txtDetalle_egreso.Text;
            
            oEgreso_efectivo.pfecha_egreso_efectivo = DateTime.Now;
            oEgreso_efectivo.pid_usuario = Inicio.parametro_id_usuario_inicio;
            oEgreso_efectivo.pimporte = double.Parse(this.txtEfectivo_egreso.Text);
            oEgreso_efectivo.Insertar();

            Acomodar_frm();

            this.txtEfectivo_egreso.Text = "0";
            this.txtEfectivo_egreso.Focus();
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

        private void txtsaldo_inicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularDecimales(sender, e);
        }

    }
}
