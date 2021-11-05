using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class ReportePlanes : Form
    {

        PlanLogic pLogic = new PlanLogic();

        public ReportePlanes()
        {
            InitializeComponent();
        }

        private void ReportePlanes_Load(object sender, EventArgs e)
        {
            List<Plan> planes = pLogic.GetAll();
            ReportDataSource rds = new ReportDataSource("dataSetPlanes", planes);
            this.rvwPlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.InformePlan.rdlc";
            this.rvwPlanes.LocalReport.DataSources.Clear();
            this.rvwPlanes.LocalReport.DataSources.Add(rds);
            this.rvwPlanes.RefreshReport();

        }
    }
}
