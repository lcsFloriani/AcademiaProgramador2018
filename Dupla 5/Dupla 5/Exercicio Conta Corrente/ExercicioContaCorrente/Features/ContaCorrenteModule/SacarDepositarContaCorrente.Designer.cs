namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    partial class SacarDepositarContaCorrente
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbWithdrawValue = new System.Windows.Forms.Label();
            this.txtWithdrawValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(153, 110);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(64, 110);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lbWithdrawValue
            // 
            this.lbWithdrawValue.AutoSize = true;
            this.lbWithdrawValue.Location = new System.Drawing.Point(54, 75);
            this.lbWithdrawValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWithdrawValue.Name = "lbWithdrawValue";
            this.lbWithdrawValue.Size = new System.Drawing.Size(34, 13);
            this.lbWithdrawValue.TabIndex = 13;
            this.lbWithdrawValue.Text = "Valor:";
            // 
            // txtWithdrawValue
            // 
            this.txtWithdrawValue.Location = new System.Drawing.Point(104, 71);
            this.txtWithdrawValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtWithdrawValue.Name = "txtWithdrawValue";
            this.txtWithdrawValue.Size = new System.Drawing.Size(120, 20);
            this.txtWithdrawValue.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Saldo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Número:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(101, 27);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(13, 13);
            this.lblNumero.TabIndex = 21;
            this.lblNumero.Text = "0";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(101, 51);
            this.lblSaldo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(45, 13);
            this.lblSaldo.TabIndex = 20;
            this.lblSaldo.Text = "R$ 0.00";
            // 
            // SacarDepositarContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 170);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbWithdrawValue);
            this.Controls.Add(this.txtWithdrawValue);
            this.Name = "SacarDepositarContaCorrente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SacarContaCorrentecs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbWithdrawValue;
        private System.Windows.Forms.TextBox txtWithdrawValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblSaldo;
    }
}