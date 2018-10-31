using MF6.Domain.Excecoes;
using MF6.Domain.Funcionalidades.Impressoras;
using MF6.Infra.ORM.Contexts;
using System.Data.Entity;
using System.Linq;

namespace MF6.Infra.ORM.Funcionalidades.Impressoras
{
    public class ImpressoraRepositorio : IImpressoraRepositorio
    {

        private MF6Context _contexto;

        public ImpressoraRepositorio(MF6Context contexto) => _contexto = contexto;

        public bool Atualizar(Impressora impressora)
        {
            _contexto.Entry(impressora).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Deletar(long impressoraId)
        {
            var impressora = _contexto.Impressoras.Where(i => i.Id == impressoraId).FirstOrDefault();

            if (impressora is null)
                throw new NaoEncontradoException();

            _contexto.Entry(impressora).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Impressora Inserir(Impressora impressora)
        {
            _contexto.Impressoras.Attach(impressora);
            var novaImpressora = _contexto.Impressoras.Add(impressora);
            _contexto.SaveChanges();
            return novaImpressora;
        }

        public Impressora PegarPorId(long impressoraId) => _contexto.Impressoras.Find(impressoraId);

        public IQueryable<Impressora> PegarTodos() => _contexto.Impressoras;
    }
}
