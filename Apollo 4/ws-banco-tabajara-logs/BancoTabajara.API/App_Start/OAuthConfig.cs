using BancoTabajara.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoTabajara.API.App_Start
{
    public static class OAuthConfig
    {
        /// <summary>
        /// Método que configura e inicializa a disponibilização de tokens
        /// </summary>
        public static void ConfigureOAuth(IAppBuilder app)
        {
            AtivandoAccessTokens(app);
        }

        private static void AtivandoAccessTokens(IAppBuilder app)
        {
            // configurando fornecimento de tokens
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new ProviderDeTokensDeAcesso()
            };

            // ativando o uso de access tokens            
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}