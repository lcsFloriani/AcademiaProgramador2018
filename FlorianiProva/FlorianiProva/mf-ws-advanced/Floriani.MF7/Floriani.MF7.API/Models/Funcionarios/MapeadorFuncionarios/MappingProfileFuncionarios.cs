using AutoMapper;

using Floriani.MF7.API.Models.Funcionarios.ViewModel;
using Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios.Comandos;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;

namespace Floriani.MF7.API.Models.Funcionarios.MapeadorFuncionarios
{
	public class MappingProfileFuncionarios : Profile
	{
		public MappingProfileFuncionarios()
		{
			CreateMap<ComandoRegistrarFuncionario, Funcionario>();
			CreateMap<Funcionario, FuncionarioViewModel>();
			CreateMap<ComandoAtualizarFuncionario, Funcionario>();
			CreateMap<ComandoDeletarFuncionario, Funcionario>();
		}
	}
}