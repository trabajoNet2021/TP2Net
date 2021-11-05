
namespace UI.Desktop
{
    partial class ReportePlanes
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
            this.rvwPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvwPlanes
            // 
            this.rvwPlanes.Location = new System.Drawing.Point(1, 1);
            this.rvwPlanes.Name = "rvwPlanes";
            this.rvwPlanes.ServerReport.BearerToken = null;
            this.rvwPlanes.Size = new System.Drawing.Size(798, 445);
            this.rvwPlanes.TabIndex = 0;
            // 
            // ReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvwPlanes);
            this.Name = "ReportePlanes";
            this.Text = "ReportePlanes";
            this.Load += new System.EventHandler(this.ReportePlanes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvwPlanes;
    }
}