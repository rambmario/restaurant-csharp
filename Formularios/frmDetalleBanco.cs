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
    public partial class frmDetalleBanco : Form
    {
        public frmDetalleBanco()
        {
            InitializeComponent();
        }

        Clase.clsBanco obanco = new Clase.clsBanco();
        frmAbmBanco abmBanco = new frmAbmBanco();

        private void frmDetalleBanco_Load(object sender, EventArgs e)
        {
            if (Inicio.Bandera_Banco == 1)
            {
                LimpiarControles();
            }
            else
            {
                ObtenerDatos();
            }
            this.txtnombre_banco.Focus();
            this.CancelButton = btnSalir;
            this.BackColor = Color.Gainsboro;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
        private void LimpiarControles()
        {
            this.txtnombre_banco.Text = "";
        }
        private void AsignarDatos()
        {
            obanco.pnombre_banco = this.txtnombre_banco.Text;
        }

        private void ObtenerDatos()
        {
            obanco.GetOne(Inicio.id_banco);
            this.txtnombre_banco.Text = obanco.pnombre_banco;
            obanco.pid_banco = Inicio.id_banco;
        }
        private void SoloLectura()
        {
            this.txtnombre_banco.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar que las cajas de texto no esten vacias
            if (string.IsNullOrEmpty(txtnombre_banco.Text))
            {
                MessageBox.Show("Debe Llenar los Campos Obligatorios");
                txtnombre_banco.Focus();
                return;
            }

            try
            {
                this.AsignarDatos();
                if (obanco.Exist())
                {

                    if (Inicio.Bandera_Banco == 1)
                    {
                        MessageBox.Show("Sr. Usuario: Los Datos que Pretende Ingresar ya Fueron Cargados en el Sistema");
                        return;
                    }
                    else
                    {
                        if (Inicio.Bandera_Banco == 2)
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

                switch (Inicio.Bandera_Banco)
                {
                    case 1:
                        obanco.Insertar();
                        ((frmAbmBanco)this.Owner).RefrescarGrilla();
                        //this.ObtenerDatos();
                        LimpiarControles();
                        this.txtnombre_banco.Focus();
                        break;

                    case 2:
                        obanco.Modificar();
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
            TabularTextBox(sender, e);
        }

    }
}
