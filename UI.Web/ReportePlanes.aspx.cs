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
    public partial class ReportePlanes : System.Web.UI.Page
    {

        #region Propiedades
        public PlanLogic PlanValido { get; set; }
        private Plan Entity { get; set; }

        #endregion


        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            PlanValido = new PlanLogic();
            this.LoadGrid();
        }

        protected void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            PlanLogic pLogic = new PlanLogic();
            List<Plan> planes = pLogic.GetPlanesEspecialidad();

            PdfWriter pdfWriter = new PdfWriter(@"C:\Users\Usuario\Downloads\ReportePlanes.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);
            var parrafo = new Paragraph("Planes de la Academia");
            var parrafo2 = new Paragraph("");   //Esto es para hacer un espacio entre el título y la tabla
            documento.Add(parrafo);
            documento.Add(parrafo2);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Id", "Descripción", "Especialidad" };

            float[] tamanios = { 3, 3, 3 };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }

            foreach (Plan pla in planes)
            {
                tabla.AddCell(new Cell().Add(new Paragraph(pla.ID.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(pla.Descripcion.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(pla.DescripcionEspecialidad.ToString()).SetFont(fontContenido)));
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
            this.gridView.DataSource = this.PlanValido.GetPlanesEspecialidad();
            this.gridView.DataBind();
        }


        #endregion

        
    }
}