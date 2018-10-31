using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Alunos;
using ORM01.Dominio.Features.Enderecos;
using ORM01.Dominio.Features.Turmas;
using ORM01.Infra;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Comum.Testes.Base
{
    public class IncializadorDB<T> : DropCreateDatabaseAlways<ContextORM>
    {
        protected override void Seed(ContextORM context) {

            //Adicionar no contexto
            Endereco endereco = ObjectMother.endereco;

            context.EnderecoContext.Add(endereco);

            Turma turma = ObjectMother.Turma;

            context.TurmaContext.Add(turma);

            Aluno aluno = ObjectMother.aluno;
            aluno.Endereco = endereco;
            aluno.Turma = turma;

            context.AlunoContext.Add(aluno);

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }

    }
}
