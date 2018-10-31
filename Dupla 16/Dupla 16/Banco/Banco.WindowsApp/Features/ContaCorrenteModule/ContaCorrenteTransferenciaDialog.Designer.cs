namespace Banco.WindowsApp.Features.ContaCorrenteModule
{
    partial class ContaCorrenteTransferenciaDialog
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
            this.cmbContasTransferencias = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lbltext = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbContasTransferencias
            // 
            this.cmbContasTransferencias.FormattingEnabled = true;
            this.cmbContasTransferencias.Location = new System.Drawing.Point(157, 156);
            this.cmbContasTransferencias.Name = "cmbContasTransferencias";
            this.cmbContasTransferencias.Size = new System.Drawing.Size(159, 21);
            this.cmbContasTransferencias.TabIndex = 0;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(189, 222);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 1;
            // 
            // lbltext
            // 
            this.lbltext.AutoSize = true;
            this.lbltext.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltext.Location = new System.Drawing.Point(121, 43);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(0, 29);
            this.lbltext.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Transferir para";
            // 
            // btnTransferir
            // 
            this.btnTransferir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTransferir.Location = new System.Drawing.Point(253, 283);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(75, 41);
            this.btnTransferir.TabIndex = 5;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(334, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ContaCorrenteTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 323);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbltext);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cmbContasTransferencias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ContaCorrenteTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContaCorrenteTransferencia";
            this.Load += new System.EventHandler(this.ContaCorrenteTransferencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbContasTransferencias;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lbltext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.Button button2;
    }
}