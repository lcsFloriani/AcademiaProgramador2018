using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using BancoTabajara.API.Filtros;
using BancoTabajara.API.IoC;
using BancoTabajara.Aplicacao.Mappers;
using BancoTabajara.Infra.ORM.Contexto;
using BancoTabajara.Infra.ORM.Inicializar;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(BancoTabajara.API.Startup))]

namespace BancoTabajara.API
{
    public class Startup
    {

        public Startup()
        {
         
        }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            Register(config);

            app.UseWebApi(config);

         
            // ativando cors
            app.UseCors(CorsOptions.AllowAll);

            AtivandoAccessTokens(app);

            SimpleInjectorContainer.Initialize();
            AutoMapperConfig.RegisterMappings();
            // ativando configuração WebApi
            app.UseWebApi(config);
        }

        public void AtivandoAccessTokens(IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new ProviderDeTokensDeAcesso()
            };

            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        /// <summary>
        /// Método executado ao inicio da API que adiciona configurações e permissionamentos.
        /// </summary>
        public  void Register(HttpConfiguration config)
        {


            // Web API configuration and services
            MapApiRoutes(config);
            ConfigureJsonSerialization(config);
            ConfigureXMLSerialization(config);
            // Adicionamos o atributo global de tratamento de exceções 
            // para responder adequadamente conforme exception de negócio
            config.Filters.Add(new ExceptionHandlerAttribute());

            InitializeDatabase();
        }

        /// <summary>
        /// Método responsável por configurar as rotas de api
        /// </summary>
        /// <param name="config"></param>
        private void MapApiRoutes(HttpConfiguration config)
        {
            // Habilita o uso do Atributo de [Route]
            config.MapHttpAttributeRoutes();
            // Configura o uso de [Route]
            config.Routes.MapHttpRoute(
                name: "BancoTabajara.API",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );
        }


        /// <summary>
        /// Método responsável por configurar a forma de serialização em JSON
        /// </summary>
        /// <param name="config"></param>
        private void ConfigureJsonSerialization(HttpConfiguration config)
        {
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.None;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // Define que o Content-Type na resposta é o application/json
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        /// <summary>
        /// Método responsável por configurar a forma de serialização em XML
        /// </summary>
        /// <param name="config"></param>
        private  void ConfigureXMLSerialization(HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }

        private  void InitializeDatabase()
        {
            var contexto = new BancoTabajaraDbContexto();
            var init = new InicializadorDB(contexto);
            init.Configurar();
        }
    }
}
