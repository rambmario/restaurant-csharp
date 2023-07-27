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
    public partial class frmDetalleOpcion_Modificacion_Producto : Form
    {
        public frmDetalleOpcion_Modificacion_Producto()
        {
            InitializeComponent();
            CargarComboOpcion_Modificacion();
        }

        Clase.clsOpcion_Modificacion_Producto oopcion_modificacion_producto = new Clase.clsOpcion_Modificacion_Producto();
        Clase.clsOpcion_Modificacion oopcion_modificacion = new Clase.clsOpcion_Modificacion();
        frmAbmOpcion_Modificacion_Producto frmabm = new frmAbmOpcion_Modificacion_Producto();

        private void frmDetalleOpcion_Modificacion_Producto_Load(object sender, EventArgs e)
        {
            if (Inicio.BanderaOpcion_modificacion_producto == 1)
            {
                LimpiarControles();
            }
            else
            {
                ObtenerDatos();
            }
            this.txtdescripcion.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        //definicion de Metodos utiles.

        private void CargarComboOpcion_Modificacion()
        {
            DataTable odt = new DataTable();
            odt = oopcion_modificacion.GetCmb();
            cmbOpcionModificacion.DataSource = odt;
            cmbOpcionModificacion.DisplayMember = "nombre_opcion_modificacion";
            cmbOpcionModificacion.ValueMember = "id_opcion_modificacion";

        }


        private void LimpiarControles()
        {
            this.txtprecio.Text = "";
            this.txtdescripcion.Text = "";
            this.cmbOpcionModificacion.SelectedItem = null;
        }

        private void AsignarDatos()
        {
            oopcion_modificacion_producto.pprecio = Convert.ToDouble(this.txtprecio.Text);
            oopcion_modificacion_producto.pdescripcion = this.txtdescripcion.Text;
            oopcion_modificacion_producto.pid_opcion_modificacion = Convert.ToInt32(cmbOpcionModificacion.SelectedValue);
            
        }

        private void ObtenerDatos()
        {
            oopcion_modificacion_producto.GetOne(Inicio.id_Opcion_Modificacion_producto);
            this.txtprecio.Text = Convert.ToString(oopcion_modificacion_producto.pprecio);
            oopcion_modificacion_producto.pid_opcion_modificacion_producto = Inicio.id_Opcion_Modificacion_producto;
            this.txtdescripcion.Text = oopcion_modificacion_producto.pdescripcion;
            this.cmbOpcionModificacion.SelectedValue = oopcion_modificacion_producto.pid_opcion_modificacion;
        }
        private void SoloLectura()
        {
            this.txtprecio.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.txtdescripcion.Enabled = false;
            this.cmbOpcionModificacion.Enabled = false;
        }


        //Eventos y acciones


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar que el combobox contenga un valor correcto y que no este vacio
            if (cmbOpcionModificacion.SelectedItem == null)
            {

                MessageBox.Show("Llenar El Combo Con datos Correctos");
                cmbOpcionModificacion.Focus();
                return;
            }
            //validar que las cajas de texto no esten vacias
            if (string.IsNullOrEmpty(txtprecio.Text) | string.IsNullOrEmpty(txtdescripcion.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtprecio.Focus();
                return;
            }


            //creacion o modificacion de la tabla
            try
            {
                this.AsignarDatos();
                if (oopcion_modificacion_producto.Exist())
                {

                    if (Inicio.BanderaOpcion_modificacion_producto == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.BanderaOpcion_modificacion_producto == 2)
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

                switch (Inicio.BanderaOpcion_modificacion_producto)
                {
                    //INGRESA UNO NUEVO
                    case 1:
                        oopcion_modificacion_producto.Insertar();
                        ((frmAbmOpcion_Modificacion_Producto)this.Owner).RefrescarGrilla();
                        LimpiarControles();
                        this.txtdescripcion.Focus();
                        break;
                    //MODIFICA UNO EXISTENTE
                    case 2:
                        oopcion_modificacion_producto.Modificar();
                        this.Close();
                        break;
                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch
        }

        //Tabulaciones y Validaciones (metodos)


        //valida si esta ingresando numeros y ademas que solo tenga una unica coma.
        public void TabularDecimales(object sender, KeyPressEventArgs e)
        {
            TextBox txttemp = new TextBox();
            txttemp = (TextBox)sender;

            //pregunta si se presiono la tecla "."
            if (e.KeyChar == '.')
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

        //implementacion de los metodos en sus respectivos lugares.


        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularDecimales(sender, e);
        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void cmbOpcionModificacion_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender,e);
        }


    }
}
