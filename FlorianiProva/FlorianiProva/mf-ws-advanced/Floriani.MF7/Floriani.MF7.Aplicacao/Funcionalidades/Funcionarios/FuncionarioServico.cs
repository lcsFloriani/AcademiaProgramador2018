using System.Linq;
using AutoMapper;
using Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios.Comandos;
using Floriani.MF7.Dominio.Excecoes;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Floriani.MF7.Infra.Crypto;

namespace Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios
{
	public class FuncionarioServico : IFuncionarioServico
	{
		private readonly IFuncionarioRepositorio _repositorioFuncionario;

		public FuncionarioServico(IFuncionarioRepositorio repositorioFuncionario)
			=> _repositorioFuncionario = repositorioFuncionario;		

		public bool Atualizar(ComandoAtualizarFuncionario funcionarioCmd)
		{
			var funcionario = Mapper.Map<ComandoAtualizarFuncionario, Funcionario>( funcionarioCmd );

			var funcionarioDb = _repositorioFuncionario.PegarPorId( funcionario.Id ) ?? throw new NaoEncontradoException();

			return _repositorioFuncionario.Atualizar( funcionarioDb );
		}

		public bool AtualizarStatus(int funcionarioId)
		{
			var funcionario = _repositorioFuncionario.PegarPorId(funcionarioId);

			if (funcionario == null)
				throw new NaoEncontradoException();

			funcionario.AtualizarStatus();

			_repositorioFuncionario.Atualizar(funcionario);

			return funcionario.Status;
		}

		public bool Deletar(ComandoDeletarFuncionario funcionarioCmd)
		{
			var funcionario = Mapper.Map<ComandoDeletarFuncionario, Funcionario>( funcionarioCmd );

			if (funcionario == null || funcionario.Id < 1)
				throw new NaoEncontradoException();

			return _repositorioFuncionario.Deletar( funcionario.Id );
		}

		public int Inserir(ComandoRegistrarFuncionario funcionarioCmd)
		{
			var funcionario = Mapper.Map<ComandoRegistrarFuncionario, Funcionario>( funcionarioCmd );

			var	password = funcionario.Senha.GenerateHash();

			funcionario.Senha = password;

			var novoFuncionario = _repositorioFuncionario.Inserir( funcionario );

			return novoFuncionario.Id;
		}

		public Funcionario PegarPorId(int funcionarioId)
		{
			if(funcionarioId < 1)

				throw new NaoEncontradoException();

			return _repositorioFuncionario.PegarPorId(funcionarioId) ?? throw new NaoEncontradoException();
		}

		public IQueryable<Funcionario> PegarTodos()
			=> _repositorioFuncionario.PegarTodos();
		public Funcionario Login(string user, string password)
		{
			password = password.GenerateHash();
			return _repositorioFuncionario.PegarPorNomeESenha( user, password );
		}
	}
}
