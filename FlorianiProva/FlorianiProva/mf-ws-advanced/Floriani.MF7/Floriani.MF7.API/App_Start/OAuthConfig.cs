using System;
using System.Diagnostics.CodeAnalysis;
using Floriani.MF7.API.Provider;
using Floriani.MF7.Infra.Settings;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Floriani.MF7.API.App_Start
{
	[ExcludeFromCodeCoverage]
	public static class OAuthConfig
	{
		public static void ConfigureOAuth(IAppBuilder app)
		{
			ConfigureOAuthTokenGeneration( app );
		}

		private static void ConfigureOAuthTokenGeneration(IAppBuilder app)
		{
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString( "/token" ),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays( ProjectSettings.AuthenticationSettings.TokenExpiration ),
				Provider = new OAuthProvider(),

			};

			app.UseOAuthAuthorizationServer( OAuthServerOptions );

			app.UseOAuthBearerAuthentication( new OAuthBearerAuthenticationOptions() );
		}
	}
}