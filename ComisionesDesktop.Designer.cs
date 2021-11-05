
namespace UI.Desktop
{
    partial class ComisionesDesktop
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
            this.tblComision = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtAñoEspecialidad = new System.Windows.Forms.TextBox();
            this.lblAñoEspecialidad = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.txtIdPlan = new System.Windows.Forms.TextBox();
            this.lblIdComision = new System.Windows.Forms.Label();
            this.txtIdComision = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tblComision.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblComision
            // 
            this.tblComision.ColumnCount = 2;
            this.tblComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.625F));
            this.tblComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.375F));
            this.tblComision.Controls.Add(this.btnAceptar, 0, 4);
            this.tblComision.Controls.Add(this.txtAñoEspecialidad, 1, 3);
            this.tblComision.Controls.Add(this.lblAñoEspecialidad, 0, 3);
            this.tblComision.Controls.Add(this.lblDescripcion, 0, 2);
            this.tblComision.Controls.Add(this.txtDescripcion, 1, 2);
            this.tblComision.Controls.Add(this.lblIdPlan, 0, 1);
            this.tblComision.Controls.Add(this.txtIdPlan, 1, 1);
            this.tblComision.Controls.Add(this.lblIdComision, 0, 0);
            this.tblComision.Controls.Add(this.txtIdComision, 1, 0);
            this.tblComision.Controls.Add(this.btnCancelar, 1, 4);
            this.tblComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblComision.Location = new System.Drawing.Point(0, 0);
            this.tblComision.Name = "tblComision";
            this.tblComision.RowCount = 5;
            this.tblComision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tblComision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tblComision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tblComision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tblComision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblComision.Size = new System.Drawing.Size(800, 450);
            this.tblComision.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(73, 419);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtAñoEspecialidad
            // 
            this.txtAñoEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAñoEspecialidad.Location = new System.Drawing.Point(224, 350);
            this.txtAñoEspecialidad.Name = "txtAñoEspecialidad";
            this.txtAñoEspecialidad.Size = new System.Drawing.Size(573, 20);
            this.txtAñoEspecialidad.TabIndex = 5;
            // 
            // lblAñoEspecialidad
            // 
            this.lblAñoEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAñoEspecialidad.AutoSize = true;
            this.lblAñoEspecialidad.Location = new System.Drawing.Point(66, 354);
            this.lblAñoEspecialidad.Name = "lblAñoEspecialidad";
            this.lblAñoEspecialidad.Size = new System.Drawing.Size(88, 13);
            this.lblAñoEspecialidad.TabIndex = 0;
            this.lblAñoEspecialidad.Text = "Año especialidad";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(79, 251);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Location = new System.Drawing.Point(224, 247);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(573, 20);
            this.txtDescripcion.TabIndex = 4;
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Location = new System.Drawing.Point(83, 148);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(54, 13);
            this.lblIdPlan.TabIndex = 2;
            this.lblIdPlan.Text = "Id de plan";
            // 
            // txtIdPlan
            // 
            this.txtIdPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdPlan.Location = new System.Drawing.Point(224, 144);
            this.txtIdPlan.Name = "txtIdPlan";
            this.txtIdPlan.Size = new System.Drawing.Size(573, 20);
            this.txtIdPlan.TabIndex = 3;
            // 
            // lblIdComision
            // 
            this.lblIdComision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdComision.AutoSize = true;
            this.lblIdComision.Location = new System.Drawing.Point(80, 45);
            this.lblIdComision.Name = "lblIdComision";
            this.lblIdComision.Size = new System.Drawing.Size(60, 13);
            this.lblIdComision.TabIndex = 8;
            this.lblIdComision.Text = "Id comisión";
            // 
            // txtIdComision
            // 
            this.txtIdComision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdComision.Location = new System.Drawing.Point(224, 41);
            this.txtIdComision.Name = "txtIdComision";
            this.txtIdComision.ReadOnly = true;
            this.txtIdComision.Size = new System.Drawing.Size(573, 20);
            this.txtIdComision.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(473, 419);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ComisionesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblComision);
            this.Name = "ComisionesDesktop";
            this.Text = "Comisión";
            this.Load += new System.EventHandler(this.ComisionesDesktop_Load);
            this.tblComision.ResumeLayout(false);
            this.tblComision.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblComision;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblAñoEspecialidad;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.TextBox txtIdPlan;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtAñoEspecialidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblIdComision;
        private System.Windows.Forms.TextBox txtIdComision;
    }
}