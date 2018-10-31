using System;
using System.Linq;
using NDDResearch.Infra.Data.Contexts;
using NDDResearch.Domain.Users;
using NDDResearch.Domain.Exceptions;
using NDDResearch.Infra.Structs;

namespace NDDResearch.Infra.Data.Features.Users
{
    /// <summary>
    ///  Repositório de usuários
    /// </summary>
    public class UsersRepository : IUserRepository
    {
        private readonly NDDResearchDbContext _context;

        public UsersRepository(NDDResearchDbContext context)
        {
            _context = context;
        }

        public Try<Exception, User> GetByCredentials(string email, string password)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Email.Equals(email) && u.Password == password);
            if (user == null)
            {
                return new InvalidCredentialsException();
            }
            return user;
        }
    }
}
