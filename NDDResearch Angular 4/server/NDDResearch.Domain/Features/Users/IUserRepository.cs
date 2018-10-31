using NDDResearch.Infra.Structs;
using System;

namespace NDDResearch.Domain.Users
{
    /// <summary>
    /// Representa o repositório de usuários
    /// </summary>
    public interface IUserRepository
    {
        Try<Exception, User> GetByCredentials(string email, string password); 
    }
}
