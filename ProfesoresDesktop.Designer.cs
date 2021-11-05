
namespace UI.Desktop
{
    partial class ProfesoresDesktop
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
            this.lbIdDocente = new System.Windows.Forms.Label();
            this.lbIDCurso = new System.Windows.Forms.Label();
            this.lbIDDictado = new System.Windows.Forms.Label();
            this.lbCargo = new System.Windows.Forms.Label();
            this.txtIdDocente = new System.Windows.Forms.TextBox();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.txtIdDictado = new System.Windows.Forms.TextBox();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlProfesores = new System.Windows.Forms.TableLayoutPanel();
            this.tlProfesores.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbIdDocente
            // 
            this.lbIdDocente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbIdDocente.AutoSize = true;
            this.lbIdDocente.Location = new System.Drawing.Point(69, 218);
            this.lbIdDocente.Name = "lbIdDocente";
            this.lbIdDocente.Size = new System.Drawing.Size(62, 13);
            this.lbIdDocente.TabIndex = 0;
            this.lbIdDocente.Text = "ID Docente";
            // 
            // lbIDCurso
            // 
            this.lbIDCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbIDCurso.AutoSize = true;
            this.lbIDCurso.Location = new System.Drawing.Point(76, 128);
            this.lbIDCurso.Name = "lbIDCurso";
            this.lbIDCurso.Size = new System.Drawing.Size(48, 13);
            this.lbIDCurso.TabIndex = 1;
            this.lbIDCurso.Text = "ID Curso";
            // 
            // lbIDDictado
            // 
            this.lbIDDictado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbIDDictado.AutoSize = true;
            this.lbIDDictado.Location = new System.Drawing.Point(71, 38);
            this.lbIDDictado.Name = "lbIDDictado";
            this.lbIDDictado.Size = new System.Drawing.Size(58, 13);
            this.lbIDDictado.TabIndex = 2;
            this.lbIDDictado.Text = "ID Dictado";
            this.lbIDDictado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCargo
            // 
            this.lbCargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCargo.AutoSize = true;
            this.lbCargo.Location = new System.Drawing.Point(82, 308);
            this.lbCargo.Name = "lbCargo";
            this.lbCargo.Size = new System.Drawing.Size(35, 13);
            this.lbCargo.TabIndex = 3;
            this.lbCargo.Text = "Cargo";
            // 
            // txtIdDocente
            // 
            this.txtIdDocente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdDocente.Location = new System.Drawing.Point(203, 215);
            this.txtIdDocente.Name = "txtIdDocente";
            this.txtIdDocente.Size = new System.Drawing.Size(594, 20);
            this.txtIdDocente.TabIndex = 4;
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdCurso.Location = new System.Drawing.Point(203, 125);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.Size = new System.Drawing.Size(594, 20);
            this.txtIdCurso.TabIndex = 5;
            // 
            // txtIdDictado
            // 
            this.txtIdDictado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdDictado.Location = new System.Drawing.Point(203, 35);
            this.txtIdDictado.Name = "txtIdDictado";
            this.txtIdDictado.ReadOnly = true;
            this.txtIdDictado.Size = new System.Drawing.Size(594, 20);
            this.txtIdDictado.TabIndex = 6;
            // 
            // txtCargo
            // 
            this.txtCargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCargo.Location = new System.Drawing.Point(203, 305);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(594, 20);
            this.txtCargo.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(46, 393);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(449, 393);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tlProfesores
            // 
            this.tlProfesores.ColumnCount = 2;
            this.tlProfesores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlProfesores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlProfesores.Controls.Add(this.lbIDDictado, 0, 0);
            this.tlProfesores.Controls.Add(this.lbCargo, 0, 3);
            this.tlProfesores.Controls.Add(this.lbIDCurso, 0, 1);
            this.tlProfesores.Controls.Add(this.lbIdDocente, 0, 2);
            this.tlProfesores.Controls.Add(this.txtIdCurso, 1, 1);
            this.tlProfesores.Controls.Add(this.txtCargo, 1, 3);
            this.tlProfesores.Controls.Add(this.txtIdDictado, 1, 0);
            this.tlProfesores.Controls.Add(this.txtIdDocente, 1, 2);
            this.tlProfesores.Controls.Add(this.btnAceptar, 0, 4);
            this.tlProfesores.Controls.Add(this.btnCancelar, 1, 4);
            this.tlProfesores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlProfesores.Location = new System.Drawing.Point(0, 0);
            this.tlProfesores.Name = "tlProfesores";
            this.tlProfesores.RowCount = 5;
            this.tlProfesores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlProfesores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlProfesores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlProfesores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlProfesores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlProfesores.Size = new System.Drawing.Size(800, 450);
            this.tlProfesores.TabIndex = 10;
            // 
            // ProfesoresDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlProfesores);
            this.Name = "ProfesoresDesktop";
            this.Text = "Profesores";
            this.Load += new System.EventHandler(this.ProfesoresDesktop_Load);
            this.tlProfesores.ResumeLayout(false);
            this.tlProfesores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbIdDocente;
        private System.Windows.Forms.Label lbIDCurso;
        private System.Windows.Forms.Label lbIDDictado;
        private System.Windows.Forms.Label lbCargo;
        private System.Windows.Forms.TextBox txtIdDocente;
        private System.Windows.Forms.TextBox txtIdCurso;
        private System.Windows.Forms.TextBox txtIdDictado;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tlProfesores;
    }
}