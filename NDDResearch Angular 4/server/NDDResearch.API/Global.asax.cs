using MPSPortal.Application.Mapping;
using NDDResearch.API.App_Start;
using NDDResearch.API.IoC;
using NDDResearch.Infra.Data.Initializer;
using System;
using System.Data.Entity;
using System.Web.Http;

namespace NDDResearch.API
{
    /// <summary>
    /// Classe para execução de rotinas durante o ciclo de vida da API
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        ///Método de execução de rotinas durante a inicialização da API
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            // Realiza as configurações gerais da API
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Inicializa do AutoMapper e o IoC da API
            AutoMapperInitializer.Initialize();
            SimpleInjectorContainer.Initialize();
            Database.SetInitializer(new DbInitializer());
        }
    }
}