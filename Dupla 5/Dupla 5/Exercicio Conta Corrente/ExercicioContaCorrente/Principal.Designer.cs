namespace ExercicioContaCorrente
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panelControl = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contasCorrentesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAtualizar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnRealizarSaque = new System.Windows.Forms.ToolStripButton();
            this.btnRealizarDeposito = new System.Windows.Forms.ToolStripButton();
            this.btnTransferirPara = new System.Windows.Forms.ToolStripButton();
            this.btnExibirExtrato = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCadastrar = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Location = new System.Drawing.Point(11, 65);
            this.panelControl.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(951, 319);
            this.panelControl.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(973, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contasCorrentesMenuItem,
            this.clientesMenuItem,
            this.sairToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // contasCorrentesMenuItem
            // 
            this.contasCorrentesMenuItem.Name = "contasCorrentesMenuItem";
            this.contasCorrentesMenuItem.Size = new System.Drawing.Size(165, 22);
            this.contasCorrentesMenuItem.Text = "Contas Correntes";
            this.contasCorrentesMenuItem.Click += new System.EventHandler(this.contasCorrentesMenuItem_Click);
            // 
            // clientesMenuItem
            // 
            this.clientesMenuItem.Name = "clientesMenuItem";
            this.clientesMenuItem.Size = new System.Drawing.Size(165, 22);
            this.clientesMenuItem.Text = "Clientes";
            this.clientesMenuItem.Click += new System.EventHandler(this.clientesMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Padding = new System.Windows.Forms.Padding(8);
            this.btnAtualizar.Size = new System.Drawing.Size(108, 35);
            this.btnAtualizar.Text = "Atualizar Conta";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(8);
            this.btnExcluir.Size = new System.Drawing.Size(96, 35);
            this.btnExcluir.Text = "Excluir Conta";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnRealizarSaque
            // 
            this.btnRealizarSaque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRealizarSaque.Image = ((System.Drawing.Image)(resources.GetObject("btnRealizarSaque.Image")));
            this.btnRealizarSaque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRealizarSaque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRealizarSaque.Name = "btnRealizarSaque";
            this.btnRealizarSaque.Padding = new System.Windows.Forms.Padding(8);
            this.btnRealizarSaque.Size = new System.Drawing.Size(102, 35);
            this.btnRealizarSaque.Text = "Realizar Saque";
            this.btnRealizarSaque.Click += new System.EventHandler(this.btnRealizarSaque_Click);
            // 
            // btnRealizarDeposito
            // 
            this.btnRealizarDeposito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRealizarDeposito.Image = ((System.Drawing.Image)(resources.GetObject("btnRealizarDeposito.Image")));
            this.btnRealizarDeposito.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRealizarDeposito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRealizarDeposito.Name = "btnRealizarDeposito";
            this.btnRealizarDeposito.Padding = new System.Windows.Forms.Padding(8);
            this.btnRealizarDeposito.Size = new System.Drawing.Size(117, 35);
            this.btnRealizarDeposito.Text = "Realizar Depósito";
            this.btnRealizarDeposito.Click += new System.EventHandler(this.btnRealizarDeposito_Click);
            // 
            // btnTransferirPara
            // 
            this.btnTransferirPara.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTransferirPara.Image = ((System.Drawing.Image)(resources.GetObject("btnTransferirPara.Image")));
            this.btnTransferirPara.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTransferirPara.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransferirPara.Name = "btnTransferirPara";
            this.btnTransferirPara.Padding = new System.Windows.Forms.Padding(8);
            this.btnTransferirPara.Size = new System.Drawing.Size(102, 35);
            this.btnTransferirPara.Text = "Transferir para";
            this.btnTransferirPara.Click += new System.EventHandler(this.btnTransferirPara_Click);
            // 
            // btnExibirExtrato
            // 
            this.btnExibirExtrato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExibirExtrato.Image = ((System.Drawing.Image)(resources.GetObject("btnExibirExtrato.Image")));
            this.btnExibirExtrato.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExibirExtrato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExibirExtrato.Name = "btnExibirExtrato";
            this.btnExibirExtrato.Padding = new System.Windows.Forms.Padding(8);
            this.btnExibirExtrato.Size = new System.Drawing.Size(94, 35);
            this.btnExibirExtrato.Text = "Exibir Extrato";
            this.btnExibirExtrato.Click += new System.EventHandler(this.btnExibirExtrato_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(60, 35);
            this.labelTipoCadastro.Text = "[cadastro]";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCadastrar,
            this.btnAtualizar,
            this.btnExcluir,
            this.btnRealizarSaque,
            this.btnRealizarDeposito,
            this.btnTransferirPara,
            this.btnExibirExtrato,
            this.toolStripSeparator1,
            this.labelTipoCadastro});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(973, 38);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCadastrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Padding = new System.Windows.Forms.Padding(8);
            this.btnCadastrar.Size = new System.Drawing.Size(112, 35);
            this.btnCadastrar.Text = "Cadastrar Conta";
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click_1);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 395);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelControl);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contasCorrentesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnAtualizar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripButton btnRealizarSaque;
        private System.Windows.Forms.ToolStripButton btnRealizarDeposito;
        private System.Windows.Forms.ToolStripButton btnTransferirPara;
        private System.Windows.Forms.ToolStripButton btnExibirExtrato;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCadastrar;
    }
}