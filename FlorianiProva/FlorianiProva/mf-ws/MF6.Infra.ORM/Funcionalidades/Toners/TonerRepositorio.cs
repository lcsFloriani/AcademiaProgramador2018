using MF6.Domain.Excecoes;
using MF6.Domain.Funcionalidades.Toners;
using MF6.Domain.Funcionalidades.Toners.Excecoes;
using MF6.Infra.ORM.Contexts;
using System;
using System.Data.Entity;
using System.Linq;

namespace MF6.Infra.ORM.Funcionalidades.Toners
{
    public class TonerRepositorio : ITonerRepositorio
    {
        private MF6Context _contexto;

        public TonerRepositorio(MF6Context contexto) => _contexto = contexto;

        public bool Atualizar(Toner toner)
        {
            _contexto.Entry(toner).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Deletar(long tonerId)
        {
            var toner = _contexto.Toners.Where(i => i.Id == tonerId).FirstOrDefault();

            var tonerColorido = _contexto.Impressoras.Where(c => c.TonerColorido.Id.Equals(tonerId)).FirstOrDefault();
            var tonerPretoBranco = _contexto.Impressoras.Where(c => c.TonerPretoBranco.Id.Equals(tonerId)).FirstOrDefault();

            if (toner is null)
                throw new NaoEncontradoException();

            if (tonerColorido != null)
                throw new TonerEmUsoException();

            if (tonerPretoBranco != null)
                throw new TonerEmUsoException();

            _contexto.Entry(toner).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Toner Inserir(Toner toner)
        {
            _contexto.Toners.Attach(toner);
            var novoToner = _contexto.Toners.Add(toner);
            _contexto.SaveChanges();
            return novoToner;
        }

        public Toner PegarPorId(long tonerId) => _contexto.Toners.Find(tonerId);

        public IQueryable<Toner> PegarTodos() => _contexto.Toners;
    }
}
