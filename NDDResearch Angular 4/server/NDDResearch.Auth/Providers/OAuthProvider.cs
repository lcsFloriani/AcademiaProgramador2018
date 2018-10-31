using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using NDDResearch.Domain.Features.Authentication;
using NDDResearch.Domain.Users;
using NDDResearch.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NDDResearch.Auth.Providers
{
    /// <summary>
    /// Provedor de autenticação do NDDResearch.Auth
    /// 
    /// É o responsável por validar os parâmetros da chamada htpp de solicitação de token
    /// e também verificar as credenciais informadas.
    /// 
    /// </summary>
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {

        private AuthenticationService _authService;
        private NDDResearchDbContext _dbContext;

        public OAuthProvider()
        {
            _dbContext = new NDDResearchDbContext();
            _authService = new AuthenticationService(this._dbContext);
        }


        /// <summary>
        /// 
        /// Esse método é responsável por validar se a API da Aplicação está registrada para usar a API de Autenticação
        /// Tudo isso ocorrerá através do valor do ClientId informado, que deve ser informado no Request sem a chave criptografada
        /// Diante do "caminho feliz" o contexto do Request será marcado como válido
        /// 
        /// </summary>
        /// <param name="context">É o contexto atual da chamada http na visão do oauth</param>
        /// <returns>Retorna se o client_id informado é válido (true) ou não (false)</returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string symmetricKeyAsBase64 = string.Empty;
            // Obtém as chaves do contexto de autenticação
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }
            // Caso não tenha um client_id no contexto da chamada
            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "ErrorCode:001 - The client_id is not set");

                return Task.FromResult<object>(null);
            }
            // Busca o client
            var client = AppClientsStore.FindClient(context.ClientId);
            // Se não encontrou, então o client_id é inválido
            if (client == null)
            {
                context.SetError("invalid_clientId", "ErrorCode:002 - The client_id is incorrect");

                return Task.FromResult<object>(null);
            }
            // Torna válido o contexto da chamada
            context.Validated();

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 
        /// Esse método é responsável por validar as credenciais do usuário
        /// Essa validação é a verificação das credencias (email e senha) em uma base de usuários
        /// 
        /// O token de acesso JWT será gerado a partir da chamada "context.Validated(ticket)",
        /// seguindo os padrões de formatação definidos na classe "CustomJwtFormat"
        /// 
        /// </summary>
        /// <param name="context">É o contexto atual da chamada http na visão do oauth</param>
        /// <returns>Retorna se as credenciais informadas são válidas (true) ou não (false)</returns>
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            // Verifica as credenciais do usuário do serviço de autenticação
            var authVerifyCallback = _authService.Login(context.UserName, context.Password);
            // Se não está valido, o user será null e retornará o erro de credenciais inválidas
            if (authVerifyCallback.IsFailure)
            {
                context.SetError("invalid_grant", authVerifyCallback.Failure.Message);
                return Task.FromResult<object>(null);
            }
            var user = authVerifyCallback.Result;
            // Cria os atributos que estarão no JsonWebToken (JWT)
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim("UserId", user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            // Valida o contexto atual com o JWT
            var props = new AuthenticationProperties(new Dictionary<string, string> { { "client", context.ClientId } });
            // O ticket são as informações públicas que estarão codificadas no token JWT
            var ticket = new AuthenticationTicket(identity, props);
            // Torna válido as credenciais e gera o token de resposta com base no ticket
            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }
    }
}