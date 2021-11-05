using System;
using Business.Entities;


namespace UI.Web
{
    public partial class PaginaPrincipal1 : ApplicationWebForm
    {

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            Persona per = (Persona)Session["persona"];
            this.OcultaAcciones(per.TipoPersona);
            bvNombreApellido.Text = ("Bienvenido " + per.Apellido + " " + per.Nombre);
        }

        protected void btnPersona_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personas.aspx");
        }

        protected void btnProfesor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profesor.aspx");
        }

        protected void btnInscripcionCursado_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlumnosInscripcion.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnReporteCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReporteCursos.aspx");
        }

        protected void btnReportePlanes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportePlanes.aspx");
        }

        #endregion


        #region Métodos

        //Método que oculta acciones tanto a docentes, como así también a alumnos
        protected override void OcultaAcciones(string tipoPersona)
        {
            //Dentro de este método, se llamará a otro método que oculta los botones
            //que solo un administrador puede ver

            switch (tipoPersona)
            {
                case "Alumno":
                    this.OcultaBotones();
                    break;

                case "Docente":
                    this.OcultaBotones();
                    break;

                default:
                    break;
            }

        }

        protected override void OcultaBotones()
        {
            this.btnPersona.Enabled = false;
            this.btnProfesor.Enabled = false;
        }


        #endregion
    }
}