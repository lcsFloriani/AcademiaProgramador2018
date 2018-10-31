namespace Prova2.WinApp
{
    partial class Biblioteca
    {
        
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Biblioteca));
            this.tabBiblioteca = new System.Windows.Forms.TabControl();
            this.Cadastro = new System.Windows.Forms.TabPage();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDisponibilidade = new System.Windows.Forms.CheckBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.Consulta = new System.Windows.Forms.TabPage();
            this.btnRelatorioEmprestimo = new System.Windows.Forms.Button();
            this.btnRelatorioLivros = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lbLivros = new System.Windows.Forms.ListBox();
            this.Emprestimo = new System.Windows.Forms.TabPage();
            this.btnExitEdit = new System.Windows.Forms.Button();
            this.btnMulta = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdEmprestimo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditarEmprestimo = new System.Windows.Forms.Button();
            this.lbEmprestimo = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCadastroEmprestimo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbLivros = new System.Windows.Forms.ComboBox();
            this.Cliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.tabBiblioteca.SuspendLayout();
            this.Cadastro.SuspendLayout();
            this.Consulta.SuspendLayout();
            this.Emprestimo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBiblioteca
            // 
            this.tabBiblioteca.Controls.Add(this.Cadastro);
            this.tabBiblioteca.Controls.Add(this.Consulta);
            this.tabBiblioteca.Controls.Add(this.Emprestimo);
            this.tabBiblioteca.Location = new System.Drawing.Point(-1, 0);
            this.tabBiblioteca.Name = "tabBiblioteca";
            this.tabBiblioteca.SelectedIndex = 0;
            this.tabBiblioteca.Size = new System.Drawing.Size(448, 368);
            this.tabBiblioteca.TabIndex = 0;
            // 
            // Cadastro
            // 
            this.Cadastro.Controls.Add(this.txtVolume);
            this.Cadastro.Controls.Add(this.label6);
            this.Cadastro.Controls.Add(this.btnClear);
            this.Cadastro.Controls.Add(this.btnSave);
            this.Cadastro.Controls.Add(this.dateTime);
            this.Cadastro.Controls.Add(this.label5);
            this.Cadastro.Controls.Add(this.label4);
            this.Cadastro.Controls.Add(this.label3);
            this.Cadastro.Controls.Add(this.label2);
            this.Cadastro.Controls.Add(this.label1);
            this.Cadastro.Controls.Add(this.cbDisponibilidade);
            this.Cadastro.Controls.Add(this.txtAutor);
            this.Cadastro.Controls.Add(this.txtTema);
            this.Cadastro.Controls.Add(this.txtTitulo);
            this.Cadastro.Controls.Add(this.txtId);
            this.Cadastro.Location = new System.Drawing.Point(4, 22);
            this.Cadastro.Name = "Cadastro";
            this.Cadastro.Padding = new System.Windows.Forms.Padding(3);
            this.Cadastro.Size = new System.Drawing.Size(440, 342);
            this.Cadastro.TabIndex = 0;
            this.Cadastro.Text = "Cadastro";
            this.Cadastro.UseVisualStyleBackColor = true;
            this.Cadastro.Click += new System.EventHandler(this.Cadastro_Click);
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(109, 171);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(100, 20);
            this.txtVolume.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Volume";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(253, 252);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(97, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateTime
            // 
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime.Location = new System.Drawing.Point(109, 209);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(126, 20);
            this.dateTime.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Autor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Título";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID:";
            // 
            // cbDisponibilidade
            // 
            this.cbDisponibilidade.AutoSize = true;
            this.cbDisponibilidade.Location = new System.Drawing.Point(271, 205);
            this.cbDisponibilidade.Name = "cbDisponibilidade";
            this.cbDisponibilidade.Size = new System.Drawing.Size(97, 17);
            this.cbDisponibilidade.TabIndex = 6;
            this.cbDisponibilidade.Text = "Disponibilidade";
            this.cbDisponibilidade.UseVisualStyleBackColor = true;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(109, 132);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(259, 20);
            this.txtAutor.TabIndex = 3;
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(109, 94);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(259, 20);
            this.txtTema.TabIndex = 2;
            this.txtTema.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(109, 59);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(259, 20);
            this.txtTitulo.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(109, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(63, 20);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "0";
            this.txtId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Consulta
            // 
            this.Consulta.Controls.Add(this.btnRelatorioEmprestimo);
            this.Consulta.Controls.Add(this.btnRelatorioLivros);
            this.Consulta.Controls.Add(this.btnExcluir);
            this.Consulta.Controls.Add(this.btnEditar);
            this.Consulta.Controls.Add(this.lbLivros);
            this.Consulta.Location = new System.Drawing.Point(4, 22);
            this.Consulta.Name = "Consulta";
            this.Consulta.Padding = new System.Windows.Forms.Padding(3);
            this.Consulta.Size = new System.Drawing.Size(440, 342);
            this.Consulta.TabIndex = 1;
            this.Consulta.Text = "Consulta";
            this.Consulta.UseVisualStyleBackColor = true;
            this.Consulta.Click += new System.EventHandler(this.Consulta_Click);
            // 
            // btnRelatorioEmprestimo
            // 
            this.btnRelatorioEmprestimo.Location = new System.Drawing.Point(117, 250);
            this.btnRelatorioEmprestimo.Name = "btnRelatorioEmprestimo";
            this.btnRelatorioEmprestimo.Size = new System.Drawing.Size(115, 23);
            this.btnRelatorioEmprestimo.TabIndex = 4;
            this.btnRelatorioEmprestimo.Text = "Relatorio Empréstimo";
            this.btnRelatorioEmprestimo.UseVisualStyleBackColor = true;
            this.btnRelatorioEmprestimo.Click += new System.EventHandler(this.btnRelatorioEmprestimo_Click);
            // 
            // btnRelatorioLivros
            // 
            this.btnRelatorioLivros.Location = new System.Drawing.Point(9, 251);
            this.btnRelatorioLivros.Name = "btnRelatorioLivros";
            this.btnRelatorioLivros.Size = new System.Drawing.Size(102, 23);
            this.btnRelatorioLivros.TabIndex = 3;
            this.btnRelatorioLivros.Text = "Relatorio Livros";
            this.btnRelatorioLivros.UseVisualStyleBackColor = true;
            this.btnRelatorioLivros.Click += new System.EventHandler(this.btnRelatorioLivros_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Location = new System.Drawing.Point(343, 250);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(252, 251);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lbLivros
            // 
            this.lbLivros.FormattingEnabled = true;
            this.lbLivros.Location = new System.Drawing.Point(9, 17);
            this.lbLivros.Name = "lbLivros";
            this.lbLivros.Size = new System.Drawing.Size(423, 212);
            this.lbLivros.TabIndex = 0;
            this.lbLivros.SelectedIndexChanged += new System.EventHandler(this.lbLivros_SelectedIndexChanged);
            // 
            // Emprestimo
            // 
            this.Emprestimo.Controls.Add(this.btnExitEdit);
            this.Emprestimo.Controls.Add(this.btnMulta);
            this.Emprestimo.Controls.Add(this.label9);
            this.Emprestimo.Controls.Add(this.txtIdEmprestimo);
            this.Emprestimo.Controls.Add(this.btnCancelar);
            this.Emprestimo.Controls.Add(this.btnEditarEmprestimo);
            this.Emprestimo.Controls.Add(this.lbEmprestimo);
            this.Emprestimo.Controls.Add(this.label8);
            this.Emprestimo.Controls.Add(this.dateTimePicker1);
            this.Emprestimo.Controls.Add(this.btnCadastroEmprestimo);
            this.Emprestimo.Controls.Add(this.label7);
            this.Emprestimo.Controls.Add(this.cmbLivros);
            this.Emprestimo.Controls.Add(this.Cliente);
            this.Emprestimo.Controls.Add(this.txtCliente);
            this.Emprestimo.Location = new System.Drawing.Point(4, 22);
            this.Emprestimo.Name = "Emprestimo";
            this.Emprestimo.Size = new System.Drawing.Size(440, 342);
            this.Emprestimo.TabIndex = 2;
            this.Emprestimo.Text = "Emprestimo";
            this.Emprestimo.UseVisualStyleBackColor = true;
            // 
            // btnExitEdit
            // 
            this.btnExitEdit.Location = new System.Drawing.Point(232, 310);
            this.btnExitEdit.Name = "btnExitEdit";
            this.btnExitEdit.Size = new System.Drawing.Size(85, 23);
            this.btnExitEdit.TabIndex = 13;
            this.btnExitEdit.Text = "Sair edição";
            this.btnExitEdit.UseVisualStyleBackColor = true;
            this.btnExitEdit.Click += new System.EventHandler(this.btnExitEdit_Click);
            // 
            // btnMulta
            // 
            this.btnMulta.Location = new System.Drawing.Point(45, 310);
            this.btnMulta.Name = "btnMulta";
            this.btnMulta.Size = new System.Drawing.Size(91, 23);
            this.btnMulta.TabIndex = 12;
            this.btnMulta.Text = "Multa";
            this.btnMulta.UseVisualStyleBackColor = true;
            this.btnMulta.Click += new System.EventHandler(this.btnMulta_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "ID:";
            // 
            // txtIdEmprestimo
            // 
            this.txtIdEmprestimo.Enabled = false;
            this.txtIdEmprestimo.Location = new System.Drawing.Point(71, 180);
            this.txtIdEmprestimo.Name = "txtIdEmprestimo";
            this.txtIdEmprestimo.Size = new System.Drawing.Size(20, 20);
            this.txtIdEmprestimo.TabIndex = 10;
            this.txtIdEmprestimo.Text = "0";
            this.txtIdEmprestimo.TextChanged += new System.EventHandler(this.txtIdEmprestimo_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(323, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Excluir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditarEmprestimo
            // 
            this.btnEditarEmprestimo.Enabled = false;
            this.btnEditarEmprestimo.Location = new System.Drawing.Point(142, 310);
            this.btnEditarEmprestimo.Name = "btnEditarEmprestimo";
            this.btnEditarEmprestimo.Size = new System.Drawing.Size(84, 23);
            this.btnEditarEmprestimo.TabIndex = 8;
            this.btnEditarEmprestimo.Text = "Editar";
            this.btnEditarEmprestimo.UseVisualStyleBackColor = true;
            this.btnEditarEmprestimo.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbEmprestimo
            // 
            this.lbEmprestimo.FormattingEnabled = true;
            this.lbEmprestimo.Location = new System.Drawing.Point(48, 209);
            this.lbEmprestimo.Name = "lbEmprestimo";
            this.lbEmprestimo.Size = new System.Drawing.Size(350, 95);
            this.lbEmprestimo.TabIndex = 7;
            this.lbEmprestimo.SelectedIndexChanged += new System.EventHandler(this.lbEmprestimo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Devolução:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(45, 141);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnCadastroEmprestimo
            // 
            this.btnCadastroEmprestimo.Location = new System.Drawing.Point(251, 142);
            this.btnCadastroEmprestimo.Name = "btnCadastroEmprestimo";
            this.btnCadastroEmprestimo.Size = new System.Drawing.Size(75, 23);
            this.btnCadastroEmprestimo.TabIndex = 4;
            this.btnCadastroEmprestimo.Text = "Salvar";
            this.btnCadastroEmprestimo.UseVisualStyleBackColor = true;
            this.btnCadastroEmprestimo.Click += new System.EventHandler(this.btnCadastroEmprestimo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Livro";
            // 
            // cmbLivros
            // 
            this.cmbLivros.FormattingEnabled = true;
            this.cmbLivros.Location = new System.Drawing.Point(45, 97);
            this.cmbLivros.Name = "cmbLivros";
            this.cmbLivros.Size = new System.Drawing.Size(350, 21);
            this.cmbLivros.TabIndex = 2;
            this.cmbLivros.SelectedIndexChanged += new System.EventHandler(this.cmbLivros_SelectedIndexChanged);
            // 
            // Cliente
            // 
            this.Cliente.AutoSize = true;
            this.Cliente.Location = new System.Drawing.Point(42, 22);
            this.Cliente.Name = "Cliente";
            this.Cliente.Size = new System.Drawing.Size(39, 13);
            this.Cliente.TabIndex = 1;
            this.Cliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(45, 38);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(350, 20);
            this.txtCliente.TabIndex = 0;
            // 
            // Biblioteca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 367);
            this.Controls.Add(this.tabBiblioteca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Biblioteca";
            this.Text = "Biblioteca";
            this.Load += new System.EventHandler(this.Biblioteca_Load);
            this.tabBiblioteca.ResumeLayout(false);
            this.Cadastro.ResumeLayout(false);
            this.Cadastro.PerformLayout();
            this.Consulta.ResumeLayout(false);
            this.Emprestimo.ResumeLayout(false);
            this.Emprestimo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBiblioteca;
        private System.Windows.Forms.TabPage Cadastro;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDisponibilidade;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TabPage Consulta;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbLivros;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TabPage Emprestimo;
        private System.Windows.Forms.Button btnCadastroEmprestimo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbLivros;
        private System.Windows.Forms.Label Cliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListBox lbEmprestimo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditarEmprestimo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdEmprestimo;
        private System.Windows.Forms.Button btnMulta;
        private System.Windows.Forms.Button btnExitEdit;
        private System.Windows.Forms.Button btnRelatorioLivros;
        private System.Windows.Forms.Button btnRelatorioEmprestimo;
    }
}

