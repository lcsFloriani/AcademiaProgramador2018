namespace Pizzaria.WinApp
{
    partial class PrincipalForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripbtnGravar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripbtnEditar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripbtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripFiltro = new System.Windows.Forms.ToolStripButton();
            this.panelControl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PedidoToolStripMenuItem,
            this.ClienteToolStripMenuItem,
            this.ProdutoToolStripMenuItem});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.cadastroToolStripMenuItem.Text = "Arquivo";
            // 
            // PedidoToolStripMenuItem
            // 
            this.PedidoToolStripMenuItem.Name = "PedidoToolStripMenuItem";
            this.PedidoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.PedidoToolStripMenuItem.Text = "Pedido";
            this.PedidoToolStripMenuItem.Click += new System.EventHandler(this.PedidoToolStripMenuItem_Click);
            // 
            // ClienteToolStripMenuItem
            // 
            this.ClienteToolStripMenuItem.Name = "ClienteToolStripMenuItem";
            this.ClienteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.ClienteToolStripMenuItem.Text = "Cliente";
            this.ClienteToolStripMenuItem.Click += new System.EventHandler(this.ClienteToolStripMenuItem_Click);
            // 
            // ProdutoToolStripMenuItem
            // 
            this.ProdutoToolStripMenuItem.Name = "ProdutoToolStripMenuItem";
            this.ProdutoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.ProdutoToolStripMenuItem.Text = "Produto";
            this.ProdutoToolStripMenuItem.Click += new System.EventHandler(this.ProdutoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripbtnGravar,
            this.ToolStripbtnEditar,
            this.ToolStripbtnExcluir,
            this.toolStripFiltro});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1045, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripbtnGravar
            // 
            this.ToolStripbtnGravar.Enabled = false;
            this.ToolStripbtnGravar.Image = global::Pizzaria.WinApp.Properties.Resources.icon_salvar;
            this.ToolStripbtnGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripbtnGravar.Name = "ToolStripbtnGravar";
            this.ToolStripbtnGravar.Size = new System.Drawing.Size(61, 22);
            this.ToolStripbtnGravar.Text = "Gravar";
            this.ToolStripbtnGravar.Click += new System.EventHandler(this.ToolStripbtnGravar_Click);
            // 
            // ToolStripbtnEditar
            // 
            this.ToolStripbtnEditar.Enabled = false;
            this.ToolStripbtnEditar.Image = global::Pizzaria.WinApp.Properties.Resources.icon_editar;
            this.ToolStripbtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripbtnEditar.Name = "ToolStripbtnEditar";
            this.ToolStripbtnEditar.Size = new System.Drawing.Size(57, 22);
            this.ToolStripbtnEditar.Text = "Editar";
            this.ToolStripbtnEditar.Click += new System.EventHandler(this.ToolStripbtnEditar_Click);
            // 
            // ToolStripbtnExcluir
            // 
            this.ToolStripbtnExcluir.Enabled = false;
            this.ToolStripbtnExcluir.Image = global::Pizzaria.WinApp.Properties.Resources.icon_excluir;
            this.ToolStripbtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripbtnExcluir.Name = "ToolStripbtnExcluir";
            this.ToolStripbtnExcluir.Size = new System.Drawing.Size(61, 22);
            this.ToolStripbtnExcluir.Text = "Excluir";
            this.ToolStripbtnExcluir.Click += new System.EventHandler(this.ToolStripbtnExcluir_Click);
            // 
            // toolStripFiltro
            // 
            this.toolStripFiltro.Enabled = false;
            this.toolStripFiltro.Image = global::Pizzaria.WinApp.Properties.Resources.icon_procura;
            this.toolStripFiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFiltro.Name = "toolStripFiltro";
            this.toolStripFiltro.Size = new System.Drawing.Size(57, 22);
            this.toolStripFiltro.Text = "Filtrar";
            this.toolStripFiltro.Click += new System.EventHandler(this.toolStripFiltro_Click);
            // 
            // panelControl
            // 
            this.panelControl.Location = new System.Drawing.Point(12, 52);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1021, 516);
            this.panelControl.TabIndex = 2;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 580);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PrincipalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sartor Pizzas e Calzone";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripbtnGravar;
        private System.Windows.Forms.ToolStripButton ToolStripbtnEditar;
        private System.Windows.Forms.ToolStripButton ToolStripbtnExcluir;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ToolStripMenuItem ClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripFiltro;
    }
}

