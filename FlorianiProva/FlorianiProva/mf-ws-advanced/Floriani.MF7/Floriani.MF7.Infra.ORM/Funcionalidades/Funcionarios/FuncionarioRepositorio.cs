using System.Data.Entity;
using System.Linq;

using Floriani.MF7.Dominio.Excecoes;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Floriani.MF7.Infra.ORM.Contexto;

namespace Floriani.MF7.Infra.ORM.Funcionalidades.Funcionarios
{
	public class FuncionarioRepositorio : IFuncionarioRepositorio
	{
		private FlorianiMF7Contexto _contexto;

		public FuncionarioRepositorio(FlorianiMF7Contexto contexto) => _contexto = contexto;

		public bool Atualizar(Funcionario funcionario)
		{
			_contexto.Entry(funcionario).State = EntityState.Modified;
			return _contexto.SaveChanges() > 0;
		}

		public bool Deletar(int funcionarioId)
		{
			var funcionario = _contexto.Funcionarios.Where(o => o.Id == funcionarioId).FirstOrDefault();

			var gasto = _contexto.Gastos.Where( c => c.Funcionario.Id.Equals( funcionarioId ) ).FirstOrDefault();

			if (funcionario == null)
				throw new NaoEncontradoException();

			if (gasto != null) {
				if (funcionario.Status) {
					funcionario.AtualizarStatus();
					Atualizar( funcionario );
				}				
			}

			_contexto.Entry(funcionario).State = EntityState.Deleted;
			return _contexto.SaveChanges() > 0;
		}

		public Funcionario Inserir(Funcionario funcionario)
		{
			_contexto.Funcionarios.Attach(funcionario);
			var novoFuncionario = _contexto.Funcionarios.Add(funcionario);
			_contexto.SaveChanges();
			return novoFuncionario;
		}

		public Funcionario PegarPorId(int funcionarioId) 
			=> _contexto.Funcionarios.Find(funcionarioId);

		public IQueryable<Funcionario> PegarTodos() 
			=> _contexto.Funcionarios.OrderBy(f => f.PrimeiroNome);
		public Funcionario PegarPorNomeESenha(string user, string senha)
		{
			return this._contexto.Funcionarios.FirstOrDefault( u => u.Usuario.Equals( user ) && u.Senha == senha ) ?? throw new CredenciaisInvalidasException();
		}
	}
}
