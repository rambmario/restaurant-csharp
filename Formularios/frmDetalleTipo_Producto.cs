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
    public partial class frmDetalleTipo_Producto : Form
    {
        public frmDetalleTipo_Producto()
        {
            InitializeComponent();
            CargarComboGrupo_producto();
        }

        
        Clase.clsTipo_Producto otipo_producto = new Clase.clsTipo_Producto();
        Clase.clsGrupo_Producto ogrupo_producto = new Clase.clsGrupo_Producto();
        frmAbmTipo_Producto frmabm = new frmAbmTipo_Producto();

        private void frmDetalleTipo_Producto_Load(object sender, EventArgs e)
        {
            if (Inicio.BanderaTipo_Producto == 1)
            {
                LimpiarControles();
            }
            else
            {
                ObtenerDatos();
            }
            this.txtnombre_tipo_producto.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }


        //definicion de Metodos utiles.

        private void CargarComboGrupo_producto()
        {
            DataTable odt = new DataTable();
            odt = ogrupo_producto.GetCmb();
            cmbGrupo_producto.DataSource = odt;
            cmbGrupo_producto.DisplayMember = "nombre_grupo_producto";
            cmbGrupo_producto.ValueMember = "id_grupo_producto";

        }

        
        private void LimpiarControles()
        {
            this.txtnombre_tipo_producto.Text = "";
            this.txticono.Text = "";
            this.pictureBox1.Image = null;
            this.cmbGrupo_producto.SelectedItem = null;
        }

        private void AsignarDatos()
        {
            otipo_producto.pnombre_tipo_producto = this.txtnombre_tipo_producto.Text;
            otipo_producto.picono = this.txticono.Text;
            otipo_producto.pid_grupo_producto = Convert.ToInt32(cmbGrupo_producto.SelectedValue);
        }

        private void ObtenerDatos()
        {
            otipo_producto.GetOne(Inicio.id_tipo_producto);
            this.txtnombre_tipo_producto.Text = otipo_producto.pnombre_tipo_producto;
            otipo_producto.pid_tipo_producto = Inicio.id_tipo_producto;
            this.txticono.Text = otipo_producto.picono;
            pictureBox1.ImageLocation = this.txticono.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.cmbGrupo_producto.SelectedValue = otipo_producto.pid_grupo_producto;
        }
        private void SoloLectura()
        {
            this.txtnombre_tipo_producto.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.txticono.Enabled = false;
            this.cmbGrupo_producto.Enabled = false;
        }


        //Eventos y acciones

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar que el combobox contenga un valor correcto y que no este vacio
            if (cmbGrupo_producto.SelectedItem == null)
            {

                MessageBox.Show("Llenar El Combo Con datos Correctos");
                cmbGrupo_producto.Focus();
                return;
            }
            //validar que las cajas de texto no esten vacias
            if (string.IsNullOrEmpty(txtnombre_tipo_producto.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_tipo_producto.Focus();
                return;
            }



            //creacion o modificacion de la tabla
            try
            {
                this.AsignarDatos();
                if (otipo_producto.Exist())
                {

                    if (Inicio.BanderaTipo_Producto == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.BanderaTipo_Producto == 2)
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

                switch (Inicio.BanderaTipo_Producto)
                {
                    //INGRESA UNO NUEVO
                    case 1:
                        otipo_producto.Insertar();
                        ((frmAbmTipo_Producto)this.Owner).RefrescarGrilla();
                        LimpiarControles();
                        this.txtnombre_tipo_producto.Focus();
                        break;
                    //MODIFICA UNO EXISTENTE
                    case 2:
                        otipo_producto.Modificar();
                        this.Close();
                        break;
                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch 
        }

        private void btnGrupo_producto_Click(object sender, EventArgs e)
        {
            frmAbmGrupo_Producto ogp = new frmAbmGrupo_Producto();
            ogp.ShowDialog();
            CargarComboGrupo_producto();
            this.cmbGrupo_producto.Focus();
            this.cmbGrupo_producto.Text = "";
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
        private void txtnombre_tipo_producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }

        private void txticono_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender, e);
        }

        private void cmbGrupo_producto_KeyDown(object sender, KeyEventArgs e)
        {
            TabularCombobox(sender, e);
        }








    }
}
