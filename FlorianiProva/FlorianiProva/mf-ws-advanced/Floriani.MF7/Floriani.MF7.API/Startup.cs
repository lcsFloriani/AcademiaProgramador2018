using Floriani.MF7.API.App_Start;
using Floriani.MF7.API.IoC;
using Floriani.MF7.API.Logger;
using Floriani.MF7.API.Models.Mapeador;
using Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios;
using Microsoft.Owin;
using Owin;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: OwinStartup( typeof( Floriani.MF7.API.Startup ) )]
namespace Floriani.MF7.API
{
	[ExcludeFromCodeCoverage]
	public class Startup
	{
		public IFuncionarioServico _funcionarioServico;

		public void Configuration(IAppBuilder app)
		{
			GlobalConfiguration.Configure( WebApiConfig.Register );
			SimpleInjectorContainer.Inicializador();
			InicializadorAutoMapper.Inicializador();

			HttpConfiguration config = new HttpConfiguration();
			OAuthConfig.ConfigureOAuth( app );
			config.MessageHandlers.Add( new CustomLogHandler() );
			app.UseWebApi( config );
		}
	}
}