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
    public partial class frmDetalleGrupo_Producto : Form
    {
        public frmDetalleGrupo_Producto()
        {
            InitializeComponent();
        }

        Clase.clsGrupo_Producto ogrupo_producto = new Clase.clsGrupo_Producto();
        frmAbmGrupo_Producto abmGrupo_producto = new frmAbmGrupo_Producto();

        private void frmDetalleGrupo_Producto_Load(object sender, EventArgs e)
        {
            if (Inicio.BanderaGrupo_Producto == 1)
            {
                LimpiarControles();
            }
            else
            {
                ObtenerDatos();
            }
            this.txtnombre_grupo_producto.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void LimpiarControles()
        {
            this.txtnombre_grupo_producto.Text = "";
        }

        private void AsignarDatos()
        {
            ogrupo_producto.pnombre_grupo_producto = this.txtnombre_grupo_producto.Text;
        }

        private void ObtenerDatos()
        {
            ogrupo_producto.GetOne(Inicio.id_grupo_Producto);
            this.txtnombre_grupo_producto.Text = ogrupo_producto.pnombre_grupo_producto;
            ogrupo_producto.pid_grupo_producto = Inicio.id_grupo_Producto;
        }
        private void SoloLectura()
        {
            this.txtnombre_grupo_producto.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar que las cajas de texto no esten vacias
            if (string.IsNullOrEmpty(txtnombre_grupo_producto.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_grupo_producto.Focus();
                return;
            }

            try
            {
                this.AsignarDatos();
                if (ogrupo_producto.Exist())
                {

                    if (Inicio.BanderaGrupo_Producto == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.BanderaGrupo_Producto == 2)
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

                switch (Inicio.BanderaGrupo_Producto)
                {
                    case 1:
                        ogrupo_producto.Insertar();
                        ((frmAbmGrupo_Producto)this.Owner).RefrescarGrilla();
                        //this.ObtenerDatos();
                        LimpiarControles();
                        this.txtnombre_grupo_producto.Focus();
                        break;

                    case 2:
                        ogrupo_producto.Modificar();
                        this.Close();
                        break;
                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //metodos de tabulaciones y validaciones...


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

        private void txtnombre_grupo_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }

        //implementacion de metodos a sus respectivos sitios...

    }
}
