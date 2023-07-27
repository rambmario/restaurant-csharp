using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Gestion_gastronomica.Reporte.Formulario_report
{
    public partial class frmReporte_caja : Form
    {
        public frmReporte_caja()
        {
            InitializeComponent();
        }

        private void frmReporte_caja_Load(object sender, EventArgs e)
        {
            rptInforme_caja aoReport = new rptInforme_caja();
            aoReport.SetParameterValue("@id_caja", Inicio.id_caja);
            crystalReportViewer1.ReportSource = aoReport;
            
        }
    }
}
