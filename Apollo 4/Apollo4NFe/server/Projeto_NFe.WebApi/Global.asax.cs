using Enedir.MF7.API;
using Projeto_NFe.WebApi.IoC;
using System.Web.Http;

namespace Projeto_NFe.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SimpleInjectorContainer.Inicializador();
        }
    }
}
