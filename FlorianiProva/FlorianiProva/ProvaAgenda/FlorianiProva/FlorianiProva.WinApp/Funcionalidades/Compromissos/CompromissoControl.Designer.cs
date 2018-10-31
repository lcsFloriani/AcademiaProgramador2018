namespace FlorianiProva.WinApp.Funcionalidades.Compromissos
{
    partial class CompromissoControl
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
            this.Compromissos = new System.Windows.Forms.GroupBox();
            this.lbCompromissos = new System.Windows.Forms.ListBox();
            this.Compromissos.SuspendLayout();
            this.SuspendLayout();
            // 
            // Compromissos
            // 
            this.Compromissos.Controls.Add(this.lbCompromissos);
            this.Compromissos.Location = new System.Drawing.Point(3, 3);
            this.Compromissos.Name = "Compromissos";
            this.Compromissos.Size = new System.Drawing.Size(737, 262);
            this.Compromissos.TabIndex = 0;
            this.Compromissos.TabStop = false;
            this.Compromissos.Text = "Compromissos";
            // 
            // lbCompromissos
            // 
            this.lbCompromissos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCompromissos.FormattingEnabled = true;
            this.lbCompromissos.Location = new System.Drawing.Point(6, 17);
            this.lbCompromissos.Name = "lbCompromissos";
            this.lbCompromissos.Size = new System.Drawing.Size(725, 238);
            this.lbCompromissos.TabIndex = 0;
            // 
            // CompromissoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Compromissos);
            this.Name = "CompromissoControl";
            this.Size = new System.Drawing.Size(740, 265);
            this.Compromissos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Compromissos;
        private System.Windows.Forms.ListBox lbCompromissos;
    }
}
