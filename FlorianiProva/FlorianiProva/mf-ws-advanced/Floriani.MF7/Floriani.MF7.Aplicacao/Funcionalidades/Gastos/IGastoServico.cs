using System.Linq;

using Floriani.MF7.Aplicacao.Funcionalidades.Gastos.Comandos;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;

namespace Floriani.MF7.Aplicacao.Funcionalidades.Gastos
{
	public interface IGastoServico
	{
		int Inserir(ComandoRegistrarGasto gasto);
		bool Deletar(ComandoDeletarGasto gasto);
		IQueryable<Gasto> PegarTodos();
		Gasto PegarPorId(int gastoId);
	}
}
