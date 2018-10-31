using NDDResearch.Infra.Data.Initializer;
using System;
using System.Data.Entity;

namespace NDDResearch.Auth
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
            Database.SetInitializer(new DbInitializer());
        }
    }
}