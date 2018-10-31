using NDDResearch.Infra.Settings.Entities;
using System.Configuration;

namespace NDDResearch.Infra.Settings
{
    /// <summary>
    /// Fornece configurações transversais (para todas as layers) do NDDResearchServer
    /// </summary>
    public static class NDDResearchSettings
    {
        #region private fields
        static AuthenticationSettings _authSettings;
        #endregion private fields

        /// <summary>
        /// Fornece as configurações de autenticação que estão dispostas no Web.config
        /// </summary>
        public static AuthenticationSettings AuthenticationSettings
        {
            get
            {
                return _authSettings ?? ((AuthenticationSettings)ConfigurationManager.GetSection("NDDResearch/AuthenticationSettings"));
            }
        }
    }
}
