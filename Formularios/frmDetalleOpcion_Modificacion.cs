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
    public partial class frmDetalleOpcion_Modificacion : Form
    {
        public frmDetalleOpcion_Modificacion()
        {
            InitializeComponent();
        }
        Clase.clsOpcion_Modificacion oOpcion_modificacion = new Clase.clsOpcion_Modificacion();
        frmAbmOpcion_Modificacion frmamb = new frmAbmOpcion_Modificacion();
        private void frmDetalleOpcion_Modificacion_Load(object sender, EventArgs e)
        {
            if (Inicio.BanderaOpcion_modificacion == 1)
            {
                LimpiarControles();
            }
            else
            {
                ObtenerDatos();
            }
            this.txtnombre_opcion_modificacion.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
        private void LimpiarControles()
        {
            this.txtnombre_opcion_modificacion.Text = "";
        }

        private void AsignarDatos()
        {
            oOpcion_modificacion.pnombre_opcion_modificacion = this.txtnombre_opcion_modificacion.Text;
        }

        private void ObtenerDatos()
        {
            oOpcion_modificacion.GetOne(Inicio.id_Opcion_Modificacion);
            this.txtnombre_opcion_modificacion.Text = oOpcion_modificacion.pnombre_opcion_modificacion;
            oOpcion_modificacion.pid_opcion_modificacion = Inicio.id_Opcion_Modificacion;
        }
        private void SoloLectura()
        {
            this.txtnombre_opcion_modificacion.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar que las cajas de texto no esten vacias
            if (string.IsNullOrEmpty(txtnombre_opcion_modificacion.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_opcion_modificacion.Focus();
                return;
            }

            try
            {
                this.AsignarDatos();
                if (oOpcion_modificacion.Exist())
                {

                    if (Inicio.BanderaOpcion_modificacion == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.BanderaOpcion_modificacion == 2)
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

                switch (Inicio.BanderaOpcion_modificacion)
                {
                    case 1:
                        oOpcion_modificacion.Insertar();
                        ((frmAbmOpcion_Modificacion)this.Owner).RefrescarGrilla();
                        //this.ObtenerDatos();
                        LimpiarControles();
                        this.txtnombre_opcion_modificacion.Focus();
                        break;

                    case 2:
                        oOpcion_modificacion.Modificar();
                        this.Close();
                        break;
                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch
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

        private void txtnombre_opcion_modificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }
    }
}
