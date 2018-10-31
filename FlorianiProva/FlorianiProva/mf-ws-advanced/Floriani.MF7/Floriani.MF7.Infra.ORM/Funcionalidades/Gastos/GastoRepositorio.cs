using System;
using System.Data.Entity;
using System.Linq;

using Floriani.MF7.Dominio.Funcionalidades.Gastos;
using Floriani.MF7.Infra.ORM.Contexto;

namespace Floriani.MF7.Infra.ORM.Funcionalidades.Gastos
{
	public class GastoRepositorio : IGastoRepositorio
	{
		private FlorianiMF7Contexto _contexto;
		public GastoRepositorio(FlorianiMF7Contexto context) => _contexto = context;
		public bool Deletar(int gastoId)
		{
			var gasto = _contexto.Gastos.Where( c => c.Id.Equals( gastoId ) ).FirstOrDefault();
			_contexto.Entry( gasto ).State = EntityState.Deleted;
			return _contexto.SaveChanges() > 0;
		}

		public Gasto Inserir(Gasto gasto)
		{
			_contexto.Gastos.Attach( gasto );
			var novoGasto = _contexto.Gastos.Add( gasto );
			_contexto.SaveChanges();
			return novoGasto;
		}

		public Gasto PegarPorId(int gastoId)
			=> _contexto.Gastos.Find( gastoId );

		public IQueryable<Gasto> PegarTodos()
			=> _contexto.Gastos.OrderBy( f => f.Descricao );
	}
}
