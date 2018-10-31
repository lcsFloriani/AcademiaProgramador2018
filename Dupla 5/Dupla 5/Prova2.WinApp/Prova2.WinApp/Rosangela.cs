using Prova2.Applications;
using Prova2.Domain;
using System;
using System.Windows.Forms;

namespace Prova2.WinApp
{
    public partial class Rosangela : Form
    {
        public Rosangela()
        {
            InitializeComponent();

            ClearFields();
            ListBooks();
            ListLoans();
        }

        private Book _book = new Book();
        private Book _bookSelected = new Book();
        private BookService _bookService = new BookService();

        private Loan _loan = new Loan();
        private LoanService _loanService = new LoanService();


        private void btnSave_Click(object sender, EventArgs e)
        {
            Book objBook = new Book();

            try
            {
                FormBookToObject();

                if (_book.Id == 0)
                {
                    objBook = _bookService.AddBook(_book);
                }
                else
                {
                    objBook = _bookService.UpdateBook(_book);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (objBook.Ex == false)
            {
                ClearFields();
                DisableButtons();
            }
            else
            {
                DisableButtons();
            }
        }

        private void FormBookToObject()
        {
            //Validação do componente txtBox para numérico
            if (!String.IsNullOrEmpty(txtVolume.Text) && !char.IsNumber(txtVolume.Text.ToCharArray()[0]))
            {
                throw new Exception("O valor deve ser numérico!");
            }
            if (String.IsNullOrEmpty(txtVolume.Text))
            {
                throw new Exception("O Volume deve ser numérico e um campo válido!");
            }
            _book.Title = txtTitle.Text;
            _book.Theme = txtTheme.Text;
            _book.Autor = txtAutor.Text;
            _book.Volume = Convert.ToInt32(txtVolume.Text);
            _book.IsAvailable = cbIsAvailable.Checked ? true : false; //Operador ternário
            _book.DatePublication = dtpDatePublication.Value;
        }

        private void FormLoanToObject()
        {
            _loan.Customer = txtCustomer.Text;
            _loan.Book = _bookSelected;
            _loan.ReturnDate = dtpReturnDate.Value;
        }

        private void ClearFields()
        {
            _book = new Book();

            txtId.Text = "0";
            txtTitle.Clear();
            txtTheme.Clear();
            txtAutor.Clear();
            txtVolume.Clear();
            dtpDatePublication.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
            cbIsAvailable.Checked = false;

            _loan = new Loan();
            txtCustomer.Clear();
            cmbBooks.SelectedIndex = -1;
            //numQty.ResetText();

            ListLoans();
            ListBooks();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tabRosangela.SelectedIndex = 0;
            txtId.Text = _book.Id.ToString();
            txtTitle.Text = _book.Title;
            txtTheme.Text = _book.Theme;
            txtAutor.Text = _book.Autor;
            txtVolume.Text = _book.Volume.ToString();
            cbIsAvailable.Checked = _book.IsAvailable ? true : false;
            dtpDatePublication.Value = _book.DatePublication;
        }

        private void ListBooks()
        {
            lbBooks.Items.Clear();
            cmbBooks.Items.Clear();

            try
            {
                var list = _bookService.GetAllBooks();

                foreach (var item in list)
                {
                    lbBooks.Items.Add(item);

                    if (item.IsAvailable)
                    {
                        cmbBooks.Items.Add(item);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível obter a lista de Livros");
            }
        }

        private void ListLoans()
        {
            lbLoans.Items.Clear();

            var list = _loanService.GetAllLoans();

            foreach (var item in list)
            {
                lbLoans.Items.Add(item);
            }
        }

        private void cmbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bookSelected = cmbBooks.SelectedItem as Book;
        }

        private void btnSaveLoan_Click(object sender, EventArgs e)
        {
            Loan obj = new Loan();
            try
            {
                if (_loan.Id == 0)
                {
                    FormLoanToObject();

                    obj = _loanService.AddLoan(_loan);
                }
                else
                {
                    FormLoanToObject();

                    _loanService.UpdateLoan(_loan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return; // precisa deste return para nao limpar os campos ja informados
            }

            if (obj.Ex == false)
            {
                ClearFields();
                DisableButtons();
            } else
            {
                DisableButtons();
            }
        }

        private void btnClearLoans_Click(object sender, EventArgs e)
        {
            ClearFields();
            DisableButtons();
        }

        private void btnEditLoan_Click(object sender, EventArgs e)
        {
            txtCustomer.Text = _loan.Customer;

            dtpReturnDate.Value = _loan.ReturnDate;

            cmbBooks.SelectedItem = _loan.Book;

            ListLoans();

            DisableButtons();
        }

        private void lbLoans_SelectedIndexChanged(object sender, EventArgs e)
        {
            _loan = lbLoans.SelectedItem as Loan;

            txtCustomer.Text = _loan.Customer;
            dtpReturnDate.Value = _loan.ReturnDate;
            cmbBooks.SelectedItem = _loan.Book;

            btnDeleteLoan.Enabled = true;
            btnTax.Enabled = true;
        }

        private void btnDeleteLoan_Click(object sender, EventArgs e)
        {
            if (_loan != null)
            {
                var message = MessageBox.Show("Deseja excluir o empréstimo " + _loan.Customer + "?", "Atenção",
                    MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _loanService.DeleteLoan(_loan);
                }
            }
            else
            {
                MessageBox.Show("Selecione um empréstimo para excluir!");
            }

            ClearFields();
            DisableButtons();
        }

        private void DisableButtons()
        {
            btnDeleteLoan.Enabled = false;
            btnTax.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnTax_Click(object sender, EventArgs e)
        {

            _loan.Tax = _loan.GetTax(_loan);

            MessageBox.Show("O lucro do produto selecionado é de: " + _loan.Tax);
        }

        private void btnReportLoan_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Pdf File|*.pdf";
            saveFile.Title = "Save your PDF File";
            saveFile.ShowDialog();

            try
            {
                _loanService.LoanPdfCreator(saveFile.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbBooks_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _book = lbBooks.SelectedItem as Book;

            tabRosangela.SelectedIndex = 0;
            txtId.Text = _book.Id.ToString();
            txtTitle.Text = _book.Title;
            txtTheme.Text = _book.Theme;
            txtAutor.Text = _book.Autor;
            txtVolume.Text = _book.Volume.ToString();
            cbIsAvailable.Checked = _book.IsAvailable ? true : false;
            dtpDatePublication.Value = _book.DatePublication;

            btnDelete.Enabled = true;
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Pdf File|*.pdf";
            saveFile.Title = "Save your PDF File";
            saveFile.ShowDialog();

            try
            {
                _bookService.BookPdfCreator(saveFile.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (_book != null)
            {
                var message = MessageBox.Show("Deseja excluir o livro " + _book.Title + "?", "Atenção",
                    MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    try
                    {
                        _bookService.DeleteBook(_book);
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível deletar o item selecionado, pois o livro consta no registro de Empréstimos.");
                    }

                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir!");
            }

            ClearFields();
            DisableButtons();
        }
    }
}
