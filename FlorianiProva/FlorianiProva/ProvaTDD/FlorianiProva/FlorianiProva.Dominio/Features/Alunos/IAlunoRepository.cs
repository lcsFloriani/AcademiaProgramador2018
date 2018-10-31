using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Alunos
{
    public interface IAlunoRepository
    {
        Aluno Inserir(Aluno aluno);

        Aluno Atualizar(Aluno aluno);

        List<Aluno> ObterTodos();

        Aluno ObterPorId(long id);

        bool Deletar(long id);
    }
}
