using System.Linq;

using Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios.Comandos;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;

namespace Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios
{
	public interface IFuncionarioServico
	{
		int Inserir(ComandoRegistrarFuncionario funcionario);
		bool Atualizar(ComandoAtualizarFuncionario funcionario);
		bool Deletar(ComandoDeletarFuncionario funcionario);
		bool AtualizarStatus(int funcionarioId);
		IQueryable<Funcionario> PegarTodos();
		Funcionario PegarPorId(int funcionarioId);
		Funcionario Login(string email, string password);
	}
}
