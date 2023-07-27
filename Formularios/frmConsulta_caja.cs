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
    public partial class frmConsulta_caja : Form
    {
        public frmConsulta_caja()
        {
            InitializeComponent();
            CargarComboCaja();
        }
        Clase.clsCaja oCaja = new Clase.clsCaja();
        Clase.clsPago_Pedido oPago_Pedido = new Clase.clsPago_Pedido();
        Clase.clsEgreso_efectivo oEgreso_efectivo = new Clase.clsEgreso_efectivo();
        private void frmConsulta_caja_Load(object sender, EventArgs e)
        {
            RefrescarGrillaConsulta();
        }
        public void CargarComboCaja() 
        {
            DataTable odt = new DataTable();
            odt = oCaja.GetCmb_2();
            cmbCaja.DataSource = odt;
            cmbCaja.DisplayMember = "Caja";
            cmbCaja.ValueMember = "id_caja";
            if (this.cmbCaja.SelectedIndex >= 0)
            {
                this.cmbCaja.SelectedIndex = 0;
                Inicio.id_caja = Convert.ToInt32(cmbCaja.SelectedValue);
            }
        }
        public void RefrescarGrillaConsulta() 
        {
            DataTable odt = null;
            double efectivo = 0;
            double tarjeta = 0;
            double cheque = 0;
            odt = oPago_Pedido.GetCaja(Inicio.id_caja);
            this.dgvConsulta.DataSource = odt;
            this.dgvConsulta.Columns[0].Visible = false;
            this.dgvConsulta.Columns[1].Visible = false;
            this.dgvConsulta.AllowUserToAddRows = false;

            foreach (DataGridViewRow row in dgvConsulta.Rows)
            {
                int movimiento = Convert.ToInt32(row.Cells["id_tipo_forma_pago"].Value);
                switch(movimiento)
                {
                        //Efectivo
                    case 2:
                        efectivo += Convert.ToDouble(row.Cells["Importe"].Value);
                        break;
                        //Tarjeta
                    case 3:
                        tarjeta += Convert.ToDouble(row.Cells["Importe"].Value);
                        break;
                        //Cheque
                    case 4:
                        cheque += Convert.ToDouble(row.Cells["Importe"].Value);
                        break;
                }
            }
            this.txtCheque.Text = cheque.ToString();
            this.txtTarjeta.Text = tarjeta.ToString();
            this.txtTotal_ingreso.Text = efectivo.ToString();
            
            oCaja.GetOne(Inicio.id_caja);
            this.txtsaldo_inicial.Text = oCaja.psaldo_inicial.ToString();
            this.txtTotal_egreso.Text = oEgreso_efectivo.EfectivoxCaja(Inicio.id_caja).ToString();
            this.txtTotal_efectivo.Text = ((double.Parse(this.txtTotal_ingreso.Text) + double.Parse(this.txtsaldo_inicial.Text)) - double.Parse(this.txtTotal_egreso.Text)).ToString();

            this.txtTotal.Text = (cheque + tarjeta + double.Parse(this.txtTotal_efectivo.Text)).ToString();
        }

        private void cmbCaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Inicio.id_caja = Convert.ToInt32(this.cmbCaja.SelectedValue);
                RefrescarGrillaConsulta();
            }
            catch (Exception)
            {
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte.Formulario_report.frmReporte_caja caja = new Reporte.Formulario_report.frmReporte_caja();
            caja.ShowDialog();
        }
    }
}
