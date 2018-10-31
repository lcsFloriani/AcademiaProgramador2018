using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Floriani.MF7.API.IoC;
using Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector.Lifestyles;

namespace Floriani.MF7.API.Provider
{
	public class OAuthProvider : OAuthAuthorizationServerProvider
	{
		public OAuthProvider() : base()
		{
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();

			return Task.FromResult<object>( null );
		}

		public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			context.OwinContext.Response.Headers.Add( "Access-Control-Allow-Origin", new[] { "*" } );

			var user = default( Funcionario );

			try {
				using (AsyncScopedLifestyle.BeginScope( SimpleInjectorContainer.ContainerInstance )) {
					var authService = SimpleInjectorContainer.ContainerInstance.GetInstance<IFuncionarioServico>();
					user = authService.Login( context.UserName, context.Password );
				}
			} catch (Exception ex) {
				context.SetError( "invalid_grant", ex.Message );
				return Task.FromResult<object>( null );
			}
			var identity = new ClaimsIdentity( "JWT" );
			identity.AddClaim( new Claim( "Id", user.Id.ToString() ) );
			identity.AddClaim( new Claim( ClaimTypes.Name, user.Usuario ) );
			var ticket = new AuthenticationTicket( identity, null );
			context.Validated( ticket );

			return Task.FromResult<object>( null );
		}
	}
}