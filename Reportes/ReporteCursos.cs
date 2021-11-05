using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop.Reportes
{
    public partial class ReporteCursos : Form
    {
        CursoLogic cLogic = new CursoLogic();
        public ReporteCursos()
        {
            InitializeComponent();
        }

        private void ReporteCursos_Load(object sender, EventArgs e)
        {
            List<Curso> cursos = cLogic.GetAll();
            ReportDataSource rds = new ReportDataSource("dataSetCurso", cursos);
            this.rvwCursos.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.InformeCurso.rdlc";
            this.rvwCursos.LocalReport.DataSources.Clear();
            this.rvwCursos.LocalReport.DataSources.Add(rds);
            this.rvwCursos.RefreshReport();

        }
    }
}
