using System;
using System.Collections.Generic;
using Business.Entities;
using Business.Logic;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace UI.Web
{
    public partial class ReporteCursos : System.Web.UI.Page
    {

        #region Propiedades
        public CursoLogic CursoValido { get; set; }

        private Curso Entity { get; set; }

        #endregion


        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            CursoValido = new CursoLogic();
            this.LoadGrid();
        }

        protected void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            CursoLogic cLogic = new CursoLogic();
            List<Curso> cursos = cLogic.GetAll();

            PdfWriter pdfWriter = new PdfWriter(@"C:\Users\Usuario\Downloads\ReporteCursos.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);
            var parrafo = new Paragraph("Cursos de la Academia");
            var parrafo2 = new Paragraph("");   //Esto es para hacer un espacio entre el título y la tabla
            documento.Add(parrafo);
            documento.Add(parrafo2);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Id de curso", "Descripción", "Materia", "Comisión", "Cupo", "Año calendario" };

            float[] tamanios = { 3, 3, 3, 3, 3, 3 };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }

            foreach (Curso cur in cursos)
            {
                tabla.AddCell(new Cell().Add(new Paragraph(cur.ID.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(cur.Descripcion.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(cur.Materia.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(cur.Comision.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(cur.Cupo.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(cur.AnioCalendario.ToString()).SetFont(fontContenido)));
            }

            documento.Add(tabla);
            documento.Close();
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
        #endregion


        #region Métodos

        private void LoadGrid()
        {
            this.gridView.DataSource = this.CursoValido.GetCursoMateriaCom();
            this.gridView.DataBind();
        }

        #endregion

        
    }
}