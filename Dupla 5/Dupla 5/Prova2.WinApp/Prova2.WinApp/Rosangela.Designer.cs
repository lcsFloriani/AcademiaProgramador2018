namespace Prova2.WinApp
{
    partial class Rosangela
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnReportLoan = new System.Windows.Forms.Button();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lbReturnDate = new System.Windows.Forms.Label();
            this.btnTax = new System.Windows.Forms.Button();
            this.btnDeleteLoan = new System.Windows.Forms.Button();
            this.lbLoans = new System.Windows.Forms.ListBox();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.btnClearLoans = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lbBook = new System.Windows.Forms.Label();
            this.cmbBooks = new System.Windows.Forms.ComboBox();
            this.btnSaveLoan = new System.Windows.Forms.Button();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtTheme = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.cbIsAvailable = new System.Windows.Forms.CheckBox();
            this.lbIsAvailable = new System.Windows.Forms.Label();
            this.dtpDatePublication = new System.Windows.Forms.DateTimePicker();
            this.lbData = new System.Windows.Forms.Label();
            this.lbVolume = new System.Windows.Forms.Label();
            this.lbAutor = new System.Windows.Forms.Label();
            this.lbTheme = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tabRosangela = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.tabRosangela.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnReportLoan);
            this.tabPage3.Controls.Add(this.dtpReturnDate);
            this.tabPage3.Controls.Add(this.lbReturnDate);
            this.tabPage3.Controls.Add(this.btnTax);
            this.tabPage3.Controls.Add(this.btnDeleteLoan);
            this.tabPage3.Controls.Add(this.lbLoans);
            this.tabPage3.Controls.Add(this.lbCustomer);
            this.tabPage3.Controls.Add(this.btnClearLoans);
            this.tabPage3.Controls.Add(this.txtCustomer);
            this.tabPage3.Controls.Add(this.lbBook);
            this.tabPage3.Controls.Add(this.cmbBooks);
            this.tabPage3.Controls.Add(this.btnSaveLoan);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(617, 241);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Emprestimo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnReportLoan
            // 
            this.btnReportLoan.Location = new System.Drawing.Point(7, 203);
            this.btnReportLoan.Name = "btnReportLoan";
            this.btnReportLoan.Size = new System.Drawing.Size(80, 23);
            this.btnReportLoan.TabIndex = 27;
            this.btnReportLoan.Text = "Relatório";
            this.btnReportLoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportLoan.Click += new System.EventHandler(this.btnReportLoan_Click);
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(111, 71);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(175, 20);
            this.dtpReturnDate.TabIndex = 26;
            this.dtpReturnDate.Value = new System.DateTime(2018, 2, 20, 0, 0, 0, 0);
            // 
            // lbReturnDate
            // 
            this.lbReturnDate.AutoSize = true;
            this.lbReturnDate.Location = new System.Drawing.Point(19, 78);
            this.lbReturnDate.Name = "lbReturnDate";
            this.lbReturnDate.Size = new System.Drawing.Size(88, 13);
            this.lbReturnDate.TabIndex = 25;
            this.lbReturnDate.Text = "Data Devolução:";
            // 
            // btnTax
            // 
            this.btnTax.Enabled = false;
            this.btnTax.Location = new System.Drawing.Point(106, 203);
            this.btnTax.Name = "btnTax";
            this.btnTax.Size = new System.Drawing.Size(80, 23);
            this.btnTax.TabIndex = 24;
            this.btnTax.Text = "Multa";
            this.btnTax.UseVisualStyleBackColor = true;
            this.btnTax.Click += new System.EventHandler(this.btnTax_Click);
            // 
            // btnDeleteLoan
            // 
            this.btnDeleteLoan.Enabled = false;
            this.btnDeleteLoan.Location = new System.Drawing.Point(205, 203);
            this.btnDeleteLoan.Name = "btnDeleteLoan";
            this.btnDeleteLoan.Size = new System.Drawing.Size(81, 23);
            this.btnDeleteLoan.TabIndex = 23;
            this.btnDeleteLoan.Text = "Excluir";
            this.btnDeleteLoan.UseVisualStyleBackColor = true;
            this.btnDeleteLoan.Click += new System.EventHandler(this.btnDeleteLoan_Click);
            // 
            // lbLoans
            // 
            this.lbLoans.FormattingEnabled = true;
            this.lbLoans.Location = new System.Drawing.Point(292, 14);
            this.lbLoans.Name = "lbLoans";
            this.lbLoans.Size = new System.Drawing.Size(319, 212);
            this.lbLoans.TabIndex = 21;
            this.lbLoans.SelectedIndexChanged += new System.EventHandler(this.lbLoans_SelectedIndexChanged);
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Location = new System.Drawing.Point(19, 21);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(42, 13);
            this.lbCustomer.TabIndex = 20;
            this.lbCustomer.Text = "Cliente:";
            // 
            // btnClearLoans
            // 
            this.btnClearLoans.Location = new System.Drawing.Point(65, 130);
            this.btnClearLoans.Name = "btnClearLoans";
            this.btnClearLoans.Size = new System.Drawing.Size(75, 23);
            this.btnClearLoans.TabIndex = 19;
            this.btnClearLoans.Text = "Limpar";
            this.btnClearLoans.UseVisualStyleBackColor = true;
            this.btnClearLoans.Click += new System.EventHandler(this.btnClearLoans_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(111, 14);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(175, 20);
            this.txtCustomer.TabIndex = 16;
            // 
            // lbBook
            // 
            this.lbBook.AutoSize = true;
            this.lbBook.Location = new System.Drawing.Point(19, 49);
            this.lbBook.Name = "lbBook";
            this.lbBook.Size = new System.Drawing.Size(33, 13);
            this.lbBook.TabIndex = 15;
            this.lbBook.Text = "Livro:";
            // 
            // cmbBooks
            // 
            this.cmbBooks.BackColor = System.Drawing.SystemColors.Window;
            this.cmbBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.Location = new System.Drawing.Point(111, 41);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(175, 21);
            this.cmbBooks.TabIndex = 14;
            this.cmbBooks.SelectedIndexChanged += new System.EventHandler(this.cmbBooks_SelectedIndexChanged);
            // 
            // btnSaveLoan
            // 
            this.btnSaveLoan.Location = new System.Drawing.Point(151, 130);
            this.btnSaveLoan.Name = "btnSaveLoan";
            this.btnSaveLoan.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLoan.TabIndex = 12;
            this.btnSaveLoan.Text = "Salvar";
            this.btnSaveLoan.UseVisualStyleBackColor = true;
            this.btnSaveLoan.Click += new System.EventHandler(this.btnSaveLoan_Click);
            // 
            // tabRegister
            // 
            this.tabRegister.Controls.Add(this.btnReport);
            this.tabRegister.Controls.Add(this.btnDelete);
            this.tabRegister.Controls.Add(this.lbBooks);
            this.tabRegister.Controls.Add(this.btnClear);
            this.tabRegister.Controls.Add(this.btnCancel);
            this.tabRegister.Controls.Add(this.btnSave);
            this.tabRegister.Controls.Add(this.txtId);
            this.tabRegister.Controls.Add(this.txtVolume);
            this.tabRegister.Controls.Add(this.txtAutor);
            this.tabRegister.Controls.Add(this.txtTheme);
            this.tabRegister.Controls.Add(this.txtTitle);
            this.tabRegister.Controls.Add(this.lbId);
            this.tabRegister.Controls.Add(this.cbIsAvailable);
            this.tabRegister.Controls.Add(this.lbIsAvailable);
            this.tabRegister.Controls.Add(this.dtpDatePublication);
            this.tabRegister.Controls.Add(this.lbData);
            this.tabRegister.Controls.Add(this.lbVolume);
            this.tabRegister.Controls.Add(this.lbAutor);
            this.tabRegister.Controls.Add(this.lbTheme);
            this.tabRegister.Controls.Add(this.lbTitle);
            this.tabRegister.Location = new System.Drawing.Point(4, 22);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegister.Size = new System.Drawing.Size(617, 241);
            this.tabRegister.TabIndex = 0;
            this.tabRegister.Text = "Cadastro";
            this.tabRegister.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(455, 212);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 32;
            this.btnReport.Text = "Relatório";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(536, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // lbBooks
            // 
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.Location = new System.Drawing.Point(292, 14);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(319, 186);
            this.lbBooks.TabIndex = 33;
            this.lbBooks.SelectedIndexChanged += new System.EventHandler(this.lbBooks_SelectedIndexChanged_1);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(93, 212);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(26, 212);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DimGray;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtId.Location = new System.Drawing.Point(112, 14);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(68, 20);
            this.txtId.TabIndex = 25;
            this.txtId.Text = "0";
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(112, 127);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(174, 20);
            this.txtVolume.TabIndex = 19;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(112, 99);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(174, 20);
            this.txtAutor.TabIndex = 17;
            // 
            // txtTheme
            // 
            this.txtTheme.Location = new System.Drawing.Point(112, 71);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(174, 20);
            this.txtTheme.TabIndex = 15;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(112, 43);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(174, 20);
            this.txtTitle.TabIndex = 13;
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(23, 21);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(19, 13);
            this.lbId.TabIndex = 24;
            this.lbId.Text = "Id:";
            // 
            // cbIsAvailable
            // 
            this.cbIsAvailable.AutoSize = true;
            this.cbIsAvailable.Location = new System.Drawing.Point(112, 186);
            this.cbIsAvailable.Name = "cbIsAvailable";
            this.cbIsAvailable.Size = new System.Drawing.Size(15, 14);
            this.cbIsAvailable.TabIndex = 23;
            this.cbIsAvailable.UseVisualStyleBackColor = true;
            // 
            // lbIsAvailable
            // 
            this.lbIsAvailable.AutoSize = true;
            this.lbIsAvailable.Location = new System.Drawing.Point(23, 187);
            this.lbIsAvailable.Name = "lbIsAvailable";
            this.lbIsAvailable.Size = new System.Drawing.Size(64, 13);
            this.lbIsAvailable.TabIndex = 22;
            this.lbIsAvailable.Text = "Disponível?";
            // 
            // dtpDatePublication
            // 
            this.dtpDatePublication.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePublication.Location = new System.Drawing.Point(112, 156);
            this.dtpDatePublication.Name = "dtpDatePublication";
            this.dtpDatePublication.Size = new System.Drawing.Size(174, 20);
            this.dtpDatePublication.TabIndex = 21;
            this.dtpDatePublication.Value = new System.DateTime(2018, 2, 20, 0, 0, 0, 0);
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(23, 162);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(89, 13);
            this.lbData.TabIndex = 20;
            this.lbData.Text = "Data Publicação:";
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(23, 134);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(45, 13);
            this.lbVolume.TabIndex = 18;
            this.lbVolume.Text = "Volume:";
            // 
            // lbAutor
            // 
            this.lbAutor.AutoSize = true;
            this.lbAutor.Location = new System.Drawing.Point(22, 106);
            this.lbAutor.Name = "lbAutor";
            this.lbAutor.Size = new System.Drawing.Size(35, 13);
            this.lbAutor.TabIndex = 16;
            this.lbAutor.Text = "Autor:";
            // 
            // lbTheme
            // 
            this.lbTheme.AutoSize = true;
            this.lbTheme.Location = new System.Drawing.Point(21, 78);
            this.lbTheme.Name = "lbTheme";
            this.lbTheme.Size = new System.Drawing.Size(37, 13);
            this.lbTheme.TabIndex = 14;
            this.lbTheme.Text = "Tema:";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(21, 50);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(38, 13);
            this.lbTitle.TabIndex = 12;
            this.lbTitle.Text = "Título:";
            // 
            // tabRosangela
            // 
            this.tabRosangela.Controls.Add(this.tabRegister);
            this.tabRosangela.Controls.Add(this.tabPage3);
            this.tabRosangela.Location = new System.Drawing.Point(13, 13);
            this.tabRosangela.Name = "tabRosangela";
            this.tabRosangela.SelectedIndex = 0;
            this.tabRosangela.Size = new System.Drawing.Size(625, 267);
            this.tabRosangela.TabIndex = 0;
            // 
            // Rosangela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 292);
            this.Controls.Add(this.tabRosangela);
            this.Name = "Rosangela";
            this.Text = "Form1";
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            this.tabRosangela.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnReportLoan;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lbReturnDate;
        private System.Windows.Forms.Button btnTax;
        private System.Windows.Forms.Button btnDeleteLoan;
        private System.Windows.Forms.ListBox lbLoans;
        private System.Windows.Forms.Label lbCustomer;
        private System.Windows.Forms.Button btnClearLoans;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lbBook;
        private System.Windows.Forms.ComboBox cmbBooks;
        private System.Windows.Forms.Button btnSaveLoan;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtTheme;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.CheckBox cbIsAvailable;
        private System.Windows.Forms.Label lbIsAvailable;
        private System.Windows.Forms.DateTimePicker dtpDatePublication;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.Label lbAutor;
        private System.Windows.Forms.Label lbTheme;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TabControl tabRosangela;
    }
}

