
namespace UI.Desktop
{
    partial class frmMain
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
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnProfesores = new System.Windows.Forms.Button();
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnPersonas = new System.Windows.Forms.Button();
            this.msOpciones = new System.Windows.Forms.MenuStrip();
            this.tsPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerListadoPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAltaPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsModificacionPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBajaPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerListadoMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAltaMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsModificacionMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBajaMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerListadoEspecialidad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAltaEspecialidad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsModificacionEspecialidad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBajaEspecialidad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerListadoComision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAltaComision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsModificacionComision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBajaComision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerListadoCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAltaCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsModificacionCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBajaCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(283, 63);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(223, 13);
            this.lblMensaje.TabIndex = 0;
            this.lblMensaje.Text = "¡Bienvenido al sistema de Academia de .NET!";
            // 
            // btnProfesores
            // 
            this.btnProfesores.Location = new System.Drawing.Point(314, 177);
            this.btnProfesores.Name = "btnProfesores";
            this.btnProfesores.Size = new System.Drawing.Size(144, 23);
            this.btnProfesores.TabIndex = 3;
            this.btnProfesores.Text = "ABM Profesores";
            this.btnProfesores.UseVisualStyleBackColor = true;
            this.btnProfesores.Click += new System.EventHandler(this.btnProfesores_Click);
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.Location = new System.Drawing.Point(314, 231);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(144, 23);
            this.btnAlumnos.TabIndex = 1;
            this.btnAlumnos.Text = "Inscribir alumnos";
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Click += new System.EventHandler(this.btnInscribirAlumnos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(314, 286);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(144, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnPersonas
            // 
            this.btnPersonas.Location = new System.Drawing.Point(314, 124);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(144, 23);
            this.btnPersonas.TabIndex = 9;
            this.btnPersonas.Text = "ABM Personas";
            this.btnPersonas.UseVisualStyleBackColor = true;
            this.btnPersonas.Click += new System.EventHandler(this.btnPersonas_Click);
            // 
            // msOpciones
            // 
            this.msOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPlan,
            this.tsMaterias,
            this.tsEspecialidades,
            this.tsComisiones,
            this.tsCursos,
            this.reportesToolStripMenuItem});
            this.msOpciones.Location = new System.Drawing.Point(0, 0);
            this.msOpciones.Name = "msOpciones";
            this.msOpciones.Size = new System.Drawing.Size(899, 24);
            this.msOpciones.TabIndex = 12;
            this.msOpciones.Text = "menuStrip1";
            // 
            // tsPlan
            // 
            this.tsPlan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerListadoPlan,
            this.tsAltaPlan,
            this.tsModificacionPlan,
            this.tsBajaPlan});
            this.tsPlan.Name = "tsPlan";
            this.tsPlan.Size = new System.Drawing.Size(42, 20);
            this.tsPlan.Text = "Plan";
            // 
            // tsVerListadoPlan
            // 
            this.tsVerListadoPlan.Name = "tsVerListadoPlan";
            this.tsVerListadoPlan.Size = new System.Drawing.Size(144, 22);
            this.tsVerListadoPlan.Text = "Ver listado";
            this.tsVerListadoPlan.Click += new System.EventHandler(this.tsVerListadoPlan_Click);
            // 
            // tsAltaPlan
            // 
            this.tsAltaPlan.Name = "tsAltaPlan";
            this.tsAltaPlan.Size = new System.Drawing.Size(144, 22);
            this.tsAltaPlan.Text = "Alta";
            this.tsAltaPlan.Click += new System.EventHandler(this.tsAltaPlan_Click);
            // 
            // tsModificacionPlan
            // 
            this.tsModificacionPlan.Name = "tsModificacionPlan";
            this.tsModificacionPlan.Size = new System.Drawing.Size(144, 22);
            this.tsModificacionPlan.Text = "Modificación";
            this.tsModificacionPlan.Click += new System.EventHandler(this.tsModificacionPlan_Click);
            // 
            // tsBajaPlan
            // 
            this.tsBajaPlan.Name = "tsBajaPlan";
            this.tsBajaPlan.Size = new System.Drawing.Size(144, 22);
            this.tsBajaPlan.Text = "Baja";
            this.tsBajaPlan.Click += new System.EventHandler(this.tsBajaPlan_Click);
            // 
            // tsMaterias
            // 
            this.tsMaterias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerListadoMateria,
            this.tsAltaMateria,
            this.tsModificacionMateria,
            this.tsBajaMateria});
            this.tsMaterias.Name = "tsMaterias";
            this.tsMaterias.Size = new System.Drawing.Size(64, 20);
            this.tsMaterias.Text = "Materias";
            // 
            // tsVerListadoMateria
            // 
            this.tsVerListadoMateria.Name = "tsVerListadoMateria";
            this.tsVerListadoMateria.Size = new System.Drawing.Size(144, 22);
            this.tsVerListadoMateria.Text = "Ver listado";
            this.tsVerListadoMateria.Click += new System.EventHandler(this.tsVerListadoMateria_Click);
            // 
            // tsAltaMateria
            // 
            this.tsAltaMateria.Name = "tsAltaMateria";
            this.tsAltaMateria.Size = new System.Drawing.Size(144, 22);
            this.tsAltaMateria.Text = "Alta";
            this.tsAltaMateria.Click += new System.EventHandler(this.tsAltaMateria_Click);
            // 
            // tsModificacionMateria
            // 
            this.tsModificacionMateria.Name = "tsModificacionMateria";
            this.tsModificacionMateria.Size = new System.Drawing.Size(144, 22);
            this.tsModificacionMateria.Text = "Modificación";
            this.tsModificacionMateria.Click += new System.EventHandler(this.tsModificacionMateria_Click);
            // 
            // tsBajaMateria
            // 
            this.tsBajaMateria.Name = "tsBajaMateria";
            this.tsBajaMateria.Size = new System.Drawing.Size(144, 22);
            this.tsBajaMateria.Text = "Baja";
            this.tsBajaMateria.Click += new System.EventHandler(this.tsBajaMateria_Click);
            // 
            // tsEspecialidades
            // 
            this.tsEspecialidades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerListadoEspecialidad,
            this.tsAltaEspecialidad,
            this.tsModificacionEspecialidad,
            this.tsBajaEspecialidad});
            this.tsEspecialidades.Name = "tsEspecialidades";
            this.tsEspecialidades.Size = new System.Drawing.Size(95, 20);
            this.tsEspecialidades.Text = "Especialidades";
            // 
            // tsVerListadoEspecialidad
            // 
            this.tsVerListadoEspecialidad.Name = "tsVerListadoEspecialidad";
            this.tsVerListadoEspecialidad.Size = new System.Drawing.Size(144, 22);
            this.tsVerListadoEspecialidad.Text = "Ver listado";
            this.tsVerListadoEspecialidad.Click += new System.EventHandler(this.tsVerListadoEspecialidad_Click);
            // 
            // tsAltaEspecialidad
            // 
            this.tsAltaEspecialidad.Name = "tsAltaEspecialidad";
            this.tsAltaEspecialidad.Size = new System.Drawing.Size(144, 22);
            this.tsAltaEspecialidad.Text = "Alta";
            this.tsAltaEspecialidad.Click += new System.EventHandler(this.tsAltaEspecialidad_Click);
            // 
            // tsModificacionEspecialidad
            // 
            this.tsModificacionEspecialidad.Name = "tsModificacionEspecialidad";
            this.tsModificacionEspecialidad.Size = new System.Drawing.Size(144, 22);
            this.tsModificacionEspecialidad.Text = "Modificación";
            this.tsModificacionEspecialidad.Click += new System.EventHandler(this.tsModificacionEspecialidad_Click);
            // 
            // tsBajaEspecialidad
            // 
            this.tsBajaEspecialidad.Name = "tsBajaEspecialidad";
            this.tsBajaEspecialidad.Size = new System.Drawing.Size(144, 22);
            this.tsBajaEspecialidad.Text = "Baja";
            this.tsBajaEspecialidad.Click += new System.EventHandler(this.tsBajaEspecialidad_Click);
            // 
            // tsComisiones
            // 
            this.tsComisiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerListadoComision,
            this.tsAltaComision,
            this.tsModificacionComision,
            this.tsBajaComision});
            this.tsComisiones.Name = "tsComisiones";
            this.tsComisiones.Size = new System.Drawing.Size(81, 20);
            this.tsComisiones.Text = "Comisiones";
            // 
            // tsVerListadoComision
            // 
            this.tsVerListadoComision.Name = "tsVerListadoComision";
            this.tsVerListadoComision.Size = new System.Drawing.Size(144, 22);
            this.tsVerListadoComision.Text = "Ver listado";
            this.tsVerListadoComision.Click += new System.EventHandler(this.tsVerListadoComision_Click);
            // 
            // tsAltaComision
            // 
            this.tsAltaComision.Name = "tsAltaComision";
            this.tsAltaComision.Size = new System.Drawing.Size(144, 22);
            this.tsAltaComision.Text = "Alta";
            this.tsAltaComision.Click += new System.EventHandler(this.tsAltaComision_Click);
            // 
            // tsModificacionComision
            // 
            this.tsModificacionComision.Name = "tsModificacionComision";
            this.tsModificacionComision.Size = new System.Drawing.Size(144, 22);
            this.tsModificacionComision.Text = "Modificación";
            this.tsModificacionComision.Click += new System.EventHandler(this.tsModificacionComision_Click);
            // 
            // tsBajaComision
            // 
            this.tsBajaComision.Name = "tsBajaComision";
            this.tsBajaComision.Size = new System.Drawing.Size(144, 22);
            this.tsBajaComision.Text = "Baja";
            this.tsBajaComision.Click += new System.EventHandler(this.tsBajaComision_Click);
            // 
            // tsCursos
            // 
            this.tsCursos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerListadoCurso,
            this.tsAltaCurso,
            this.tsModificacionCurso,
            this.tsBajaCurso});
            this.tsCursos.Name = "tsCursos";
            this.tsCursos.Size = new System.Drawing.Size(55, 20);
            this.tsCursos.Text = "Cursos";
            // 
            // tsVerListadoCurso
            // 
            this.tsVerListadoCurso.Name = "tsVerListadoCurso";
            this.tsVerListadoCurso.Size = new System.Drawing.Size(144, 22);
            this.tsVerListadoCurso.Text = "Ver listado";
            this.tsVerListadoCurso.Click += new System.EventHandler(this.tsVerListadoCurso_Click);
            // 
            // tsAltaCurso
            // 
            this.tsAltaCurso.Name = "tsAltaCurso";
            this.tsAltaCurso.Size = new System.Drawing.Size(144, 22);
            this.tsAltaCurso.Text = "Alta";
            this.tsAltaCurso.Click += new System.EventHandler(this.tsAltaCurso_Click);
            // 
            // tsModificacionCurso
            // 
            this.tsModificacionCurso.Name = "tsModificacionCurso";
            this.tsModificacionCurso.Size = new System.Drawing.Size(144, 22);
            this.tsModificacionCurso.Text = "Modificación";
            this.tsModificacionCurso.Click += new System.EventHandler(this.tsModificacionCurso_Click);
            // 
            // tsBajaCurso
            // 
            this.tsBajaCurso.Name = "tsBajaCurso";
            this.tsBajaCurso.Size = new System.Drawing.Size(144, 22);
            this.tsBajaCurso.Text = "Baja";
            this.tsBajaCurso.Click += new System.EventHandler(this.tsBajaCurso_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursosToolStripMenuItem,
            this.planesToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.cursosToolStripMenuItem.Text = "Cursos";
            this.cursosToolStripMenuItem.Click += new System.EventHandler(this.cursosToolStripMenuItem_Click);
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.planesToolStripMenuItem.Text = "Planes";
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(899, 512);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProfesores);
            this.Controls.Add(this.btnAlumnos);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.msOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msOpciones;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Academia";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msOpciones.ResumeLayout(false);
            this.msOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnProfesores;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.MenuStrip msOpciones;
        private System.Windows.Forms.ToolStripMenuItem tsPlan;
        private System.Windows.Forms.ToolStripMenuItem tsAltaPlan;
        private System.Windows.Forms.ToolStripMenuItem tsModificacionPlan;
        private System.Windows.Forms.ToolStripMenuItem tsBajaPlan;
        private System.Windows.Forms.ToolStripMenuItem tsVerListadoPlan;
        private System.Windows.Forms.ToolStripMenuItem tsMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem tsComisiones;
        private System.Windows.Forms.ToolStripMenuItem tsAltaComision;
        private System.Windows.Forms.ToolStripMenuItem tsModificacionComision;
        private System.Windows.Forms.ToolStripMenuItem tsBajaComision;
        private System.Windows.Forms.ToolStripMenuItem tsVerListadoComision;
        private System.Windows.Forms.ToolStripMenuItem tsAltaEspecialidad;
        private System.Windows.Forms.ToolStripMenuItem tsModificacionEspecialidad;
        private System.Windows.Forms.ToolStripMenuItem tsBajaEspecialidad;
        private System.Windows.Forms.ToolStripMenuItem tsVerListadoEspecialidad;
        private System.Windows.Forms.ToolStripMenuItem tsAltaMateria;
        private System.Windows.Forms.ToolStripMenuItem tsModificacionMateria;
        private System.Windows.Forms.ToolStripMenuItem tsBajaMateria;
        private System.Windows.Forms.ToolStripMenuItem tsVerListadoMateria;
        private System.Windows.Forms.ToolStripMenuItem tsCursos;
        private System.Windows.Forms.ToolStripMenuItem tsAltaCurso;
        private System.Windows.Forms.ToolStripMenuItem tsModificacionCurso;
        private System.Windows.Forms.ToolStripMenuItem tsBajaCurso;
        private System.Windows.Forms.ToolStripMenuItem tsVerListadoCurso;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
    }
}