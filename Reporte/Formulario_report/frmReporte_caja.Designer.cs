﻿namespace Gestion_gastronomica.Reporte.Formulario_report
{
    partial class frmReporte_caja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptInforme_caja1 = new Gestion_gastronomica.Reporte.rptInforme_caja();
            this.rptInforme_caja2 = new Gestion_gastronomica.Reporte.rptInforme_caja();
            this.rptInforme_caja3 = new Gestion_gastronomica.Reporte.rptInforme_caja();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1016, 733);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // frmReporte_caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 733);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmReporte_caja";
            this.Text = "frmReporte_caja";
            this.Load += new System.EventHandler(this.frmReporte_caja_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private rptInforme_caja rptInforme_caja1;
        private Gestion_gastronomica.Reporte.rptInforme_caja rptInforme_caja2;
        private rptInforme_caja rptInforme_caja3;
    }
}