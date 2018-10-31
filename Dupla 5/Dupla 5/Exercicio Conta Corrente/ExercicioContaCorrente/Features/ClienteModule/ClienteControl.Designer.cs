namespace ExercicioContaCorrente.Features.ClienteModule
{
    partial class ClienteControl
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
            this.listClientes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listClientes
            // 
            this.listClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listClientes.FormattingEnabled = true;
            this.listClientes.Location = new System.Drawing.Point(0, 0);
            this.listClientes.Margin = new System.Windows.Forms.Padding(2);
            this.listClientes.Name = "listClientes";
            this.listClientes.Size = new System.Drawing.Size(476, 294);
            this.listClientes.TabIndex = 1;
            // 
            // ClienteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listClientes);
            this.Name = "ClienteControl";
            this.Size = new System.Drawing.Size(476, 294);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listClientes;
    }
}
