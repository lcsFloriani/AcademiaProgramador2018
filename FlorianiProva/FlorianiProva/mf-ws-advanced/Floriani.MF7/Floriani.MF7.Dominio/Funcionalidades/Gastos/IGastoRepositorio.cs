using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.MF7.Dominio.Funcionalidades.Gastos
{
	public interface IGastoRepositorio
	{
		IQueryable<Gasto> PegarTodos();
		Gasto Inserir(Gasto gasto);
		Gasto PegarPorId(int gastoId);
		bool Deletar(int gastoId);
	}
}
