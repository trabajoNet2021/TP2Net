
namespace UI.Desktop
{
    partial class AlumnosDesktop
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
            this.txtIdAlumno = new System.Windows.Forms.TextBox();
            this.lblIdAlumno = new System.Windows.Forms.Label();
            this.lblIdInscripcion = new System.Windows.Forms.Label();
            this.txtIdInscripcion = new System.Windows.Forms.TextBox();
            this.lblIdCurso = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tlAlumnosDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.btnListadoCursos = new System.Windows.Forms.Button();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.tlAlumnosDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdAlumno
            // 
            this.txtIdAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdAlumno.Location = new System.Drawing.Point(153, 120);
            this.txtIdAlumno.Name = "txtIdAlumno";
            this.txtIdAlumno.Size = new System.Drawing.Size(611, 20);
            this.txtIdAlumno.TabIndex = 13;
            // 
            // lblIdAlumno
            // 
            this.lblIdAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdAlumno.AutoSize = true;
            this.lblIdAlumno.Location = new System.Drawing.Point(48, 124);
            this.lblIdAlumno.Name = "lblIdAlumno";
            this.lblIdAlumno.Size = new System.Drawing.Size(53, 13);
            this.lblIdAlumno.TabIndex = 12;
            this.lblIdAlumno.Text = "Id alumno";
            this.lblIdAlumno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIdInscripcion
            // 
            this.lblIdInscripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdInscripcion.AutoSize = true;
            this.lblIdInscripcion.Location = new System.Drawing.Point(40, 37);
            this.lblIdInscripcion.Name = "lblIdInscripcion";
            this.lblIdInscripcion.Size = new System.Drawing.Size(70, 13);
            this.lblIdInscripcion.TabIndex = 6;
            this.lblIdInscripcion.Text = "Id Inscripción";
            // 
            // txtIdInscripcion
            // 
            this.txtIdInscripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdInscripcion.Location = new System.Drawing.Point(153, 33);
            this.txtIdInscripcion.Name = "txtIdInscripcion";
            this.txtIdInscripcion.ReadOnly = true;
            this.txtIdInscripcion.Size = new System.Drawing.Size(611, 20);
            this.txtIdInscripcion.TabIndex = 10;
            // 
            // lblIdCurso
            // 
            this.lblIdCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdCurso.AutoSize = true;
            this.lblIdCurso.Location = new System.Drawing.Point(52, 211);
            this.lblIdCurso.Name = "lblIdCurso";
            this.lblIdCurso.Size = new System.Drawing.Size(46, 13);
            this.lblIdCurso.TabIndex = 7;
            this.lblIdCurso.Text = "Id Curso";
            // 
            // lblNota
            // 
            this.lblNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(60, 298);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(30, 13);
            this.lblNota.TabIndex = 8;
            this.lblNota.Text = "Nota";
            // 
            // txtNota
            // 
            this.txtNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota.Location = new System.Drawing.Point(153, 294);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(611, 20);
            this.txtNota.TabIndex = 4;
            // 
            // lblCondicion
            // 
            this.lblCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Location = new System.Drawing.Point(48, 385);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(54, 13);
            this.lblCondicion.TabIndex = 9;
            this.lblCondicion.Text = "Condicion";
            this.lblCondicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCondicion
            // 
            this.txtCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCondicion.Location = new System.Drawing.Point(153, 381);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(611, 20);
            this.txtCondicion.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoEllipsis = true;
            this.btnCancelar.Location = new System.Drawing.Point(153, 438);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(3, 438);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // tlAlumnosDesktop
            // 
            this.tlAlumnosDesktop.BackColor = System.Drawing.SystemColors.Control;
            this.tlAlumnosDesktop.ColumnCount = 3;
            this.tlAlumnosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.60784F));
            this.tlAlumnosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.39216F));
            this.tlAlumnosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tlAlumnosDesktop.Controls.Add(this.btnCancelar, 1, 5);
            this.tlAlumnosDesktop.Controls.Add(this.txtCondicion, 1, 4);
            this.tlAlumnosDesktop.Controls.Add(this.lblCondicion, 0, 4);
            this.tlAlumnosDesktop.Controls.Add(this.txtNota, 1, 3);
            this.tlAlumnosDesktop.Controls.Add(this.lblNota, 0, 3);
            this.tlAlumnosDesktop.Controls.Add(this.lblIdCurso, 0, 2);
            this.tlAlumnosDesktop.Controls.Add(this.txtIdInscripcion, 1, 0);
            this.tlAlumnosDesktop.Controls.Add(this.lblIdInscripcion, 0, 0);
            this.tlAlumnosDesktop.Controls.Add(this.lblIdAlumno, 0, 1);
            this.tlAlumnosDesktop.Controls.Add(this.txtIdAlumno, 1, 1);
            this.tlAlumnosDesktop.Controls.Add(this.btnListadoCursos, 2, 2);
            this.tlAlumnosDesktop.Controls.Add(this.btnAceptar, 0, 5);
            this.tlAlumnosDesktop.Controls.Add(this.txtIdCurso, 1, 2);
            this.tlAlumnosDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnosDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnosDesktop.Name = "tlAlumnosDesktop";
            this.tlAlumnosDesktop.RowCount = 6;
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.Size = new System.Drawing.Size(905, 523);
            this.tlAlumnosDesktop.TabIndex = 0;
            // 
            // btnListadoCursos
            // 
            this.btnListadoCursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnListadoCursos.Location = new System.Drawing.Point(771, 206);
            this.btnListadoCursos.Name = "btnListadoCursos";
            this.btnListadoCursos.Size = new System.Drawing.Size(130, 23);
            this.btnListadoCursos.TabIndex = 14;
            this.btnListadoCursos.Text = "Ver listado";
            this.btnListadoCursos.UseVisualStyleBackColor = true;
            this.btnListadoCursos.Click += new System.EventHandler(this.btnListadoCursos_Click);
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdCurso.Location = new System.Drawing.Point(153, 207);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.Size = new System.Drawing.Size(611, 20);
            this.txtIdCurso.TabIndex = 15;
            // 
            // AlumnosDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 523);
            this.Controls.Add(this.tlAlumnosDesktop);
            this.Name = "AlumnosDesktop";
            this.Text = "AlumnosDesktop";
            this.Load += new System.EventHandler(this.AlumnosDesktop_Load);
            this.tlAlumnosDesktop.ResumeLayout(false);
            this.tlAlumnosDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtIdAlumno;
        private System.Windows.Forms.Label lblIdAlumno;
        private System.Windows.Forms.Label lblIdInscripcion;
        private System.Windows.Forms.TextBox txtIdInscripcion;
        private System.Windows.Forms.Label lblIdCurso;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TableLayoutPanel tlAlumnosDesktop;
        private System.Windows.Forms.Button btnListadoCursos;
        private System.Windows.Forms.TextBox txtIdCurso;
    }
}