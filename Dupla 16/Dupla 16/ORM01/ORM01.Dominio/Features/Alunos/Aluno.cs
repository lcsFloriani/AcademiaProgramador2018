using ORM01.Dominio.Exceptions;
using ORM01.Dominio.Features.Enderecos;
using ORM01.Dominio.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Features.Alunos
{
    public class Aluno
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Aniversario { get; set; }        
        public virtual Endereco Endereco { get; set; }
        public virtual Turma Turma { get; set; }

        public virtual void Validar()
        {
            ValidarNome();
            ValidarEndereco();
            ValidarTurma();
            ValidarAniversario();
        }

        private void ValidarAniversario()
        {
            if (Aniversario < DateTime.Now)
                throw new IdadeInvalidaException();
        }

        private void ValidarTurma()
        {
            if (Turma == null)
                throw new TurmaInvalidaException();
        }

        private void ValidarEndereco()
        {
            if (Endereco == null)
                throw new EnderecoInvalidoException();
        }

        private void ValidarNome()
        {
            if (String.IsNullOrEmpty(Nome))
                throw new NomeInvalidoException();
        }
    }
}
