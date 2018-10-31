using FlorianiProva.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Aplicacao.Features.Alunos
{
    public interface IAlunoService
    {
        Aluno Inserir(Aluno aluno);

        Aluno Atualizar(Aluno aluno);

        List<Aluno> ObterTodos();

        Aluno ObterPorId(long id);

        bool Deletar(long id);
    }
}
