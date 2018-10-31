using Microsoft.Owin;
using NDDResearch.API.App_Start;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(NDDResearch.API.Startup))]
namespace NDDResearch.API
{
    /// <summary>
    /// Classe para o inicio da API.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Método que invoca as configurações iniciais para execução da API
        /// 
        /// Existem configurações que são executadas durante a inicialização. Veja também em Global.asax 
        /// 
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            // Cria a configuração da api
            HttpConfiguration config = new HttpConfiguration();
            // Configura a autenticação
            OAuthConfig.ConfigureOAuth(app);
            // Inicia a API com as configurações
            app.UseWebApi(config);
        }
    }
}