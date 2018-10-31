namespace Banco.WindowsApp
{
    partial class Banco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Banco));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contaCorrenteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSCadastrar = new System.Windows.Forms.ToolStripButton();
            this.tSExcluir = new System.Windows.Forms.ToolStripButton();
            this.tSSaque = new System.Windows.Forms.ToolStripButton();
            this.tSDeposito = new System.Windows.Forms.ToolStripButton();
            this.tSTransferencia = new System.Windows.Forms.ToolStripButton();
            this.tSExtrato = new System.Windows.Forms.ToolStripButton();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.panelControl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contaCorrenteMenuItem,
            this.clienteMenuItem,
            this.sairMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            this.cadastrosToolStripMenuItem.Click += new System.EventHandler(this.cadastrosToolStripMenuItem_Click);
            // 
            // contaCorrenteMenuItem
            // 
            this.contaCorrenteMenuItem.DoubleClickEnabled = true;
            this.contaCorrenteMenuItem.Name = "contaCorrenteMenuItem";
            this.contaCorrenteMenuItem.Size = new System.Drawing.Size(155, 22);
            this.contaCorrenteMenuItem.Text = "Conta Corrente";
            this.contaCorrenteMenuItem.Click += new System.EventHandler(this.contaCorrenteMenuItem_Click);
            // 
            // clienteMenuItem
            // 
            this.clienteMenuItem.Name = "clienteMenuItem";
            this.clienteMenuItem.Size = new System.Drawing.Size(155, 22);
            this.clienteMenuItem.Text = "Cliente";
            this.clienteMenuItem.Click += new System.EventHandler(this.clienteMenuItem_Click);
            // 
            // sairMenuItem
            // 
            this.sairMenuItem.Name = "sairMenuItem";
            this.sairMenuItem.Size = new System.Drawing.Size(155, 22);
            this.sairMenuItem.Text = "Sair";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSCadastrar,
            this.tSExcluir,
            this.tSSaque,
            this.tSDeposito,
            this.tSTransferencia,
            this.tSExtrato,
            this.labelTipoCadastro});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(717, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSCadastrar
            // 
            this.tSCadastrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSCadastrar.Enabled = false;
            this.tSCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("tSCadastrar.Image")));
            this.tSCadastrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSCadastrar.Name = "tSCadastrar";
            this.tSCadastrar.Size = new System.Drawing.Size(96, 22);
            this.tSCadastrar.Text = "Cadastrar Conta";
            this.tSCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // tSExcluir
            // 
            this.tSExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSExcluir.Image = ((System.Drawing.Image)(resources.GetObject("tSExcluir.Image")));
            this.tSExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSExcluir.Name = "tSExcluir";
            this.tSExcluir.Size = new System.Drawing.Size(80, 22);
            this.tSExcluir.Text = "Excluir Conta";
            this.tSExcluir.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // tSSaque
            // 
            this.tSSaque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSSaque.Image = ((System.Drawing.Image)(resources.GetObject("tSSaque.Image")));
            this.tSSaque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSSaque.Name = "tSSaque";
            this.tSSaque.Size = new System.Drawing.Size(86, 22);
            this.tSSaque.Text = "Realizar Saque";
            this.tSSaque.Click += new System.EventHandler(this.tSSaque_Click);
            // 
            // tSDeposito
            // 
            this.tSDeposito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSDeposito.Image = ((System.Drawing.Image)(resources.GetObject("tSDeposito.Image")));
            this.tSDeposito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSDeposito.Name = "tSDeposito";
            this.tSDeposito.Size = new System.Drawing.Size(101, 22);
            this.tSDeposito.Text = "Realizar Deposito";
            this.tSDeposito.Click += new System.EventHandler(this.tSDeposito_Click);
            // 
            // tSTransferencia
            // 
            this.tSTransferencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSTransferencia.Image = ((System.Drawing.Image)(resources.GetObject("tSTransferencia.Image")));
            this.tSTransferencia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSTransferencia.Name = "tSTransferencia";
            this.tSTransferencia.Size = new System.Drawing.Size(86, 22);
            this.tSTransferencia.Text = "Transferir para";
            this.tSTransferencia.Click += new System.EventHandler(this.tSTransferencia_Click);
            // 
            // tSExtrato
            // 
            this.tSExtrato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSExtrato.Image = ((System.Drawing.Image)(resources.GetObject("tSExtrato.Image")));
            this.tSExtrato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSExtrato.Name = "tSExtrato";
            this.tSExtrato.Size = new System.Drawing.Size(78, 22);
            this.tSExtrato.Text = "Exibir Extrato";
            this.tSExtrato.Click += new System.EventHandler(this.tSExtrato_Click);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Enabled = false;
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(60, 22);
            this.labelTipoCadastro.Text = "[cadastro]";
            // 
            // panelControl
            // 
            this.panelControl.Location = new System.Drawing.Point(12, 62);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(693, 331);
            this.panelControl.TabIndex = 2;
            // 
            // Banco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 405);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Banco";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contaCorrenteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSCadastrar;
        private System.Windows.Forms.ToolStripButton tSExcluir;
        private System.Windows.Forms.ToolStripButton tSSaque;
        private System.Windows.Forms.ToolStripButton tSDeposito;
        private System.Windows.Forms.ToolStripButton tSTransferencia;
        private System.Windows.Forms.ToolStripButton tSExtrato;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ToolStripMenuItem clienteMenuItem;
    }
}

