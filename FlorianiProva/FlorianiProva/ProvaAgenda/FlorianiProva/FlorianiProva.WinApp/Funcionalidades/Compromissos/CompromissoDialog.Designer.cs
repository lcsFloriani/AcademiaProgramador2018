namespace FlorianiProva.WinApp.Funcionalidades.Compromissos
{
    partial class CompromissoDialog
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
            this.lbContatos = new System.Windows.Forms.ListBox();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dateTimeFinal = new System.Windows.Forms.DateTimePicker();
            this.dateTimeInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblfinal = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbContatos
            // 
            this.lbContatos.FormattingEnabled = true;
            this.lbContatos.Location = new System.Drawing.Point(15, 188);
            this.lbContatos.Name = "lbContatos";
            this.lbContatos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbContatos.Size = new System.Drawing.Size(679, 95);
            this.lbContatos.TabIndex = 0;
            // 
            // txtAssunto
            // 
            this.txtAssunto.Location = new System.Drawing.Point(88, 41);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(220, 20);
            this.txtAssunto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Assunto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Local:";
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(474, 41);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(220, 20);
            this.txtLocal.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 120);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Dia todo";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dateTimeFinal
            // 
            this.dateTimeFinal.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dateTimeFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFinal.Location = new System.Drawing.Point(237, 115);
            this.dateTimeFinal.Name = "dateTimeFinal";
            this.dateTimeFinal.Size = new System.Drawing.Size(134, 20);
            this.dateTimeFinal.TabIndex = 6;
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dateTimeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeInicio.Location = new System.Drawing.Point(88, 117);
            this.dateTimeInicio.MinDate = new System.DateTime(2018, 4, 19, 0, 0, 0, 0);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.Size = new System.Drawing.Size(99, 20);
            this.dateTimeInicio.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data Inicial";
            // 
            // lblfinal
            // 
            this.lblfinal.AutoSize = true;
            this.lblfinal.Location = new System.Drawing.Point(234, 99);
            this.lblfinal.Name = "lblfinal";
            this.lblfinal.Size = new System.Drawing.Size(55, 13);
            this.lblfinal.TabIndex = 9;
            this.lblfinal.Text = "Data Final";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(559, 357);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(153, 39);
            this.btnCadastrar.TabIndex = 10;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Segure ctrl para selecionar mais de 1 contato";
            // 
            // CompromissoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 397);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblfinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimeInicio);
            this.Controls.Add(this.dateTimeFinal);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.lbContatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CompromissoDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompromissoDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbContatos;
        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dateTimeFinal;
        private System.Windows.Forms.DateTimePicker dateTimeInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblfinal;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label4;
    }
}