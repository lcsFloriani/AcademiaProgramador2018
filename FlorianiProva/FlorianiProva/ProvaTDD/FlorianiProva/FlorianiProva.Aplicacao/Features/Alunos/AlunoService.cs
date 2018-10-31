using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorianiProva.Dominio.Features.Alunos;

namespace FlorianiProva.Aplicacao.Features.Alunos
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository repository)
        {
            _alunoRepository = repository;
        }

        public Aluno Atualizar(Aluno aluno)
        {
            aluno.Validar();
            return _alunoRepository.Atualizar(aluno);
        }

        public bool Deletar(long id) => _alunoRepository.Deletar(id);

        public Aluno Inserir(Aluno aluno)
        {
            aluno.Validar();
            return _alunoRepository.Inserir(aluno);
        }

        public Aluno ObterPorId(long id) => _alunoRepository.ObterPorId(id);

        public List<Aluno> ObterTodos() => _alunoRepository.ObterTodos();
    }
}
