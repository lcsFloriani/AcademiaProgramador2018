namespace Pizzaria.WinApp.Features.Pedidos
{
    partial class PedidoDialog
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
            this.listPedidos = new System.Windows.Forms.ListBox();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblSetor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.txtSetor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabProdutos = new System.Windows.Forms.TabControl();
            this.tabPizzas = new System.Windows.Forms.TabPage();
            this.cbxTamanho = new System.Windows.Forms.ComboBox();
            this.nudQuantidadePizza = new System.Windows.Forms.NumericUpDown();
            this.btnAdicionarPizza = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxSaborBorda = new System.Windows.Forms.ComboBox();
            this.cbBorda = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxSabor2 = new System.Windows.Forms.ComboBox();
            this.cbMeia = new System.Windows.Forms.CheckBox();
            this.cbxSabor1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabCalzones = new System.Windows.Forms.TabPage();
            this.btnAdicionarCalzone = new System.Windows.Forms.Button();
            this.nudQuantidadeCalzone = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxSaborCalzone = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabBebidas = new System.Windows.Forms.TabPage();
            this.btnAdicionarBebida = new System.Windows.Forms.Button();
            this.cbxBebida = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.nudQuantidadeBebida = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnProcuraPorTelefone = new System.Windows.Forms.Button();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCartao = new System.Windows.Forms.ComboBox();
            this.cbEmitirNFe = new System.Windows.Forms.CheckBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtxObservacao = new System.Windows.Forms.RichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabProdutos.SuspendLayout();
            this.tabPizzas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadePizza)).BeginInit();
            this.tabCalzones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeCalzone)).BeginInit();
            this.tabBebidas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeBebida)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPedidos
            // 
            this.listPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPedidos.FormattingEnabled = true;
            this.listPedidos.ItemHeight = 15;
            this.listPedidos.Location = new System.Drawing.Point(10, 23);
            this.listPedidos.Name = "listPedidos";
            this.listPedidos.Size = new System.Drawing.Size(628, 199);
            this.listPedidos.TabIndex = 19;
            this.listPedidos.SelectedIndexChanged += new System.EventHandler(this.listPedidos_SelectedIndexChanged);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(594, 566);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(66, 30);
            this.lblValorTotal.TabIndex = 5;
            this.lblValorTotal.Text = "0.00";
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(970, 566);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(105, 28);
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(1083, 566);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(105, 28);
            this.btnLimpar.TabIndex = 20;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetor.Location = new System.Drawing.Point(115, 101);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(39, 15);
            this.lblSetor.TabIndex = 8;
            this.lblSetor.Text = "Setor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Responsável:";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Enabled = false;
            this.txtResponsavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponsavel.Location = new System.Drawing.Point(160, 71);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(336, 21);
            this.txtResponsavel.TabIndex = 11;
            // 
            // txtSetor
            // 
            this.txtSetor.Enabled = false;
            this.txtSetor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetor.Location = new System.Drawing.Point(160, 98);
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.Size = new System.Drawing.Size(336, 21);
            this.txtSetor.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabProdutos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(682, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 262);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item do Pedido";
            // 
            // tabProdutos
            // 
            this.tabProdutos.Controls.Add(this.tabPizzas);
            this.tabProdutos.Controls.Add(this.tabCalzones);
            this.tabProdutos.Controls.Add(this.tabBebidas);
            this.tabProdutos.Location = new System.Drawing.Point(6, 20);
            this.tabProdutos.Name = "tabProdutos";
            this.tabProdutos.SelectedIndex = 0;
            this.tabProdutos.Size = new System.Drawing.Size(500, 236);
            this.tabProdutos.TabIndex = 3;
            // 
            // tabPizzas
            // 
            this.tabPizzas.Controls.Add(this.cbxTamanho);
            this.tabPizzas.Controls.Add(this.nudQuantidadePizza);
            this.tabPizzas.Controls.Add(this.btnAdicionarPizza);
            this.tabPizzas.Controls.Add(this.label11);
            this.tabPizzas.Controls.Add(this.cbxSaborBorda);
            this.tabPizzas.Controls.Add(this.cbBorda);
            this.tabPizzas.Controls.Add(this.label8);
            this.tabPizzas.Controls.Add(this.cbxSabor2);
            this.tabPizzas.Controls.Add(this.cbMeia);
            this.tabPizzas.Controls.Add(this.cbxSabor1);
            this.tabPizzas.Controls.Add(this.label6);
            this.tabPizzas.Location = new System.Drawing.Point(4, 24);
            this.tabPizzas.Name = "tabPizzas";
            this.tabPizzas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPizzas.Size = new System.Drawing.Size(492, 208);
            this.tabPizzas.TabIndex = 0;
            this.tabPizzas.Text = "Pizzas";
            this.tabPizzas.UseVisualStyleBackColor = true;
            // 
            // cbxTamanho
            // 
            this.cbxTamanho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTamanho.FormattingEnabled = true;
            this.cbxTamanho.Location = new System.Drawing.Point(96, 13);
            this.cbxTamanho.Name = "cbxTamanho";
            this.cbxTamanho.Size = new System.Drawing.Size(374, 23);
            this.cbxTamanho.TabIndex = 3;
            this.cbxTamanho.SelectedIndexChanged += new System.EventHandler(this.cbxTamanho_SelectedIndexChanged);
            // 
            // nudQuantidadePizza
            // 
            this.nudQuantidadePizza.Location = new System.Drawing.Point(96, 162);
            this.nudQuantidadePizza.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidadePizza.Name = "nudQuantidadePizza";
            this.nudQuantidadePizza.Size = new System.Drawing.Size(56, 21);
            this.nudQuantidadePizza.TabIndex = 9;
            this.nudQuantidadePizza.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAdicionarPizza
            // 
            this.btnAdicionarPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarPizza.Location = new System.Drawing.Point(365, 162);
            this.btnAdicionarPizza.Name = "btnAdicionarPizza";
            this.btnAdicionarPizza.Size = new System.Drawing.Size(105, 28);
            this.btnAdicionarPizza.TabIndex = 11;
            this.btnAdicionarPizza.Text = "Adicionar";
            this.btnAdicionarPizza.UseVisualStyleBackColor = true;
            this.btnAdicionarPizza.Click += new System.EventHandler(this.btnAdicionarPizza_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Quantidade:";
            // 
            // cbxSaborBorda
            // 
            this.cbxSaborBorda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaborBorda.Enabled = false;
            this.cbxSaborBorda.FormattingEnabled = true;
            this.cbxSaborBorda.Location = new System.Drawing.Point(96, 122);
            this.cbxSaborBorda.Name = "cbxSaborBorda";
            this.cbxSaborBorda.Size = new System.Drawing.Size(374, 23);
            this.cbxSaborBorda.TabIndex = 8;
            // 
            // cbBorda
            // 
            this.cbBorda.AutoSize = true;
            this.cbBorda.Location = new System.Drawing.Point(13, 126);
            this.cbBorda.Name = "cbBorda";
            this.cbBorda.Size = new System.Drawing.Size(59, 19);
            this.cbBorda.TabIndex = 7;
            this.cbBorda.Text = "Borda";
            this.cbBorda.UseVisualStyleBackColor = true;
            this.cbBorda.CheckedChanged += new System.EventHandler(this.cbBorda_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tamanho:";
            // 
            // cbxSabor2
            // 
            this.cbxSabor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSabor2.Enabled = false;
            this.cbxSabor2.FormattingEnabled = true;
            this.cbxSabor2.Location = new System.Drawing.Point(96, 85);
            this.cbxSabor2.Name = "cbxSabor2";
            this.cbxSabor2.Size = new System.Drawing.Size(374, 23);
            this.cbxSabor2.TabIndex = 6;
            // 
            // cbMeia
            // 
            this.cbMeia.AutoSize = true;
            this.cbMeia.Location = new System.Drawing.Point(13, 87);
            this.cbMeia.Name = "cbMeia";
            this.cbMeia.Size = new System.Drawing.Size(69, 19);
            this.cbMeia.TabIndex = 5;
            this.cbMeia.Text = "Sabor 2";
            this.cbMeia.UseVisualStyleBackColor = true;
            this.cbMeia.CheckedChanged += new System.EventHandler(this.cbMeia_CheckedChanged);
            // 
            // cbxSabor1
            // 
            this.cbxSabor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSabor1.FormattingEnabled = true;
            this.cbxSabor1.Location = new System.Drawing.Point(96, 49);
            this.cbxSabor1.Name = "cbxSabor1";
            this.cbxSabor1.Size = new System.Drawing.Size(374, 23);
            this.cbxSabor1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sabor 1:";
            // 
            // tabCalzones
            // 
            this.tabCalzones.Controls.Add(this.btnAdicionarCalzone);
            this.tabCalzones.Controls.Add(this.nudQuantidadeCalzone);
            this.tabCalzones.Controls.Add(this.label12);
            this.tabCalzones.Controls.Add(this.cbxSaborCalzone);
            this.tabCalzones.Controls.Add(this.label10);
            this.tabCalzones.Location = new System.Drawing.Point(4, 24);
            this.tabCalzones.Name = "tabCalzones";
            this.tabCalzones.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalzones.Size = new System.Drawing.Size(492, 208);
            this.tabCalzones.TabIndex = 1;
            this.tabCalzones.Text = "Calzones";
            this.tabCalzones.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarCalzone
            // 
            this.btnAdicionarCalzone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarCalzone.Location = new System.Drawing.Point(366, 169);
            this.btnAdicionarCalzone.Name = "btnAdicionarCalzone";
            this.btnAdicionarCalzone.Size = new System.Drawing.Size(105, 28);
            this.btnAdicionarCalzone.TabIndex = 14;
            this.btnAdicionarCalzone.Text = "Adicionar ";
            this.btnAdicionarCalzone.UseVisualStyleBackColor = true;
            this.btnAdicionarCalzone.Click += new System.EventHandler(this.btnAdicionarCalzone_Click);
            // 
            // nudQuantidadeCalzone
            // 
            this.nudQuantidadeCalzone.Location = new System.Drawing.Point(103, 56);
            this.nudQuantidadeCalzone.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidadeCalzone.Name = "nudQuantidadeCalzone";
            this.nudQuantidadeCalzone.Size = new System.Drawing.Size(56, 21);
            this.nudQuantidadeCalzone.TabIndex = 13;
            this.nudQuantidadeCalzone.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 15);
            this.label12.TabIndex = 14;
            this.label12.Text = "Quantidade:";
            // 
            // cbxSaborCalzone
            // 
            this.cbxSaborCalzone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaborCalzone.FormattingEnabled = true;
            this.cbxSaborCalzone.Location = new System.Drawing.Point(103, 22);
            this.cbxSaborCalzone.Name = "cbxSaborCalzone";
            this.cbxSaborCalzone.Size = new System.Drawing.Size(368, 23);
            this.cbxSaborCalzone.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Sabor:";
            // 
            // tabBebidas
            // 
            this.tabBebidas.Controls.Add(this.btnAdicionarBebida);
            this.tabBebidas.Controls.Add(this.cbxBebida);
            this.tabBebidas.Controls.Add(this.label14);
            this.tabBebidas.Controls.Add(this.nudQuantidadeBebida);
            this.tabBebidas.Controls.Add(this.label13);
            this.tabBebidas.Location = new System.Drawing.Point(4, 24);
            this.tabBebidas.Name = "tabBebidas";
            this.tabBebidas.Padding = new System.Windows.Forms.Padding(3);
            this.tabBebidas.Size = new System.Drawing.Size(492, 208);
            this.tabBebidas.TabIndex = 2;
            this.tabBebidas.Text = "Bebidas";
            this.tabBebidas.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarBebida
            // 
            this.btnAdicionarBebida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarBebida.Location = new System.Drawing.Point(362, 165);
            this.btnAdicionarBebida.Name = "btnAdicionarBebida";
            this.btnAdicionarBebida.Size = new System.Drawing.Size(105, 28);
            this.btnAdicionarBebida.TabIndex = 17;
            this.btnAdicionarBebida.Text = "Adicionar ";
            this.btnAdicionarBebida.UseVisualStyleBackColor = true;
            this.btnAdicionarBebida.Click += new System.EventHandler(this.btnAdicionarBebida_Click);
            // 
            // cbxBebida
            // 
            this.cbxBebida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBebida.FormattingEnabled = true;
            this.cbxBebida.Location = new System.Drawing.Point(104, 22);
            this.cbxBebida.Name = "cbxBebida";
            this.cbxBebida.Size = new System.Drawing.Size(363, 23);
            this.cbxBebida.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 15);
            this.label14.TabIndex = 16;
            this.label14.Text = "Sabor:";
            // 
            // nudQuantidadeBebida
            // 
            this.nudQuantidadeBebida.Location = new System.Drawing.Point(104, 57);
            this.nudQuantidadeBebida.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidadeBebida.Name = "nudQuantidadeBebida";
            this.nudQuantidadeBebida.Size = new System.Drawing.Size(56, 21);
            this.nudQuantidadeBebida.TabIndex = 16;
            this.nudQuantidadeBebida.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "Quantidade:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtComplemento);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtNumero);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtBairro);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtLogradouro);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtClienteNome);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnProcuraPorTelefone);
            this.groupBox2.Controls.Add(this.txtTelefone);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(653, 262);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busca de Cliente por Telefone";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Enabled = false;
            this.txtComplemento.Location = new System.Drawing.Point(13, 213);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(625, 21);
            this.txtComplemento.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 196);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "Complemento";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(406, 167);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(232, 21);
            this.txtNumero.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(403, 149);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 15);
            this.label16.TabIndex = 8;
            this.label16.Text = "Número";
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Location = new System.Drawing.Point(13, 168);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(387, 21);
            this.txtBairro.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 149);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 15);
            this.label15.TabIndex = 6;
            this.label15.Text = "Bairro";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Enabled = false;
            this.txtLogradouro.Location = new System.Drawing.Point(10, 121);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(628, 21);
            this.txtLogradouro.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Logradouro";
            // 
            // txtClienteNome
            // 
            this.txtClienteNome.Enabled = false;
            this.txtClienteNome.Location = new System.Drawing.Point(10, 69);
            this.txtClienteNome.Name = "txtClienteNome";
            this.txtClienteNome.Size = new System.Drawing.Size(628, 21);
            this.txtClienteNome.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cliente";
            // 
            // btnProcuraPorTelefone
            // 
            this.btnProcuraPorTelefone.Image = global::Pizzaria.WinApp.Properties.Resources.icon_procura;
            this.btnProcuraPorTelefone.Location = new System.Drawing.Point(354, 20);
            this.btnProcuraPorTelefone.Name = "btnProcuraPorTelefone";
            this.btnProcuraPorTelefone.Size = new System.Drawing.Size(75, 23);
            this.btnProcuraPorTelefone.TabIndex = 2;
            this.btnProcuraPorTelefone.UseVisualStyleBackColor = true;
            this.btnProcuraPorTelefone.Click += new System.EventHandler(this.btnProcuraPorTelefone_Click);
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(10, 20);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(329, 21);
            this.txtTelefone.TabIndex = 1;
            this.txtTelefone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelefone_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemover);
            this.groupBox3.Controls.Add(this.listPedidos);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(653, 262);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Itens do Pedido";
            // 
            // btnRemover
            // 
            this.btnRemover.Image = global::Pizzaria.WinApp.Properties.Resources.icon_remover;
            this.btnRemover.Location = new System.Drawing.Point(563, 229);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 20;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(448, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor total R$:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Forma de Pagamento:";
            // 
            // cbxCartao
            // 
            this.cbxCartao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCartao.FormattingEnabled = true;
            this.cbxCartao.Location = new System.Drawing.Point(160, 42);
            this.cbxCartao.Name = "cbxCartao";
            this.cbxCartao.Size = new System.Drawing.Size(336, 23);
            this.cbxCartao.TabIndex = 10;
            // 
            // cbEmitirNFe
            // 
            this.cbEmitirNFe.AutoSize = true;
            this.cbEmitirNFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmitirNFe.Location = new System.Drawing.Point(160, 129);
            this.cbEmitirNFe.Name = "cbEmitirNFe";
            this.cbEmitirNFe.Size = new System.Drawing.Size(84, 19);
            this.cbEmitirNFe.TabIndex = 13;
            this.cbEmitirNFe.Text = "Emitir NFe";
            this.cbEmitirNFe.UseVisualStyleBackColor = true;
            this.cbEmitirNFe.CheckedChanged += new System.EventHandler(this.cbEmitirNFe_CheckedChanged);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(73, 157);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(77, 15);
            this.lblDocumento.TabIndex = 22;
            this.lblDocumento.Text = " Documento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(160, 154);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(336, 21);
            this.txtDocumento.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtxObservacao);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.cbxCartao);
            this.groupBox4.Controls.Add(this.txtDocumento);
            this.groupBox4.Controls.Add(this.txtSetor);
            this.groupBox4.Controls.Add(this.lblDocumento);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtResponsavel);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.lblSetor);
            this.groupBox4.Controls.Add(this.cbEmitirNFe);
            this.groupBox4.Location = new System.Drawing.Point(682, 283);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(512, 262);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informações Sobre o Pedido";
            // 
            // rtxObservacao
            // 
            this.rtxObservacao.Location = new System.Drawing.Point(160, 181);
            this.rtxObservacao.Name = "rtxObservacao";
            this.rtxObservacao.Size = new System.Drawing.Size(336, 71);
            this.rtxObservacao.TabIndex = 15;
            this.rtxObservacao.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(86, 210);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Observação:";
            // 
            // PedidoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 611);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PedidoDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Realizar Pedido";
            this.groupBox1.ResumeLayout(false);
            this.tabProdutos.ResumeLayout(false);
            this.tabPizzas.ResumeLayout(false);
            this.tabPizzas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadePizza)).EndInit();
            this.tabCalzones.ResumeLayout(false);
            this.tabCalzones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeCalzone)).EndInit();
            this.tabBebidas.ResumeLayout(false);
            this.tabBebidas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeBebida)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listPedidos;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.TextBox txtSetor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdicionarPizza;
        private System.Windows.Forms.TabControl tabProdutos;
        private System.Windows.Forms.TabPage tabPizzas;
        private System.Windows.Forms.TabPage tabCalzones;
        private System.Windows.Forms.TabPage tabBebidas;
        private System.Windows.Forms.ComboBox cbxSaborBorda;
        private System.Windows.Forms.CheckBox cbBorda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxSabor2;
        private System.Windows.Forms.CheckBox cbMeia;
        private System.Windows.Forms.ComboBox cbxSabor1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxSaborCalzone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudQuantidadePizza;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudQuantidadeCalzone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudQuantidadeBebida;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxBebida;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdicionarCalzone;
        private System.Windows.Forms.Button btnAdicionarBebida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCartao;
        private System.Windows.Forms.CheckBox cbEmitirNFe;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClienteNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnProcuraPorTelefone;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.ComboBox cbxTamanho;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox rtxObservacao;
        private System.Windows.Forms.Label label18;
    }
}