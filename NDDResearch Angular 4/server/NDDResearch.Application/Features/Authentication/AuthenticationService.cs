using NDDResearch.Domain.Exceptions;
using NDDResearch.Domain.Users;
using NDDResearch.Infra.Crypto;
using NDDResearch.Infra.Data.Contexts;
using NDDResearch.Infra.Data.Features.Users;
using NDDResearch.Infra.Structs;
using System;

namespace NDDResearch.Domain.Features.Authentication
{
    /// <summary>
    /// Serviço de autenticação de usuários
    /// </summary>
    public class AuthenticationService
    {
        private IUserRepository _userRepository;

        public AuthenticationService(NDDResearchDbContext dbContext)
        {
            _userRepository = new UsersRepository(dbContext);
        }

        /// <summary>
        ///  Método para realizar o login, ou seja, validação de credenciais de autenticação.
        /// </summary>
        /// <param name="email">É o email do usuário cadastrado</param>
        /// <param name="password">É a senha do usuário que foi cadastrado</param>
        /// <returns>O usuário que corresponde as credenciais informadas. Caso alguma esteja inválida, retorna null</returns>
        public Try<Exception, User> Login(string email, string password)
        {
            password = password.GenerateHash();
            return _userRepository.GetByCredentials(email, password);
        }
    }
}
