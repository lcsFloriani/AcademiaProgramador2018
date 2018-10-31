namespace GerenciadorProvas.WinApp
{
    partial class PrincipalForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnGerar = new System.Windows.Forms.ToolStripButton();
            this.tsbCSV = new System.Windows.Forms.ToolStripButton();
            this.tsbXML = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disciplinaToolStripMenuItem,
            this.serieToolStripMenuItem,
            this.materiaToolStripMenuItem,
            this.questaoToolStripMenuItem,
            this.testeToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // disciplinaToolStripMenuItem
            // 
            this.disciplinaToolStripMenuItem.Name = "disciplinaToolStripMenuItem";
            this.disciplinaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.disciplinaToolStripMenuItem.Text = "Disciplina";
            this.disciplinaToolStripMenuItem.Click += new System.EventHandler(this.disciplinaToolStripMenuItem_Click);
            // 
            // serieToolStripMenuItem
            // 
            this.serieToolStripMenuItem.Name = "serieToolStripMenuItem";
            this.serieToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.serieToolStripMenuItem.Text = "Série";
            this.serieToolStripMenuItem.Click += new System.EventHandler(this.serieToolStripMenuItem_Click);
            // 
            // materiaToolStripMenuItem
            // 
            this.materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            this.materiaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.materiaToolStripMenuItem.Text = "Matéria";
            this.materiaToolStripMenuItem.Click += new System.EventHandler(this.materiaToolStripMenuItem_Click);
            // 
            // questaoToolStripMenuItem
            // 
            this.questaoToolStripMenuItem.Name = "questaoToolStripMenuItem";
            this.questaoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.questaoToolStripMenuItem.Text = "Questão";
            this.questaoToolStripMenuItem.Click += new System.EventHandler(this.questaoToolStripMenuItem_Click);
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.testeToolStripMenuItem.Text = "Teste";
            this.testeToolStripMenuItem.Click += new System.EventHandler(this.testeToolStripMenuItem_Click);
            // 
            // panelControl
            // 
            this.panelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl.Location = new System.Drawing.Point(12, 52);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(826, 362);
            this.panelControl.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnSalvar,
            this.toolStripBtnEditar,
            this.toolStripBtnExcluir,
            this.toolStripBtnGerar,
            this.tsbCSV,
            this.tsbXML,
            this.toolStripSeparator1,
            this.labelTipoCadastro});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(427, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnSalvar
            // 
            this.toolStripBtnSalvar.Enabled = false;
            this.toolStripBtnSalvar.Image = global::GerenciadorProvas.WinApp.Properties.Resources.save;
            this.toolStripBtnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalvar.Name = "toolStripBtnSalvar";
            this.toolStripBtnSalvar.Size = new System.Drawing.Size(61, 22);
            this.toolStripBtnSalvar.Text = "Gravar";
            this.toolStripBtnSalvar.Click += new System.EventHandler(this.toolStripBtnSalvar_Click);
            // 
            // toolStripBtnEditar
            // 
            this.toolStripBtnEditar.Enabled = false;
            this.toolStripBtnEditar.Image = global::GerenciadorProvas.WinApp.Properties.Resources.pencil;
            this.toolStripBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEditar.Name = "toolStripBtnEditar";
            this.toolStripBtnEditar.Size = new System.Drawing.Size(57, 22);
            this.toolStripBtnEditar.Text = "Editar";
            this.toolStripBtnEditar.Click += new System.EventHandler(this.toolStripBtnEditar_Click);
            // 
            // toolStripBtnExcluir
            // 
            this.toolStripBtnExcluir.Enabled = false;
            this.toolStripBtnExcluir.Image = global::GerenciadorProvas.WinApp.Properties.Resources.rubbish_bin;
            this.toolStripBtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExcluir.Name = "toolStripBtnExcluir";
            this.toolStripBtnExcluir.Size = new System.Drawing.Size(61, 22);
            this.toolStripBtnExcluir.Text = "Excluir";
            this.toolStripBtnExcluir.Click += new System.EventHandler(this.toolStripBtnExcluir_Click);
            // 
            // toolStripBtnGerar
            // 
            this.toolStripBtnGerar.Enabled = false;
            this.toolStripBtnGerar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnGerar.Image")));
            this.toolStripBtnGerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnGerar.Name = "toolStripBtnGerar";
            this.toolStripBtnGerar.Size = new System.Drawing.Size(48, 22);
            this.toolStripBtnGerar.Text = "PDF";
            this.toolStripBtnGerar.Click += new System.EventHandler(this.toolStripBtnGerar_Click);
            // 
            // tsbCSV
            // 
            this.tsbCSV.Enabled = false;
            this.tsbCSV.Image = ((System.Drawing.Image)(resources.GetObject("tsbCSV.Image")));
            this.tsbCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCSV.Name = "tsbCSV";
            this.tsbCSV.Size = new System.Drawing.Size(48, 22);
            this.tsbCSV.Text = "CSV";
            this.tsbCSV.Click += new System.EventHandler(this.tsbCSV_Click);
            // 
            // tsbXML
            // 
            this.tsbXML.Enabled = false;
            this.tsbXML.Image = ((System.Drawing.Image)(resources.GetObject("tsbXML.Image")));
            this.tsbXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbXML.Name = "tsbXML";
            this.tsbXML.Size = new System.Drawing.Size(51, 22);
            this.tsbXML.Text = "XML";
            this.tsbXML.Click += new System.EventHandler(this.tsbXML_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(52, 22);
            this.labelTipoCadastro.Text = "cadastro";
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(850, 426);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador de Provas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questaoToolStripMenuItem;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalvar;
        private System.Windows.Forms.ToolStripButton toolStripBtnEditar;
        private System.Windows.Forms.ToolStripButton toolStripBtnExcluir;
        private System.Windows.Forms.ToolStripButton toolStripBtnGerar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripMenuItem serieToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbCSV;
        private System.Windows.Forms.ToolStripButton tsbXML;
    }
}

