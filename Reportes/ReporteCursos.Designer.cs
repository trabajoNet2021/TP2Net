
namespace UI.Desktop.Reportes
{
    partial class ReporteCursos
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
            this.rvwCursos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvwCursos
            // 
            this.rvwCursos.Location = new System.Drawing.Point(-1, 1);
            this.rvwCursos.Name = "rvwCursos";
            this.rvwCursos.ServerReport.BearerToken = null;
            this.rvwCursos.Size = new System.Drawing.Size(801, 446);
            this.rvwCursos.TabIndex = 0;
            // 
            // ReporteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvwCursos);
            this.Name = "ReporteCursos";
            this.Text = "ReporteCursos";
            this.Load += new System.EventHandler(this.ReporteCursos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvwCursos;
    }
}