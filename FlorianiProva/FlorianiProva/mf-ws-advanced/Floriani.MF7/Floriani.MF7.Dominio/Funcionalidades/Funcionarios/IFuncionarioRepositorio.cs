using System.Linq;

namespace Floriani.MF7.Dominio.Funcionalidades.Funcionarios
{
	public interface IFuncionarioRepositorio
	{
		IQueryable<Funcionario> PegarTodos();
		Funcionario Inserir(Funcionario funcionario);
		bool Atualizar(Funcionario funcionario);
		Funcionario PegarPorId(int funcionarioId);
		bool Deletar(int funcionarioId);	
		Funcionario PegarPorNomeESenha(string user, string senha);
	}
}
