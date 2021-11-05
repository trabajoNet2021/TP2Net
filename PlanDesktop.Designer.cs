namespace UI.Desktop
{
    partial class PlanDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDPlan = new System.Windows.Forms.Label();
            this.lblDescPlan = new System.Windows.Forms.Label();
            this.lblIDEspecialidad = new System.Windows.Forms.Label();
            this.txtIDPlan = new System.Windows.Forms.TextBox();
            this.txtDescPlan = new System.Windows.Forms.TextBox();
            this.txtIDEspecialidad = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblIDPlan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDescPlan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIDEspecialidad, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIDPlan, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescPlan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDEspecialidad, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 400);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblIDPlan
            // 
            this.lblIDPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDPlan.AutoSize = true;
            this.lblIDPlan.Location = new System.Drawing.Point(59, 38);
            this.lblIDPlan.Name = "lblIDPlan";
            this.lblIDPlan.Size = new System.Drawing.Size(42, 13);
            this.lblIDPlan.TabIndex = 0;
            this.lblIDPlan.Text = "ID Plan";
            // 
            // lblDescPlan
            // 
            this.lblDescPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescPlan.AutoSize = true;
            this.lblDescPlan.Location = new System.Drawing.Point(52, 128);
            this.lblDescPlan.Name = "lblDescPlan";
            this.lblDescPlan.Size = new System.Drawing.Size(56, 13);
            this.lblDescPlan.TabIndex = 1;
            this.lblDescPlan.Text = "Desc Plan";
            // 
            // lblIDEspecialidad
            // 
            this.lblIDEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDEspecialidad.AutoSize = true;
            this.lblIDEspecialidad.Location = new System.Drawing.Point(44, 218);
            this.lblIDEspecialidad.Name = "lblIDEspecialidad";
            this.lblIDEspecialidad.Size = new System.Drawing.Size(71, 13);
            this.lblIDEspecialidad.TabIndex = 2;
            this.lblIDEspecialidad.Text = "ID Especidad";
            // 
            // txtIDPlan
            // 
            this.txtIDPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDPlan.Location = new System.Drawing.Point(163, 35);
            this.txtIDPlan.Name = "txtIDPlan";
            this.txtIDPlan.ReadOnly = true;
            this.txtIDPlan.Size = new System.Drawing.Size(474, 20);
            this.txtIDPlan.TabIndex = 3;
            // 
            // txtDescPlan
            // 
            this.txtDescPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescPlan.Location = new System.Drawing.Point(163, 125);
            this.txtDescPlan.Name = "txtDescPlan";
            this.txtDescPlan.Size = new System.Drawing.Size(474, 20);
            this.txtDescPlan.TabIndex = 4;
            // 
            // txtIDEspecialidad
            // 
            this.txtIDEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDEspecialidad.Location = new System.Drawing.Point(163, 215);
            this.txtIDEspecialidad.Name = "txtIDEspecialidad";
            this.txtIDEspecialidad.Size = new System.Drawing.Size(474, 20);
            this.txtIDEspecialidad.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.Location = new System.Drawing.Point(722, 323);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(562, 323);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // PlanDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlanDesktop";
            this.Text = "PlanDesktop";
            this.Load += new System.EventHandler(this.PlanDesktop_Load_1);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIDPlan;
        private System.Windows.Forms.Label lblDescPlan;
        private System.Windows.Forms.Label lblIDEspecialidad;
        private System.Windows.Forms.TextBox txtIDPlan;
        private System.Windows.Forms.TextBox txtDescPlan;
        private System.Windows.Forms.TextBox txtIDEspecialidad;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
    }
}