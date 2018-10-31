﻿namespace NDDResearch.Infra.Settings.Entities
{
    /// <summary>
    /// Representa as configurações da autenticação providas pela NDDResearch.Infra
    /// </summary>
    public class AuthenticationSettings
    {
        /// <summary>
        /// Configuração de expiração do token de autenticação, em dias.
        /// </summary>
        public int TokenExpiration { get; set; }
    }
}
