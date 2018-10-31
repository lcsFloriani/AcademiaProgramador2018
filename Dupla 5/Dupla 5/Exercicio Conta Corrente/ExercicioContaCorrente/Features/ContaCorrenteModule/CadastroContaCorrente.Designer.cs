namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    partial class CadastroContaCorrente
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
            this.cmbTitular = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.chkEspecial = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTitular
            // 
            this.cmbTitular.FormattingEnabled = true;
            this.cmbTitular.Location = new System.Drawing.Point(100, 45);
            this.cmbTitular.Name = "cmbTitular";
            this.cmbTitular.Size = new System.Drawing.Size(147, 21);
            this.cmbTitular.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Titular:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(172, 175);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 34);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(82, 175);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(73, 34);
            this.btnGravar.TabIndex = 29;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click_1);
            // 
            // chkEspecial
            // 
            this.chkEspecial.AutoSize = true;
            this.chkEspecial.Location = new System.Drawing.Point(100, 147);
            this.chkEspecial.Margin = new System.Windows.Forms.Padding(2);
            this.chkEspecial.Name = "chkEspecial";
            this.chkEspecial.Size = new System.Drawing.Size(72, 17);
            this.chkEspecial.TabIndex = 28;
            this.chkEspecial.Text = "Especial?";
            this.chkEspecial.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Limite:";
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(100, 122);
            this.txtLimite.Margin = new System.Windows.Forms.Padding(2);
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.Size = new System.Drawing.Size(147, 20);
            this.txtLimite.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Saldo:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(100, 97);
            this.txtSaldo.Margin = new System.Windows.Forms.Padding(2);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(147, 20);
            this.txtSaldo.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNumero.Location = new System.Drawing.Point(100, 71);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(147, 20);
            this.txtNumero.TabIndex = 22;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(100, 20);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(55, 20);
            this.txtId.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Id:";
            // 
            // CadastroContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 243);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTitular);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.chkEspecial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLimite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumero);
            this.Name = "CadastroContaCorrente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadastroContaCorrente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTitular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.CheckBox chkEspecial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLimite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
    }
}