namespace Banco.WindowsApp.Features.ContaCorrenteModule
{
    partial class ContaCorrenteControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListContasCorrente = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListContasCorrente
            // 
            this.ListContasCorrente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListContasCorrente.FormattingEnabled = true;
            this.ListContasCorrente.Location = new System.Drawing.Point(0, 0);
            this.ListContasCorrente.Name = "ListContasCorrente";
            this.ListContasCorrente.Size = new System.Drawing.Size(481, 326);
            this.ListContasCorrente.TabIndex = 0;
            this.ListContasCorrente.SelectedIndexChanged += new System.EventHandler(this.ListContasCorrente_SelectedIndexChanged);
            // 
            // ContaCorrenteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListContasCorrente);
            this.Name = "ContaCorrenteControl";
            this.Size = new System.Drawing.Size(481, 326);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListContasCorrente;
    }
}
