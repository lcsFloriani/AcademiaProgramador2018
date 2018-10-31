using System.Linq;
using MF6.Domain.Excecoes;
using MF6.Domain.Funcionalidades.Impressoras;
using MF6.Domain.Funcionalidades.Toners;

namespace MF6.Application.Funcionalidades.Impressoras
{
    public class ImpressoraServico : IImpressoraServico
    {
        private readonly ITonerRepositorio _repositorioToner;
        private readonly IImpressoraRepositorio _repositorioImpressora;

        public ImpressoraServico(IImpressoraRepositorio repositorioImpressora, ITonerRepositorio repositorioToner)
        {
            _repositorioImpressora = repositorioImpressora;
            _repositorioToner = repositorioToner;

        }
        public bool Atualizar(Impressora impressora)
        {
            if(impressora.TonerColorido != null)
            {
                Toner tonerColorido = _repositorioToner.PegarPorId(impressora.TonerColorido.Id) ?? throw new NaoEncontradoException();
            }
            if(impressora.TonerPretoBranco != null)
            {
                Toner tonerPretoBranco = _repositorioToner.PegarPorId(impressora.TonerPretoBranco.Id) ?? throw new NaoEncontradoException();
            }
            Impressora impressoraResult = _repositorioImpressora.PegarPorId(impressora.Id) ?? throw new NaoEncontradoException();

            impressoraResult.Marca = impressora.Marca;
            impressoraResult.Ip = impressora.Ip;
            impressoraResult.EmUso = impressora.EmUso;

            impressoraResult.AdicionarToner(impressora.TonerColorido);
            impressoraResult.AdicionarToner(impressora.TonerPretoBranco);

            impressoraResult.Validar();

            return _repositorioImpressora.Atualizar(impressoraResult);
        }

        public bool Deletar(Impressora impressora)
        {
            if (impressora.Id < 1)
                throw new NaoEncontradoException();

            var impressoraResult = _repositorioImpressora.PegarPorId(impressora.Id);

            if(impressoraResult is null)
                throw new NaoEncontradoException();

            return _repositorioImpressora.Deletar(impressora.Id);
        }

        public long Inserir(Impressora impressora)
        {
            Toner tonerColorido = _repositorioToner.PegarPorId(impressora.TonerColorido.Id) ?? throw new NaoEncontradoException();

            Toner tonerPretoBranco = _repositorioToner.PegarPorId(impressora.TonerPretoBranco.Id) ?? throw new NaoEncontradoException();
            Impressora novaImpressora = new Impressora();

            novaImpressora.Marca = impressora.Marca;
            novaImpressora.Ip = impressora.Ip;
            novaImpressora.AdicionarToner(tonerColorido);

            novaImpressora.AdicionarToner(tonerPretoBranco);

            novaImpressora.Validar();

            var novaConta = _repositorioImpressora.Inserir(novaImpressora);

            return novaImpressora.Id;
        }

        public Impressora PegarPorId(long id)
        {
            if (id < 1)
                throw new NaoEncontradoException();

            return _repositorioImpressora.PegarPorId(id) ?? throw new NaoEncontradoException();
        }

        public IQueryable<Impressora> PegarTodos() => _repositorioImpressora.PegarTodos();
    }
}
