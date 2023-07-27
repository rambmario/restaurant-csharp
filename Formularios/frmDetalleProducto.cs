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
    public partial class frmDetalleProducto : Form
    {
        public frmDetalleProducto()
        {
            InitializeComponent();
            CargarComboOpcion_Modificacion();
            CargarComboGrupoProducto();
            CargarComboTipoProducto();
        }

        Clase.clsProducto oproducto = new Clase.clsProducto();
        Clase.clsTipo_Producto otipo_producto = new Clase.clsTipo_Producto();
        Clase.clsOpcion_Modificacion oopcion_modificacion = new Clase.clsOpcion_Modificacion();
        Clase.clsGrupo_Producto ogrupo_producto = new Clase.clsGrupo_Producto();
        frmAbmProducto frmabm = new frmAbmProducto();

        private void frmDetalleProducto_Load(object sender, EventArgs e)
        {
            if (Inicio.BanderaProducto == 1)
            {
                LimpiarControles();
            }
            else
            {
               
                ObtenerDatos();
            }
            this.txtnombre_producto.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;


        }



        //definicion de Metodos utiles.



        //metodo para obtener los valores de tipoproducto

        private void CargarComboTipoProducto()
        {
            DataTable odt = new DataTable();
            odt = otipo_producto.GetCmb_2(Inicio.id_grupo_Producto);
            cmbtipo_producto.DataSource = odt;
            cmbtipo_producto.DisplayMember = "nombre_tipo_producto";
            cmbtipo_producto.ValueMember = "id_tipo_producto";
            if (this.cmbtipo_producto.SelectedIndex >= 0) 
            {
                this.cmbtipo_producto.SelectedIndex = 0;
                Inicio.id_tipo_producto = Convert.ToInt32(cmbtipo_producto.SelectedValue);
            }

        }

        private void CargarComboGrupoProducto()
        {
            DataTable odt = new DataTable();
            odt = ogrupo_producto.GetCmb();
            cmbGrupo_producto.DataSource = odt;
            cmbGrupo_producto.DisplayMember = "nombre_grupo_producto";
            cmbGrupo_producto.ValueMember = "id_grupo_producto";
            if (this.cmbGrupo_producto.SelectedIndex > 0)
            {
                cmbGrupo_producto.SelectedIndex = 0;
                Inicio.id_grupo_Producto = Convert.ToInt32(cmbGrupo_producto.SelectedValue);
            }

        }

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
            this.txtnombre_producto.Text = "";
            this.txtdescripcion.Text = "";
            this.txtreceta.Text = "";
            this.txtprecio.Text = "";
            this.pictureBox1.Image = null;
            this.cmbtipo_producto.SelectedItem = null;
            this.cmbOpcionModificacion.SelectedItem = null;
            this.pictureBox1.Image = null;
        }

        private void AsignarDatos()
        {
            oproducto.pnombre_producto = this.txtnombre_producto.Text;
            oproducto.pdescripcion = this.txtdescripcion.Text;
            oproducto.picono = this.txticono.Text;
            oproducto.pprecio = Convert.ToDouble(txtprecio.Text);
            oproducto.preceta = this.txtreceta.Text;
            oproducto.psin_disponibilidad = this.ckbDisponible.Checked;
            oproducto.pid_tipo_producto = Convert.ToInt32(cmbtipo_producto.SelectedValue);
            oproducto.pid_opcion_modificacion = Convert.ToInt32(cmbOpcionModificacion.SelectedValue);
        }

        private void ObtenerDatos()
        {
            oproducto.GetOne(Inicio.id_Producto);
            this.txtnombre_producto.Text = oproducto.pnombre_producto;
            this.txticono.Text = oproducto.picono;
            oproducto.pid_producto = Inicio.id_Producto;
            this.txtdescripcion.Text = oproducto.pdescripcion;
            this.txtreceta.Text = oproducto.preceta;
            this.txtprecio.Text = Convert.ToString(oproducto.pprecio);
            this.ckbDisponible.Checked = oproducto.psin_disponibilidad;
            this.cmbOpcionModificacion.SelectedValue = oproducto.pid_opcion_modificacion;
            pictureBox1.ImageLocation = this.txticono.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            otipo_producto.GetOne(oproducto.pid_tipo_producto);
            Inicio.id_grupo_Producto = otipo_producto.pid_grupo_producto;
            cmbGrupo_producto.SelectedValue = Inicio.id_grupo_Producto;

            cmbtipo_producto.SelectedValue = oproducto.pid_tipo_producto;

        }
        private void SoloLectura()
        {
            this.txtnombre_producto.Enabled = false;
            this.txticono.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.txtdescripcion.Enabled = false;
            this.txtprecio.Enabled = false;
            this.cmbtipo_producto.Enabled = false;
            this.txtreceta.Enabled = false;
            this.ckbDisponible.Enabled = false;
            this.cmbOpcionModificacion.Enabled = false;
        }

        //Eventos y acciones

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //Validaciones.
            //validar que el combobox contenga un valor correcto y que no este vacio
            if (cmbtipo_producto.SelectedItem == null | cmbOpcionModificacion.SelectedItem == null)
            {

                MessageBox.Show("Llenar El Combo Con datos Correctos");
                cmbtipo_producto.Focus();
                return;
            }
            //validar que las cajas de texto no esten vacias
            
            if (string.IsNullOrEmpty(txtnombre_producto.Text) | string.IsNullOrEmpty(txtprecio.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_producto.Focus();
                return;
            }



            //creacion o modificacion de la tabla
            try
            {
                this.AsignarDatos();
                if (oproducto.Exist())
                {

                    if (Inicio.BanderaProducto == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.BanderaProducto == 2)
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

                switch (Inicio.BanderaProducto)
                {
                    //INGRESA UNO NUEVO
                    case 1:
                        oproducto.Insertar();
                        ((frmAbmProducto)this.Owner).RefrescarGrilla();
                        LimpiarControles();
                        this.txtnombre_producto.Focus();
                        break;
                    //MODIFICA UNO EXISTENTE
                    case 2:
                        oproducto.Modificar();
                        this.Close();
                        break;
                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch    
        }

        private void btnBuscartipoProducto_Click(object sender, EventArgs e)
        {
            frmAbmTipo_Producto frmtipo = new frmAbmTipo_Producto();
            frmtipo.ShowDialog();
            CargarComboTipoProducto();
            Inicio.id_Producto = 0;
            this.cmbtipo_producto.Focus();
            this.cmbtipo_producto.Text = "";
        }

        private void btnopcion_modificacion_Click(object sender, EventArgs e)
        {
            frmAbmOpcion_Modificacion frmgrupo = new frmAbmOpcion_Modificacion();
            frmgrupo.ShowDialog();
            CargarComboOpcion_Modificacion();
            Inicio.id_Opcion_Modificacion = 0;
            this.cmbOpcionModificacion.Focus();
            this.cmbOpcionModificacion.SelectedItem = null;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            //Aquí incluiremos los filtros que queramos.
            BuscarImagen.Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.bmp;*.png)|*.jpg;*.jpeg;*.bmp;*.png";
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Titulo del Dialogo";
            BuscarImagen.InitialDirectory = "C:\\";
            BuscarImagen.FileName = this.txticono.Text;
            //BuscarImagen.FileName = this.textBox1.Text;
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                // Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                this.txticono.Text = BuscarImagen.FileName;
                //String Direccion = BuscarImagen.FileName;
                //this.pictureBox1.ImageLocation = Direccion;
                pictureBox1.ImageLocation = this.txticono.Text;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }

        }
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            txticono.Text = "";
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

        private void txtnombre_producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void txtreceta_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularDecimales(sender,e);
        }

        private void cmbtipo_producto_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender,e);
        }

        private void txticono_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void cmbOpcionModificacion_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender,e);
        }

        private void txticono_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        private void btnGrupo_producto_Click(object sender, EventArgs e)
        {
            frmAbmGrupo_Producto ogp = new frmAbmGrupo_Producto();
            ogp.ShowDialog();
            CargarComboGrupoProducto();
            Inicio.id_grupo_Producto = 0;
            this.cmbGrupo_producto.Focus();
            this.cmbGrupo_producto.Text = "";
        }

        private void cmbGrupo_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_grupo_Producto = Convert.ToInt32(this.cmbGrupo_producto.SelectedValue);
                CargarComboTipoProducto();
            }
            catch (Exception)
            {
            }
        }

        private void cmbOpcionModificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_Opcion_Modificacion = Convert.ToInt32(this.cmbOpcionModificacion.SelectedValue);
            }
            catch (Exception)
            {
            }
        }





        //private void cmbGrupo_producto_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //}

        //private void cmbGrupo_producto_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    Inicio.id_grupo_Producto = Convert.ToInt32(this.cmbGrupo_producto.SelectedValue);
        //    CargarComboTipoProducto();
        //}










    }
}
