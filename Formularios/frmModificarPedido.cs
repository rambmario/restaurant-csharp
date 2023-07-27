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
    public partial class frmModificarPedido : Form
    {
        public frmModificarPedido()
        {
            InitializeComponent();
            RefrescarGrillaCuerpo_Pedido();
        }
        Clase.clsCuerpo_Pedido ocuerpo_pedido = new Clase.clsCuerpo_Pedido();
        Clase.clsPedido opedido = new Clase.clsPedido();
        Clase.clsProducto oproducto = new Clase.clsProducto();
        Clase.clsTemp_Pedido oTemp_Pedido = new Clase.clsTemp_Pedido();

        private void frmModificarPedido_Load(object sender, EventArgs e)
        {
            this.Text = "Modificando pedido Nroº" + Inicio.id_pedido;
        }

        private void AsignarCampos() 
        {
            ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
            oproducto.GetOne(ocuerpo_pedido.pid_producto);
            txtCantidad.Text = Convert.ToString(ocuerpo_pedido.pcantidad);
            txtNombreProducto.Text = oproducto.pnombre_producto;
        }

        public void RefrescarGrillaCuerpo_Pedido()
        {
            DataTable odt = null;
            try
            {
                ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
                odt = ocuerpo_pedido.GetPedido(ocuerpo_pedido.pid_pedido);
                this.dgvCuerpo_producto.DataSource = odt;
                this.dgvCuerpo_producto.Columns[0].Visible = false;
                this.dgvCuerpo_producto.Columns[1].Visible = false;
                this.dgvCuerpo_producto.AllowUserToAddRows = false;
                //txtCantidad.Text = odt.Rows[4].ToString();
                //txtNombreProducto.Text = odt.Rows[3].ToString();
            }
            catch (Exception)
            {

            }



        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCuerpo_producto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                 bool res = int.TryParse(this.dgvCuerpo_producto[0, this.dgvCuerpo_producto.CurrentRow.Index].Value.ToString(), out Inicio.id_cuerpo_pedido );
                AsignarCampos();
                txtCantidad.Focus();
            }
            catch { }
            //Funcion para lograr que señale todo el texto del txt y no simplemente el foco.
            if (!String.IsNullOrEmpty(txtCantidad.Text))
            {
                txtCantidad.SelectionStart = 0;
                txtCantidad.SelectionLength = txtCantidad.Text.Length;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidad.Text == "0")
                {
                    MessageBox.Show("El numero a ingresar debe ser mayor a 0", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else 
                {
                    ocuerpo_pedido.GetOne(Inicio.id_cuerpo_pedido);
                    oproducto.GetOne(ocuerpo_pedido.pid_producto);
                    
                    
                    int cantidad_2 = Convert.ToInt32(txtCantidad.Text);

                    if (cantidad_2 < ocuerpo_pedido.pcantidad)
                    {
                        int cantidad_3 = ocuerpo_pedido.pcantidad - cantidad_2;
                        double PrecioFinalPedido = cantidad_3 * oproducto.pprecio;

                        //modifico el importe total en el pedido
                        opedido.GetOne(ocuerpo_pedido.pid_pedido);
                        opedido.pimporte -= PrecioFinalPedido;
                        opedido.pid_pedido = ocuerpo_pedido.pid_pedido;
                        opedido.Modificar();

                    }
                    else 
                    {
                        int cantidad_3 = cantidad_2 - ocuerpo_pedido.pcantidad;
                        double precioFinalPedido = cantidad_3 * oproducto.pprecio;

                        //modifoco el importe en el pedido
                        opedido.GetOne(ocuerpo_pedido.pid_pedido);
                        opedido.pimporte += precioFinalPedido;
                        opedido.pid_pedido = ocuerpo_pedido.pid_pedido;
                        opedido.Modificar();
                    }

                    
                    

                    //consigo el precio actual del producto sumarisado
                    double cantidad = Convert.ToDouble(txtCantidad.Text);
                    double precioproducto = oproducto.pprecio;
                    double PrecioFinal = cantidad * precioproducto;

                    //modifico el cuerpo_pedido
                    ocuerpo_pedido.pcantidad = Convert.ToInt32(txtCantidad.Text);
                    ocuerpo_pedido.pprecio = PrecioFinal;
                    ocuerpo_pedido.pid_cuerpo_pedido = Inicio.id_cuerpo_pedido;
                    ocuerpo_pedido.Modificar();

                    //modifico el temporal para futuras impresiones controladas
                    oTemp_Pedido.GetFiltro(ocuerpo_pedido.pid_pedido, ocuerpo_pedido.pid_cuerpo_pedido);
                    oTemp_Pedido.pcantidad = ocuerpo_pedido.pcantidad;
                    oTemp_Pedido.pprecio = ocuerpo_pedido.pprecio;
                    oTemp_Pedido.pid_cuerpo_pedido = ocuerpo_pedido.pid_cuerpo_pedido;
                    oTemp_Pedido.Modificar();

                    RefrescarGrillaCuerpo_Pedido();
                    ((frmPedido)this.Owner).RefrescarGrillaCuerpo_Pedido();
                    ((frmPedido)this.Owner).RefrescarTotales();
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Se a Generado un Error al Modificar un producto. Comuniquese con el Administrador",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        //metodos de validacion
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

        private void TabularBoton(object sender, KeyPressEventArgs e) 
        {
            //se le asigna la tecla que realizara la accion de tabulacion
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //se asigna el valor y la funcion que va a tomar esa tecla.
                e.Handled = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
            //TabularDecimales(sender,e);
           
        }

        private void frmModificarPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularBoton(sender,e);
        }

       
    }
}
