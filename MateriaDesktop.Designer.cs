namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.txtIDMateria = new System.Windows.Forms.TextBox();
            this.txtDescMateria = new System.Windows.Forms.TextBox();
            this.lblDescMateria = new System.Windows.Forms.Label();
            this.lblIDMateria = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblIDPLan = new System.Windows.Forms.Label();
            this.txtIDPlan = new System.Windows.Forms.TextBox();
            this.lblHsTotales = new System.Windows.Forms.Label();
            this.txtHsTotales = new System.Windows.Forms.TextBox();
            this.lblHsSemanales = new System.Windows.Forms.Label();
            this.txtHsSemanales = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.Controls.Add(this.txtIDMateria, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescMateria, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescMateria, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIDMateria, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIDPLan, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIDPlan, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHsTotales, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtHsTotales, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHsSemanales, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHsSemanales, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtIDMateria
            // 
            this.txtIDMateria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDMateria.Location = new System.Drawing.Point(103, 40);
            this.txtIDMateria.Name = "txtIDMateria";
            this.txtIDMateria.ReadOnly = true;
            this.txtIDMateria.Size = new System.Drawing.Size(294, 20);
            this.txtIDMateria.TabIndex = 1;
            // 
            // txtDescMateria
            // 
            this.txtDescMateria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescMateria.Location = new System.Drawing.Point(103, 141);
            this.txtDescMateria.Name = "txtDescMateria";
            this.txtDescMateria.Size = new System.Drawing.Size(294, 20);
            this.txtDescMateria.TabIndex = 4;
            // 
            // lblDescMateria
            // 
            this.lblDescMateria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescMateria.AutoSize = true;
            this.lblDescMateria.Location = new System.Drawing.Point(15, 145);
            this.lblDescMateria.Name = "lblDescMateria";
            this.lblDescMateria.Size = new System.Drawing.Size(70, 13);
            this.lblDescMateria.TabIndex = 8;
            this.lblDescMateria.Text = "Desc Materia";
            // 
            // lblIDMateria
            // 
            this.lblIDMateria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDMateria.AutoSize = true;
            this.lblIDMateria.Location = new System.Drawing.Point(22, 44);
            this.lblIDMateria.Name = "lblIDMateria";
            this.lblIDMateria.Size = new System.Drawing.Size(56, 13);
            this.lblIDMateria.TabIndex = 0;
            this.lblIDMateria.Text = "ID Materia";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(412, 365);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(612, 365);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblIDPLan
            // 
            this.lblIDPLan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDPLan.AutoSize = true;
            this.lblIDPLan.Location = new System.Drawing.Point(29, 246);
            this.lblIDPLan.Name = "lblIDPLan";
            this.lblIDPLan.Size = new System.Drawing.Size(42, 13);
            this.lblIDPLan.TabIndex = 7;
            this.lblIDPLan.Text = "ID Plan";
            // 
            // txtIDPlan
            // 
            this.txtIDPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDPlan.Location = new System.Drawing.Point(103, 242);
            this.txtIDPlan.Name = "txtIDPlan";
            this.txtIDPlan.Size = new System.Drawing.Size(294, 20);
            this.txtIDPlan.TabIndex = 3;
            // 
            // lblHsTotales
            // 
            this.lblHsTotales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHsTotales.AutoSize = true;
            this.lblHsTotales.Location = new System.Drawing.Point(421, 145);
            this.lblHsTotales.Name = "lblHsTotales";
            this.lblHsTotales.Size = new System.Drawing.Size(58, 13);
            this.lblHsTotales.TabIndex = 6;
            this.lblHsTotales.Text = "Hs Totales";
            // 
            // txtHsTotales
            // 
            this.txtHsTotales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHsTotales.Location = new System.Drawing.Point(503, 141);
            this.txtHsTotales.Name = "txtHsTotales";
            this.txtHsTotales.Size = new System.Drawing.Size(294, 20);
            this.txtHsTotales.TabIndex = 2;
            // 
            // lblHsSemanales
            // 
            this.lblHsSemanales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHsSemanales.AutoSize = true;
            this.lblHsSemanales.Location = new System.Drawing.Point(412, 44);
            this.lblHsSemanales.Name = "lblHsSemanales";
            this.lblHsSemanales.Size = new System.Drawing.Size(75, 13);
            this.lblHsSemanales.TabIndex = 9;
            this.lblHsSemanales.Text = "Hs Semanales";
            // 
            // txtHsSemanales
            // 
            this.txtHsSemanales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHsSemanales.Location = new System.Drawing.Point(503, 40);
            this.txtHsSemanales.Name = "txtHsSemanales";
            this.txtHsSemanales.Size = new System.Drawing.Size(294, 20);
            this.txtHsSemanales.TabIndex = 5;
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MateriaDesktop";
            this.Text = "MateriaDesktop";
            this.Load += new System.EventHandler(this.MateriaDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIDMateria;
        private System.Windows.Forms.TextBox txtIDMateria;
        private System.Windows.Forms.TextBox txtHsTotales;
        private System.Windows.Forms.TextBox txtIDPlan;
        private System.Windows.Forms.TextBox txtDescMateria;
        private System.Windows.Forms.TextBox txtHsSemanales;
        private System.Windows.Forms.Label lblHsTotales;
        private System.Windows.Forms.Label lblIDPLan;
        private System.Windows.Forms.Label lblDescMateria;
        private System.Windows.Forms.Label lblHsSemanales;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}