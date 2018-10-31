using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MF6.Domain.Excecoes;
using MF6.Domain.Funcionalidades.Toners;

namespace MF6.Application.Funcionalidades.Toners
{
    public class TonerServico : ITonerServico
    {
        private readonly ITonerRepositorio _repositorioToner;

        public TonerServico(ITonerRepositorio repositorioToner)
        {
            _repositorioToner = repositorioToner;

        }
        public bool Atualizar(Toner toner)
        {
            var tonerB = _repositorioToner.PegarPorId(toner.Id);
            if (tonerB is null)
                throw new NaoEncontradoException();

            tonerB.Nivel = toner.Nivel;
            tonerB.Tipo = toner.Tipo;
            // Salva alterações
            return _repositorioToner.Atualizar(tonerB);
        }

        public bool Deletar(Toner toner) => _repositorioToner.Deletar(toner.Id);

        public long Inserir(Toner toner)
        {
            var novoToner = _repositorioToner.Inserir(toner);

            return novoToner.Id;
        }

        public Toner PegarPorId(long id) => _repositorioToner.PegarPorId(id);

        public IQueryable<Toner> PegarTodos() => _repositorioToner.PegarTodos();
    }
}
