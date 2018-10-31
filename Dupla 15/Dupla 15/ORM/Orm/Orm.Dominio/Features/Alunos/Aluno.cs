using Orm.Dominio.Base;
using Orm.Dominio.Features.Enderecos;
using Orm.Dominio.Features.Turmas;
using System;

namespace Orm.Dominio.Features.Alunos
{
    public class Aluno : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Turma Turma { get; set; }
        public Endereco Endereco { get; set; }

        public override void Validar()
        {
            Turma.Validar();
            Endereco.Validar();

            if (String.IsNullOrEmpty(Nome))
                throw new AlunoNomeEmBrancoException();

            if (DataNascimento > DateTime.Now)
                throw new AlunoDataNascimentoInvalidaException();
        }
    }
}
