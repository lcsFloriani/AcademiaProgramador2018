using System.Web.Http;
using BancoTabajara.API.IoC;
using BancoTabajara.Aplicacao.Mappers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using BancoTabajara.API.App_Start;
using BancoTabajara.API.Logger;

[assembly: OwinStartup(typeof(BancoTabajara.API.Startup))]

namespace BancoTabajara.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configurações gerais
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
            SimpleInjectorContainer.Initialize();
            DatabaseStart.Initialize();
            
            // configuracao WebApi
            var config = new HttpConfiguration();

            // ativando cors
            app.UseCors(CorsOptions.AllowAll);

            // ativando tokens de acesso
            OAuthConfig.ConfigureOAuth(app);

            config.MessageHandlers.Add(new CustomLogHandler());

            // ativando configuração WebApi
            app.UseWebApi(config);
        }
    }
}
