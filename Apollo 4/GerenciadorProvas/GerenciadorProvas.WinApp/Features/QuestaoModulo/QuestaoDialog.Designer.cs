namespace GerenciadorProvas.WinApp.Features.QuestaoModulo
{
    partial class QuestaoDialog
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
            this.lblBimestre = new System.Windows.Forms.Label();
            this.llblMateria = new System.Windows.Forms.Label();
            this.cmbBimestre = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.rtxtEnunciado = new System.Windows.Forms.RichTextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblBim = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cmbSerie = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRespostas = new System.Windows.Forms.Label();
            this.btnAdicionarResposta = new System.Windows.Forms.Button();
            this.cbxCerta = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTxtDescricao = new System.Windows.Forms.RichTextBox();
            this.btnExcluirResposta = new System.Windows.Forms.Button();
            this.listaRespostas = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBimestre
            // 
            this.lblBimestre.Location = new System.Drawing.Point(0, 0);
            this.lblBimestre.Name = "lblBimestre";
            this.lblBimestre.Size = new System.Drawing.Size(100, 23);
            this.lblBimestre.TabIndex = 13;
            // 
            // llblMateria
            // 
            this.llblMateria.AutoSize = true;
            this.llblMateria.Location = new System.Drawing.Point(9, 104);
            this.llblMateria.Name = "llblMateria";
            this.llblMateria.Size = new System.Drawing.Size(45, 13);
            this.llblMateria.TabIndex = 2;
            this.llblMateria.Text = "Matéria:";
            // 
            // cmbBimestre
            // 
            this.cmbBimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBimestre.FormattingEnabled = true;
            this.cmbBimestre.Location = new System.Drawing.Point(302, 101);
            this.cmbBimestre.Name = "cmbBimestre";
            this.cmbBimestre.Size = new System.Drawing.Size(150, 21);
            this.cmbBimestre.TabIndex = 5;
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(65, 101);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(160, 21);
            this.cmbMateria.TabIndex = 6;
            // 
            // rtxtEnunciado
            // 
            this.rtxtEnunciado.Location = new System.Drawing.Point(12, 159);
            this.rtxtEnunciado.MaxLength = 500;
            this.rtxtEnunciado.Name = "rtxtEnunciado";
            this.rtxtEnunciado.Size = new System.Drawing.Size(443, 96);
            this.rtxtEnunciado.TabIndex = 7;
            this.rtxtEnunciado.Text = "";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(274, 497);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 8;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(370, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(9, 141);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(61, 13);
            this.lblDescricao.TabIndex = 11;
            this.lblDescricao.Text = "Enunciado:";
            // 
            // lblBim
            // 
            this.lblBim.AutoSize = true;
            this.lblBim.Location = new System.Drawing.Point(246, 104);
            this.lblBim.Name = "lblBim";
            this.lblBim.Size = new System.Drawing.Size(50, 13);
            this.lblBim.TabIndex = 12;
            this.lblBim.Text = "Bimestre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.cmbSerie);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbDisciplina);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 69);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtragem";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(366, 38);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(82, 23);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cmbSerie
            // 
            this.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerie.FormattingEnabled = true;
            this.cmbSerie.Location = new System.Drawing.Point(190, 40);
            this.cmbSerie.Name = "cmbSerie";
            this.cmbSerie.Size = new System.Drawing.Size(145, 21);
            this.cmbSerie.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Série:";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(8, 40);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(149, 21);
            this.cmbDisciplina.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disciplina:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRespostas);
            this.groupBox2.Controls.Add(this.btnAdicionarResposta);
            this.groupBox2.Controls.Add(this.cbxCerta);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.richTxtDescricao);
            this.groupBox2.Controls.Add(this.btnExcluirResposta);
            this.groupBox2.Controls.Add(this.listaRespostas);
            this.groupBox2.Location = new System.Drawing.Point(12, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 230);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resposta";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblRespostas
            // 
            this.lblRespostas.AutoSize = true;
            this.lblRespostas.Location = new System.Drawing.Point(6, 106);
            this.lblRespostas.Name = "lblRespostas";
            this.lblRespostas.Size = new System.Drawing.Size(60, 13);
            this.lblRespostas.TabIndex = 6;
            this.lblRespostas.Text = "Respostas:";
            // 
            // btnAdicionarResposta
            // 
            this.btnAdicionarResposta.Location = new System.Drawing.Point(262, 99);
            this.btnAdicionarResposta.Name = "btnAdicionarResposta";
            this.btnAdicionarResposta.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarResposta.TabIndex = 5;
            this.btnAdicionarResposta.Text = "Salvar";
            this.btnAdicionarResposta.UseVisualStyleBackColor = true;
            this.btnAdicionarResposta.Click += new System.EventHandler(this.btnAdicionarResposta_Click);
            // 
            // cbxCerta
            // 
            this.cbxCerta.AutoSize = true;
            this.cbxCerta.Location = new System.Drawing.Point(199, 104);
            this.cbxCerta.Name = "cbxCerta";
            this.cbxCerta.Size = new System.Drawing.Size(51, 17);
            this.cbxCerta.TabIndex = 4;
            this.cbxCerta.Text = "Certa";
            this.cbxCerta.UseVisualStyleBackColor = true;
            this.cbxCerta.CheckedChanged += new System.EventHandler(this.cbxCerta_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descrição:";
            // 
            // richTxtDescricao
            // 
            this.richTxtDescricao.Location = new System.Drawing.Point(9, 40);
            this.richTxtDescricao.MaxLength = 100;
            this.richTxtDescricao.Name = "richTxtDescricao";
            this.richTxtDescricao.Size = new System.Drawing.Size(424, 53);
            this.richTxtDescricao.TabIndex = 2;
            this.richTxtDescricao.Text = "";
            // 
            // btnExcluirResposta
            // 
            this.btnExcluirResposta.Location = new System.Drawing.Point(358, 100);
            this.btnExcluirResposta.Name = "btnExcluirResposta";
            this.btnExcluirResposta.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirResposta.TabIndex = 1;
            this.btnExcluirResposta.Text = "Excluir";
            this.btnExcluirResposta.UseVisualStyleBackColor = true;
            this.btnExcluirResposta.Click += new System.EventHandler(this.btnExcluirResposta_Click);
            // 
            // listaRespostas
            // 
            this.listaRespostas.FormattingEnabled = true;
            this.listaRespostas.Location = new System.Drawing.Point(9, 129);
            this.listaRespostas.Name = "listaRespostas";
            this.listaRespostas.Size = new System.Drawing.Size(424, 95);
            this.listaRespostas.TabIndex = 0;
            this.listaRespostas.SelectedIndexChanged += new System.EventHandler(this.listaRespostas_SelectedIndexChanged);
            // 
            // QuestaoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBim);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.rtxtEnunciado);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.cmbBimestre);
            this.Controls.Add(this.llblMateria);
            this.Controls.Add(this.lblBimestre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestaoDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBimestre;
        private System.Windows.Forms.Label llblMateria;
        private System.Windows.Forms.ComboBox cmbBimestre;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.RichTextBox rtxtEnunciado;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblBim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cmbSerie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdicionarResposta;
        private System.Windows.Forms.CheckBox cbxCerta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTxtDescricao;
        private System.Windows.Forms.Button btnExcluirResposta;
        private System.Windows.Forms.ListBox listaRespostas;
        private System.Windows.Forms.Label lblRespostas;
    }
}