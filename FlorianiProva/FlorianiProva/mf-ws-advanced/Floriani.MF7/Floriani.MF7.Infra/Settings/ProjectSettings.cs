using System.Configuration;
using Floriani.MF7.Infra.Settings.Entities;

namespace Floriani.MF7.Infra.Settings
{
	public class ProjectSettings
	{
		#region private fields
		static AuthenticationSettings _authSettings;
		#endregion private fields

		public static AuthenticationSettings AuthenticationSettings
		{
			get
			{
				return _authSettings ?? ( (AuthenticationSettings) ConfigurationManager.GetSection( "FlorianiMF7/AuthenticationSettings" ) );
			}
		}
	}
}
