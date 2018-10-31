using System;
using System.Threading.Tasks;
using System.Web.Http;
using BancoTabajara.API.Extensoes;
using BancoTabajara.API.Filtros;
using BancoTabajara.API.IoC;
using BancoTabajara.Aplicacao.Mappers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using BancoTabajara.API.Providers;
using BancoTabajara.Infra.ORM.Inicializar;
using BancoTabajara.Infra.ORM.Contexto;
using BancoTabajara.API.App_Start;

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

            // ativando configuração WebApi
            app.UseWebApi(config);
        }
    }
}
