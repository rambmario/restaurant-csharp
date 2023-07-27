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
    public partial class frmActualizarPrecioProducto : Form
    {
        public frmActualizarPrecioProducto(double precio)
        {
            InitializeComponent();
            this.txtprecio.Text = precio.ToString();
        }
        Clase.clsProducto oproducto = new Clase.clsProducto();

        private void frmActualizarPrecioProducto_Load(object sender, EventArgs e)
        {
            this.txtprecio.Focus();
            txtprecio.SelectionStart = 0;
            txtprecio.SelectionLength = txtprecio.Text.Length;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtprecio.Text == "0" || this.txtprecio.Text == "")
            {
                MessageBox.Show("Debe ingresar un valor mayor a cero", "Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtprecio.Focus();
                txtprecio.SelectionStart = 0;
                txtprecio.SelectionLength = txtprecio.Text.Length;
            }
            else
            {
                oproducto.GetOne(Inicio.id_Producto);
                oproducto.pid_producto = Inicio.id_Producto;
                oproducto.pprecio = Convert.ToDouble(this.txtprecio.Text);
                oproducto.Modificar();
                this.Close();
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
    }
}
