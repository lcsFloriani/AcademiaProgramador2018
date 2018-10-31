namespace GerenciadorProvas.WinApp.Features.TesteModulo
{
    partial class TesteDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesteDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.lblNQuestoes = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.cbxDisciplina = new System.Windows.Forms.ComboBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.nudNumeroQuestoes = new System.Windows.Forms.NumericUpDown();
            this.cbxMateria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.rbTxtTitle = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroQuestoes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblNQuestoes
            // 
            resources.ApplyResources(this.lblNQuestoes, "lblNQuestoes");
            this.lblNQuestoes.Name = "lblNQuestoes";
            // 
            // lblData
            // 
            resources.ApplyResources(this.lblData, "lblData");
            this.lblData.Name = "lblData";
            // 
            // lblDisciplina
            // 
            resources.ApplyResources(this.lblDisciplina, "lblDisciplina");
            this.lblDisciplina.Name = "lblDisciplina";
            // 
            // cbxDisciplina
            // 
            this.cbxDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDisciplina.FormattingEnabled = true;
            resources.ApplyResources(this.cbxDisciplina, "cbxDisciplina");
            this.cbxDisciplina.Name = "cbxDisciplina";
            this.cbxDisciplina.SelectedIndexChanged += new System.EventHandler(this.cbxDisciplina_SelectedIndexChanged);
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnGravar, "btnGravar");
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // nudNumeroQuestoes
            // 
            resources.ApplyResources(this.nudNumeroQuestoes, "nudNumeroQuestoes");
            this.nudNumeroQuestoes.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudNumeroQuestoes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroQuestoes.Name = "nudNumeroQuestoes";
            this.nudNumeroQuestoes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbxMateria
            // 
            this.cbxMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMateria.FormattingEnabled = true;
            resources.ApplyResources(this.cbxMateria, "cbxMateria");
            this.cbxMateria.Name = "cbxMateria";
            this.cbxMateria.SelectedIndexChanged += new System.EventHandler(this.cbxMateria_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // labelDateTime
            // 
            resources.ApplyResources(this.labelDateTime, "labelDateTime");
            this.labelDateTime.ForeColor = System.Drawing.Color.Red;
            this.labelDateTime.Name = "labelDateTime";
            // 
            // rbTxtTitle
            // 
            resources.ApplyResources(this.rbTxtTitle, "rbTxtTitle");
            this.rbTxtTitle.Name = "rbTxtTitle";
            // 
            // TesteDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbTxtTitle);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.cbxMateria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudNumeroQuestoes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.cbxDisciplina);
            this.Controls.Add(this.lblDisciplina);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblNQuestoes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TesteDialog";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroQuestoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNQuestoes;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.ComboBox cbxDisciplina;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown nudNumeroQuestoes;
        private System.Windows.Forms.ComboBox cbxMateria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.RichTextBox rbTxtTitle;
    }
}