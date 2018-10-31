namespace GerenciadorProvas.WinApp.DisciplinaModulo
{
    partial class DisciplinaDialog
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
            this.txtNomeDisciplina = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNomeDisciplina = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomeDisciplina
            // 
            this.txtNomeDisciplina.Location = new System.Drawing.Point(66, 33);
            this.txtNomeDisciplina.Name = "txtNomeDisciplina";
            this.txtNomeDisciplina.Size = new System.Drawing.Size(199, 20);
            this.txtNomeDisciplina.TabIndex = 1;
            this.txtNomeDisciplina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNomeDisciplina_KeyDown);
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(109, 79);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 2;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnCadastrarDisciplina_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(190, 79);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNomeDisciplina
            // 
            this.lblNomeDisciplina.AutoSize = true;
            this.lblNomeDisciplina.Location = new System.Drawing.Point(22, 36);
            this.lblNomeDisciplina.Name = "lblNomeDisciplina";
            this.lblNomeDisciplina.Size = new System.Drawing.Size(38, 13);
            this.lblNomeDisciplina.TabIndex = 4;
            this.lblNomeDisciplina.Text = "Nome:";
            // 
            // DisciplinaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 119);
            this.Controls.Add(this.lblNomeDisciplina);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtNomeDisciplina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisciplinaDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNomeDisciplina;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNomeDisciplina;
    }
}