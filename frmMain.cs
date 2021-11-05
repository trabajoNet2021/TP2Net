using System;
using Business.Entities;

namespace UI.Desktop
{
    public partial class frmMain : SecurityForm
    {
        Persona pLogueada;

        #region Constructores

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(Persona per) : this()
        {
            pLogueada = per;
        }

        #endregion


        #region Métodos

        //Método para ocultar botones del menú superior
        private void DeshabilitaBotonesMenu()
        {
            this.tsAltaPlan.Visible = false;
            this.tsModificacionPlan.Visible = false;
            this.tsBajaPlan.Visible = false;
            this.tsAltaMateria.Visible = false;
            this.tsModificacionMateria.Visible = false;
            this.tsBajaMateria.Visible = false;
            this.tsAltaEspecialidad.Visible = false;
            this.tsModificacionEspecialidad.Visible = false;
            this.tsBajaEspecialidad.Visible = false;
            this.tsAltaComision.Visible = false;
            this.tsModificacionComision.Visible = false;
            this.tsBajaComision.Visible = false;
            this.tsAltaCurso.Visible = false;
            this.tsModificacionCurso.Visible = false;
            this.tsBajaCurso.Visible = false;
        }

        //Método para ocultar botones principales
        private void DeshabilitaBotonesPrincipales()
        {
            this.btnPersonas.Enabled = false;
            this.btnProfesores.Enabled = false;
            this.btnAlumnos.Enabled = false;
        }

        public override void OcultaAcciones(string tipoPersona)
        {
            //Este método estará encargado de ocultar funcionalidades, según el tipo de persona que esté 
            //logueada en el sistema

            if (tipoPersona.Equals("Alumno"))
            {
                //Parte del menú superior
                this.DeshabilitaBotonesMenu();
                //Parte del menú superior

                //Parte de los botones principales
                this.DeshabilitaBotonesPrincipales();
                //Parte de los botones principales
            }

            else
            {
                //Parte del menú superior
                this.DeshabilitaBotonesMenu();
                //Parte del menú superior

                //Parte de los botones principales
                this.btnPersonas.Visible = false;
                this.btnProfesores.Visible = false;
                //Parte de los botones principales
            }
        }

        #endregion
        

        #region Botones

        private void btnInscribirAlumnos_Click(object sender, EventArgs e)
        {
            AlumnosInscripcion frmAlumnos = new AlumnosInscripcion();
            frmAlumnos.ShowDialog();
        }



        private void btnProfesores_Click(object sender, EventArgs e)
        {
            Profesores frmProfesores = new Profesores();
            frmProfesores.ShowDialog();

        }

        private void btnEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidades frmEspecialidades = new Especialidades();
            frmEspecialidades.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas frmPersonas = new Personas();
            frmPersonas.ShowDialog();
        }

        private void btnInscripcionCursado_Click(object sender, EventArgs e)
        {

        }


        #endregion


        #region Eventos
        private void frmMain_Load(object sender, EventArgs e)
        {
            switch (pLogueada.TipoPersona)
            {
                case "Alumno":
                    this.OcultaAcciones(pLogueada.TipoPersona);
                    break;

                case "Docente":
                    this.OcultaAcciones(pLogueada.TipoPersona);
                    break;

                default:
                    break;
            }

        }

        #endregion


        #region Plan
        private void tsAltaPlan_Click(object sender, EventArgs e)
        {
            PlanDesktop frmPlanes = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            frmPlanes.ShowDialog();
        }

        private void tsModificacionPlan_Click(object sender, EventArgs e)
        {
            Planes frmPlanes = new Planes("Modificacion");
            frmPlanes.ShowDialog();
        }
        private void tsBajaPlan_Click(object sender, EventArgs e)
        {
            Planes frmPlanes = new Planes("Baja");
            frmPlanes.ShowDialog();
        }

        private void tsVerListadoPlan_Click(object sender, EventArgs e)
        {
            Planes frmPlanes = new Planes(this.pLogueada);
            frmPlanes.ShowDialog();
        }

        #endregion


        #region Materias

        private void tsAltaMateria_Click(object sender, EventArgs e)
        {
            MateriaDesktop frmPlanes = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            frmPlanes.ShowDialog();
        }

        private void tsModificacionMateria_Click(object sender, EventArgs e)
        {
            Materias frmMateria = new Materias("Modificacion");
            frmMateria.ShowDialog();
        }

        private void tsBajaMateria_Click(object sender, EventArgs e)
        {
            Materias frmMateria = new Materias("Baja");
            frmMateria.ShowDialog();
        }

        private void tsVerListadoMateria_Click(object sender, EventArgs e)
        {
            Materias frmMaterias = new Materias(pLogueada);
            frmMaterias.ShowDialog();
        }


        #endregion


        #region Especialidades

        private void tsVerListadoEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidades frmEspecialidades = new Especialidades(pLogueada);
            frmEspecialidades.ShowDialog();
        }

        private void tsAltaEspecialidad_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop frmEspecialidad = new EspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            frmEspecialidad.ShowDialog();
        }

        private void tsModificacionEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidades frmEspecialidad = new Especialidades("Modificacion");
            frmEspecialidad.ShowDialog();
        }

        private void tsBajaEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidades frmEspecialidad = new Especialidades("Baja");
            frmEspecialidad.ShowDialog();
        }

        #endregion


        #region Comisiones
        private void tsAltaComision_Click(object sender, EventArgs e)
        {
            ComisionesDesktop frmComision = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);
            frmComision.ShowDialog();
        }

        private void tsModificacionComision_Click(object sender, EventArgs e)
        {
            Comisiones frmComision = new Comisiones("Modificacion");
            frmComision.ShowDialog();
        }

        private void tsBajaComision_Click(object sender, EventArgs e)
        {
            Comisiones frmComision = new Comisiones("Baja");
            frmComision.ShowDialog();
        }

        private void tsVerListadoComision_Click(object sender, EventArgs e)
        {
            Comisiones frmComisiones = new Comisiones(pLogueada);
            frmComisiones.ShowDialog();
        }

        #endregion


        #region Cursos
        private void tsAltaCurso_Click(object sender, EventArgs e)
        {
            CursosDesktop frmCurso = new CursosDesktop(ApplicationForm.ModoForm.Alta);
            frmCurso.ShowDialog();
        }

        private void tsModificacionCurso_Click(object sender, EventArgs e)
        {
            Cursos frmCurso = new Cursos("Modificacion");
            frmCurso.ShowDialog();
        }

        private void tsBajaCurso_Click(object sender, EventArgs e)
        {
            Cursos frmCurso = new Cursos("Baja");
            frmCurso.ShowDialog();
        }

        private void tsVerListadoCurso_Click(object sender, EventArgs e)
        {
            Cursos frmCursos = new Cursos(pLogueada);
            frmCursos.ShowDialog();
        }


        #endregion


        #region Reportes

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.ReporteCursos repCurso = new Reportes.ReporteCursos();
            repCurso.Show();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportePlanes repPlan = new ReportePlanes();
            repPlan.Show();
        }

        #endregion
    }
}
