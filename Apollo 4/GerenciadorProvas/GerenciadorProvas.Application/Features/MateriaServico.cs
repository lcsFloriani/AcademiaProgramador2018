using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorProvas.Infra.Dados.SQL;
using GerenciadorProvas.Dominio.Exceptions;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Infra.Dados.IoC;

namespace GerenciadorProvas.Aplicacao.Features.MateriaServico
{
    public class MateriaServico : Servico<Materia>, IMateriaRepository
    {
        public MateriaServico() : base(IoCRepository.RepositorioMateria)
        {
        }


        public new void Excluir(Materia entidade)
        {
            try
            {
                if (RegistroComDependeciaComQuestao(entidade) || RegistroComDependeciaComTeste(entidade))
                    throw new ValidacoesExcepection("Foi encontrada inconsistencia na Materia, registro com dependência!");

                base.Excluir(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Materia> ProcurarMateriaPorDisciplina(Disciplina disciplina)
        {
            var repositorio = _repositorio as IMateriaRepository;
            return repositorio.ProcurarMateriaPorDisciplina(disciplina);
        }

        public IList<Materia> ProcurarMateriaPorDisciplinaSerie(Disciplina disciplina, Serie serie)
        {
            var repositorio = _repositorio as IMateriaRepository;
            return repositorio.ProcurarMateriaPorDisciplinaSerie(disciplina,serie);
        }

        public bool RegistroComDependeciaComQuestao(Materia entidade)
        {
            var repositorio = _repositorio as IMateriaRepository;
            return repositorio.RegistroComDependeciaComQuestao(entidade);
        }

        public bool RegistroComDependeciaComTeste(Materia entidade)
        {
            var repositorio = _repositorio as IMateriaRepository;
            return repositorio.RegistroComDependeciaComTeste(entidade);
        }

        public bool RegistroRepetido(Materia entidade)
        {
            var repositorio = _repositorio as IMateriaRepository;
            return repositorio.RegistroRepetido(entidade);
        }
    }
}
