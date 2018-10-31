using System;
using System.Threading.Tasks;
using System.Web.Http;
using Enedir.MF7.API.App_Start;
using Enedir.MF7.API.IoC;
using Enedir.MF7.API.Logger;
using Enedir.MF7.Application.Mappers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Enedir.MF7.API.Startup))]

namespace Enedir.MF7.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configurações gerais
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
            SimpleInjectorContainer.Initialize();

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
