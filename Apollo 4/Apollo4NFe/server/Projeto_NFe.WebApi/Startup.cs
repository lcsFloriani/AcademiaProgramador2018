using Microsoft.Owin;
using Owin;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Infra.ORM.Context;
using Projeto_NFe.WebApi.App_Start;
using Projeto_NFe.WebApi.IoC;
using System.Data.Entity;
using System.Web.Http;

[assembly: OwinStartup(typeof(Projeto_NFe.WebApi.Startup))]

namespace Projeto_NFe.WebApi
{
    public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// Configurações gerais
			GlobalConfiguration.Configure( WebApiConfig.Register );
			//AutoMapperConfig.RegisterMappings();
			SimpleInjectorContainer.Initializer();

            AutoMapperInitializer.Initialize();

			// configuracao WebApi
			var config = new HttpConfiguration();

            // ativando configuração WebApi
            app.UseWebApi( config );

            Database.SetInitializer<ProjetoNFeContext>(new DbInitializer());
        }
    }
}
