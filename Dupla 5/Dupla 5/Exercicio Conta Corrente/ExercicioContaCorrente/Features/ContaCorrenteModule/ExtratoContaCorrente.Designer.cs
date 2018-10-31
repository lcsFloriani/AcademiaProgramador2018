namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    partial class ExtratoContaCorrente
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
            this.ltbExtrato = new System.Windows.Forms.ListBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ltbExtrato
            // 
            this.ltbExtrato.FormattingEnabled = true;
            this.ltbExtrato.Location = new System.Drawing.Point(14, 16);
            this.ltbExtrato.Name = "ltbExtrato";
            this.ltbExtrato.Size = new System.Drawing.Size(289, 290);
            this.ltbExtrato.TabIndex = 1;
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(209, 313);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(93, 40);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // ExtratoContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 365);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.ltbExtrato);
            this.Name = "ExtratoContaCorrente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExtratoContaCorrente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ltbExtrato;
        private System.Windows.Forms.Button btnFechar;
    }
}