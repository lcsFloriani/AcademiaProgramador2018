using Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios;
using Floriani.MF7.Aplicacao.Funcionalidades.Gastos;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;
using Floriani.MF7.Infra.ORM.Contexto;
using Floriani.MF7.Infra.ORM.Funcionalidades.Funcionarios;
using Floriani.MF7.Infra.ORM.Funcionalidades.Gastos;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Data.Entity;
using System.Web.Http;

namespace Floriani.MF7.API.IoC
{
	public static class SimpleInjectorContainer
	{
		public static Container ContainerInstance { get; private set; }

		public static void Inicializador()
		{
			ContainerInstance = new Container();

			ContainerInstance.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			Registros();

			ContainerInstance.RegisterWebApiControllers( GlobalConfiguration.Configuration );

			ContainerInstance.Verify();

			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver( ContainerInstance );
		}
		public static void Registros()
		{
			ContainerInstance.Register<IFuncionarioRepositorio, FuncionarioRepositorio>();
			ContainerInstance.Register<IGastoRepositorio, GastoRepositorio>();
			ContainerInstance.Register<IFuncionarioServico, FuncionarioServico>();
			ContainerInstance.Register<IGastoServico, GastoServico>();

			ContainerInstance.Register( () => new FlorianiMF7Contexto(), Lifestyle.Scoped );
		}
	}
}