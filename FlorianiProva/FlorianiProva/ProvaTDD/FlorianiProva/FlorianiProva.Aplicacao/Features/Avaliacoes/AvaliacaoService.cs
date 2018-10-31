using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorianiProva.Dominio.Features.Avaliações;

namespace FlorianiProva.Aplicacao.Features.Avaliacoes
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository repository)
        {
            _avaliacaoRepository = repository;
        }

        public Avaliacao Atualizar(Avaliacao avaliacao)
        {
            avaliacao.Validar();
            return _avaliacaoRepository.Atualizar(avaliacao);
        }

        public bool Deletar(long id) => _avaliacaoRepository.Deletar(id);

        public Avaliacao Inserir(Avaliacao avaliacao)
        {
            avaliacao.Validar();
            return _avaliacaoRepository.Inserir(avaliacao);
        }

        public Avaliacao ObterPorId(long id) => _avaliacaoRepository.ObterPorId(id);

        public List<Avaliacao> ObterTodos() => _avaliacaoRepository.ObterTodos();
    }
}
