using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using Enedir.MF7.Application.Features.Functionaries;
using Enedir.MF7.API.IoC;

namespace Enedir.MF7.API.Providers
{
    public class ProviderAccessToken : OAuthAuthorizationServerProvider
    {
        public ProviderAccessToken()
        {
        }

        //IFunctionaryService service
        public override async Task ValidateClientAuthentication
          (OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var oAuthService = SimpleInjectorContainer.ContainerInstance.GetInstance<IFunctionaryService>();

            // encontrando o usuário
            var isAuthenticated = oAuthService.CredentialVerify(context.UserName, context.Password);

            // cancelando a emissão do token se o usuário não for encontrado
            if (!isAuthenticated)
            {
                context.SetError("invalid_grant", "Usuário não encontrado um senha incorreta.");
                return;
            }

            // emitindo o token com informacoes extras
            // se o usuário existe
            var identidadeUsuario = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identidadeUsuario);
        }
    }
}