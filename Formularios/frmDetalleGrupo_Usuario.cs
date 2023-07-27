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
    public partial class frmDetalleGrupo_Usuario : Form
    {
        
        public frmDetalleGrupo_Usuario()
        {
            InitializeComponent();
            
            
        }
        Clase.clsGrupo_Usuario ogrupousuario = new Clase.clsGrupo_Usuario();
        frmAbmGrupo_Usuario abmgrupo_usuario = new frmAbmGrupo_Usuario();
        

        private void frmDetalleGrupo_Usuario_Load(object sender, EventArgs e)
        {
            if (Inicio.BanderaGrupo_Usuario == 1)
            {
                LimpiarControles();
            }
            else
            {
                ObtenerDatos();
            }
            this.txtnombre_grupo_usuario.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
        private void LimpiarControles()
        {
            this.txtnombre_grupo_usuario.Text = "";
        }

        private void AsignarDatos()
        {
            ogrupousuario.pnombre_usuario = this.txtnombre_grupo_usuario.Text;
        }

        private void ObtenerDatos()
        {
            ogrupousuario.GetOne(Inicio.id_grupo_usuario);
            this.txtnombre_grupo_usuario.Text = ogrupousuario.pnombre_usuario;
            ogrupousuario.pid_usuario = Inicio.id_grupo_usuario;
        }
        private void SoloLectura()
        {
            this.txtnombre_grupo_usuario.Enabled = false;
            this.btnGuardar.Enabled = false;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar que las cajas de texto no esten vacias
            if (string.IsNullOrEmpty(txtnombre_grupo_usuario.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_grupo_usuario.Focus();
                return;
            }

            try
            {
                this.AsignarDatos();
                if (ogrupousuario.Exist())
                {

                    if (Inicio.BanderaGrupo_Usuario == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.BanderaGrupo_Usuario == 2)
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

                switch (Inicio.BanderaGrupo_Usuario)
                {
                    case 1:
                        ogrupousuario.Insertar();
                        ((frmAbmGrupo_Usuario)this.Owner).RefrescarGrilla();
                        //this.ObtenerDatos();
                        LimpiarControles();
                        this.txtnombre_grupo_usuario.Focus();
                        break;

                    case 2:
                        ogrupousuario.Modificar();
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



        //implementacion de metodos a sus respectivos sitios...


        private void txtnombre_grupo_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            TabularTextBox(sender,e);
        }


    }
}
