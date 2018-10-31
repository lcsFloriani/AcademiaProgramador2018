using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Floriani.MF7.Aplicacao.Funcionalidades.Gastos.Comandos;
using Floriani.MF7.Dominio.Excecoes;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;

namespace Floriani.MF7.Aplicacao.Funcionalidades.Gastos
{
	public class GastoServico : IGastoServico
	{
		private readonly IGastoRepositorio _repositorioGasto;
		private readonly IFuncionarioRepositorio _repositorioFuncionario;
		public GastoServico(IGastoRepositorio repositorioGasto, IFuncionarioRepositorio repositorioFuncionario)
		{
			_repositorioGasto = repositorioGasto;
			_repositorioFuncionario = repositorioFuncionario;
		}
		public bool Deletar(ComandoDeletarGasto gastoCmd)
		{
			var gasto = Mapper.Map<ComandoDeletarGasto, Gasto>( gastoCmd );

			if (gasto == null || gasto.Id < 1)
				throw new NaoEncontradoException();

			return _repositorioGasto.Deletar( gasto.Id );
		}

		public int Inserir(ComandoRegistrarGasto gastoCmd)
		{
			var funcionario = _repositorioFuncionario.PegarPorId(gastoCmd.FuncionarioId);

			if (funcionario == null)
				throw new NaoEncontradoException();

			var gasto = Mapper.Map<ComandoRegistrarGasto, Gasto>( gastoCmd );
			gasto.Funcionario = funcionario;

			var novoGasto = _repositorioGasto.Inserir( gasto );

			return novoGasto.Id;
		}

		public Gasto PegarPorId(int gastoId)
		{
			if (gastoId < 1)

				throw new NaoEncontradoException();

			return _repositorioGasto.PegarPorId( gastoId ) ?? throw new NaoEncontradoException();

		}

		public IQueryable<Gasto> PegarTodos()
			=> _repositorioGasto.PegarTodos();
	}
}
