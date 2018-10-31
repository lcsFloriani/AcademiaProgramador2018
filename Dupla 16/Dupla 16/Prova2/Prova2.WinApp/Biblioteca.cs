using Prova2.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Prova2.Applications;

namespace Prova2.WinApp
{
    public partial class Biblioteca : Form
    {
        public Biblioteca()
        {
            InitializeComponent();
            ListLivros();
            ListEmprestimos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private Livro _livro = new Livro();
        private Livro _livroSelected = new Livro();
        private LivroService _livroService = new LivroService();

        private Emprestimo _emprestimo = new Emprestimo();
        private EmprestimoService _emprestimoService = new EmprestimoService();
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                FormLivroToObject();

                if(_livro.Id == 0)
                {
                    _livroService.AddLivro(_livro);
                }
                else
                {
                    _livroService.UpdateLivro(_livro);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            ListLivros();
            ClearFields();
        }

        private void FormLivroToObject()
        {
            if (!char.IsNumber(txtVolume.Text.ToCharArray()[0]))
            {
                throw new Exception("O valor tem que ser númerico");
            }

            _livro.Autor = txtAutor.Text;
            _livro.Tema = txtTema.Text;
            _livro.Titulo = txtTitulo.Text;
            _livro.Volume = Convert.ToInt32(txtVolume.Text);
            _livro.Disponibilidade = cbDisponibilidade.Checked ? true : false;
            _livro.DataPublicacao = dateTime.Value;


        }
        private void ListEmprestimos()
        {
            lbEmprestimo.Items.Clear();

            var list = _emprestimoService.GetAllEmprestimos();

            foreach (var item in list)
            {
                lbEmprestimo.Items.Add(item);
            }
        }
        private void ListLivros()
        {
            lbLivros.Items.Clear();
            cmbLivros.Items.Clear();

            var list = _livroService.GetAllLivros();

            foreach (var item in list)
            {
                lbLivros.Items.Add(item);

                if (item.Disponibilidade)
                {
                    cmbLivros.Items.Add(item);
                }
            }
        }
        private void ClearFields()
        {
            _livro = new Livro();


            txtId.Text = "0";
            txtAutor.Clear();
            txtVolume.Clear();
            txtTitulo.Clear();
            txtTema.Clear();
            dateTime.Value = DateTime.Now;
            cbDisponibilidade.Checked = false;

        }
        private void ClearFieldsEmprestimo() {
            _emprestimo = new Emprestimo();
            
            this.txtIdEmprestimo.Text = "0";
            this.txtCliente.Clear();
            this.cmbLivros.SelectedItem = null;
           // _emprestimoService = new EmprestimoService();

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearFields();
        }

        private void Consulta_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            tabBiblioteca.SelectedIndex = 0;
            txtId.Text = _livro.Id.ToString();
            txtAutor.Text = _livro.Autor;
            txtTitulo.Text = _livro.Titulo.ToString();
            txtTema.Text = _livro.Tema.ToString();
            txtVolume.Text = _livro.Volume.ToString();
            cbDisponibilidade.Checked = _livro.Disponibilidade ? true : false;
            dateTime.Value = _livro.DataPublicacao;
        }

        private void lbLivros_SelectedIndexChanged(object sender, EventArgs e)
        {
            _livro = lbLivros.SelectedItem as Livro;

            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_livro != null)
            {
                var message = MessageBox.Show("Deseja excluir o livro " + _livro.Titulo + "?", "Atenção",
                    MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _livroService.DeleteLivro(_livro);

                    ListLivros();
                }
            }
            else
            {
                MessageBox.Show("Selecione um livro para excluir!");
            }
        }
        private void FormEmprestimoToObject()
        {
            _emprestimo.Cliente = txtCliente.Text;
            _emprestimo.Livro = _livroSelected;
            _emprestimo.dataDevolucao = dateTimePicker1.Value; 
        }
        private void btnCadastroEmprestimo_Click(object sender, EventArgs e)
        {
            if (_emprestimo.Id == 0)
            {
                FormEmprestimoToObject();

                _emprestimoService.AddEmprestimo(_emprestimo);
            }
            else
            {
                FormEmprestimoToObject();

                _emprestimoService.UpdateEmprestimo(_emprestimo);
            }
            ListEmprestimos();
            ClearFieldsEmprestimo();
        }

        private void lbEmprestimo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFieldsEmprestimo();
            _emprestimo = null;
            _emprestimo = lbEmprestimo.SelectedItem as Emprestimo;

            btnEditarEmprestimo.Enabled = true;
            btnCancelar.Enabled = true;
           
        }

        private void cmbLivros_SelectedIndexChanged(object sender, EventArgs e)
        {
            _livroSelected = cmbLivros.SelectedItem as Livro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            txtIdEmprestimo.Text = _emprestimo.Id.ToString();
            txtCliente.Text = _emprestimo.Cliente.ToString();
            dateTimePicker1.Value = _emprestimo.dataDevolucao;
            cmbLivros.Text = _emprestimo.Livro.ToString();


            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtIdEmprestimo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_emprestimo != null)
            {
                var message = MessageBox.Show("Deseja excluir o emprestimo " + _emprestimo.Cliente + "?", "Atenção",
                    MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _emprestimoService.DeleteEmprestimo(_emprestimo);

                    ListEmprestimos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um emprestimo para excluir!");
            }
        }

        private void btnMulta_Click(object sender, EventArgs e)
        {
            DateTime asd = DateTime.Now;
            double multa = 0;
            if (asd > _emprestimo.dataDevolucao)
            {                
                TimeSpan x = asd - _emprestimo.dataDevolucao;
                multa = x.Days * 2.50;
            }
            int result = _emprestimo.dataDevolucao.CompareTo(asd);
            if (multa > 0)
            {
                MessageBox.Show("A Multa é de R$" + multa);
            }
            else {
                MessageBox.Show("Emprestimo ainda não está atrasado!");
            }                    
            
        }

        private void btnExitEdit_Click(object sender, EventArgs e)
        {
            _emprestimo = null;
            _emprestimo = new Emprestimo();
        }

        private void btnRelatorioLivros_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PDF|*.pdf";
                saveFileDialog1.Title = "Salvar";
                saveFileDialog1.ShowDialog();

                _livroService.ReportList(saveFileDialog1.FileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRelatorioEmprestimo_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PDF|*.pdf";
                saveFileDialog1.Title = "Salvar";
                saveFileDialog1.ShowDialog();

                _emprestimoService.ReportList(saveFileDialog1.FileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cadastro_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Biblioteca_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            

        }
    }
}
