using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorianiProva.Dominio.Features.Resultados;
using FlorianiProva.Dominio.Features.Alunos.Excecoes;

namespace FlorianiProva.Aplicacao.Features.Resultados
{
    public class ResultadoService : IResultadoService
    {
        private IResultadoRepository _resultadoRepository;

        public ResultadoService(IResultadoRepository repository)
        {
            _resultadoRepository = repository;
        }
        public Resultado Atualizar(Resultado result)
        {
            result.Validar();
            return _resultadoRepository.Atualizar(result);
        }

        public bool Deletar(long id) => _resultadoRepository.Deletar(id);
        public bool VerificarEstudantesComDoisResultados(Resultado result)
        {
            if (result.Avaliacao.Resultados.Count > 0)
            {
                foreach (var resultados in result.Avaliacao.Resultados)
                {
                    if (resultados.Aluno.Id == result.Aluno.Id)
                        return true;

                }
            }
            return false;
        }
        public Resultado Inserir(Resultado result)
        {
            result.Validar();
            if (!VerificarEstudantesComDoisResultados(result))
            {
                result.Aluno.Resultados.Add(result);
                result.Avaliacao.Resultados.Add(result);
            }
            else throw new AlunoComDoisResultadosException();
                
            return _resultadoRepository.Inserir(result);
        }

        public Resultado ObterPorId(long id) => _resultadoRepository.ObterPorId(id);

        public List<Resultado> ObterTodos() => _resultadoRepository.ObterTodos();
    }
}
