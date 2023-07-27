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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFrmUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmUsuario usuario = new frmAbmUsuario();
            usuario.ShowDialog();
            this.Show();
        }

        private void btnfrmGrupo_Usuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmGrupo_Usuario grupousuario = new frmAbmGrupo_Usuario();
            grupousuario.ShowDialog();
            this.Show();
        }

        private void btnfrmMesa_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmMesa mesa = new frmAbmMesa();
            mesa.ShowDialog();
            this.Show();
        }

        private void btnfrmTipoProducto_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmTipo_Producto tipoprodu = new frmAbmTipo_Producto();
            tipoprodu.ShowDialog();
            this.Show();
        }

        private void btnfrmProducto_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmProducto producto = new frmAbmProducto();
            producto.ShowDialog();
            this.Show();
        }

        private void btnfrmOpcion_Modificacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmOpcion_Modificacion opcion = new frmAbmOpcion_Modificacion();
            opcion.ShowDialog();
            this.Show();
        }

        private void btnfrmOpcionModificacionProducto_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmOpcion_Modificacion_Producto omp = new frmAbmOpcion_Modificacion_Producto();
            omp.ShowDialog();
            this.Show();
        }

        private void btnfrmPedido_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPedido pedido = new frmPedido();
            pedido.ShowDialog();
            this.Show();
        }

        private void btnGrupo_Producto_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmGrupo_Producto ogp = new frmAbmGrupo_Producto();
            ogp.ShowDialog();
            this.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmUsuario usuario = new frmAbmUsuario();
            usuario.ShowDialog();
            this.Show();
        }

        private void mesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmMesa mesa = new frmAbmMesa();
            mesa.ShowDialog();
            this.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmProducto producto = new frmAbmProducto();
            producto.ShowDialog();
            this.Show();
        }

        private void controlDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPedido pedido = new frmPedido();
            pedido.ShowDialog();
            if (Inicio.parametro_Salir == 0)
            {
                this.Show();
            }
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
