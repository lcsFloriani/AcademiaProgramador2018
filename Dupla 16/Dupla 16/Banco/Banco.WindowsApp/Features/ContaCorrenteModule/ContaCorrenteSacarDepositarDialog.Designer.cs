namespace Banco.WindowsApp.Features.ContaCorrenteModule
{
    partial class ContaCorrenteSacarDepositarDialog
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
            this.labInfo = new System.Windows.Forms.Label();
            this.txtSacar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(48, 33);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(15, 24);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = ".";
            // 
            // txtSacar
            // 
            this.txtSacar.Location = new System.Drawing.Point(52, 107);
            this.txtSacar.Name = "txtSacar";
            this.txtSacar.Size = new System.Drawing.Size(146, 20);
            this.txtSacar.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(66, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sacar/Depositar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ContaCorrenteSacarDepositarDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSacar);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ContaCorrenteSacarDepositarDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banco - Sacar/Depositar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.TextBox txtSacar;
        private System.Windows.Forms.Button button1;
    }
}