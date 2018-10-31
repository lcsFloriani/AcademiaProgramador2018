namespace GerenciadorProvas.WinApp.Features.MateriaModulo
{
    partial class MateriaDialog
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
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.lblNomeDisciplina = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtNomeMateria = new System.Windows.Forms.TextBox();
            this.cbxDisciplina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSerie = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Location = new System.Drawing.Point(20, 59);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(55, 13);
            this.lblDisciplina.TabIndex = 11;
            this.lblDisciplina.Text = "Disciplina:";
            // 
            // lblNomeDisciplina
            // 
            this.lblNomeDisciplina.AutoSize = true;
            this.lblNomeDisciplina.Location = new System.Drawing.Point(37, 26);
            this.lblNomeDisciplina.Name = "lblNomeDisciplina";
            this.lblNomeDisciplina.Size = new System.Drawing.Size(38, 13);
            this.lblNomeDisciplina.TabIndex = 10;
            this.lblNomeDisciplina.Text = "Nome:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(162, 158);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(81, 158);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 8;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtNomeMateria
            // 
            this.txtNomeMateria.Location = new System.Drawing.Point(81, 23);
            this.txtNomeMateria.Name = "txtNomeMateria";
            this.txtNomeMateria.Size = new System.Drawing.Size(156, 20);
            this.txtNomeMateria.TabIndex = 7;
            this.txtNomeMateria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNomeMateria_KeyDown);
            // 
            // cbxDisciplina
            // 
            this.cbxDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDisciplina.FormattingEnabled = true;
            this.cbxDisciplina.Location = new System.Drawing.Point(81, 56);
            this.cbxDisciplina.Name = "cbxDisciplina";
            this.cbxDisciplina.Size = new System.Drawing.Size(156, 21);
            this.cbxDisciplina.TabIndex = 6;
            this.cbxDisciplina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxDisciplina_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Série:";
            // 
            // cbxSerie
            // 
            this.cbxSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSerie.FormattingEnabled = true;
            this.cbxSerie.Location = new System.Drawing.Point(81, 90);
            this.cbxSerie.Name = "cbxSerie";
            this.cbxSerie.Size = new System.Drawing.Size(156, 21);
            this.cbxSerie.TabIndex = 12;
            this.cbxSerie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxSerie_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 14;
            // 
            // MateriaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 194);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxSerie);
            this.Controls.Add(this.lblDisciplina);
            this.Controls.Add(this.lblNomeDisciplina);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtNomeMateria);
            this.Controls.Add(this.cbxDisciplina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MateriaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.Label lblNomeDisciplina;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtNomeMateria;
        private System.Windows.Forms.ComboBox cbxDisciplina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSerie;
        private System.Windows.Forms.Label label2;
    }
}