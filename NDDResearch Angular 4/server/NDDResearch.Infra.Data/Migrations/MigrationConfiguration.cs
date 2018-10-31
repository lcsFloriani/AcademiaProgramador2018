using NDDResearch.Domain.Users;
using NDDResearch.Infra.Crypto;
using NDDResearch.Infra.Data.Contexts;
using System.Data.Entity.Migrations;
using System.Linq;

namespace NDDResearch.Infra.Data.Initializer
{
    /// <summary>
    /// Define as configurações para realização da migração do banco conforme alterações no o
    /// </summary>
    public class MigrationConfiguration : DbMigrationsConfiguration<NDDResearchDbContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public void CallSeed(NDDResearchDbContext context)
        {
            Seed(context);
        }

        protected override void Seed(NDDResearchDbContext context)
        {
            AddUser(context);
        }

        private void AddUser(NDDResearchDbContext context)
        {
            var password = "321";

            var _user = new User()
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@admin.com",
                Password = password.GenerateHash(),
            };

            var foundUser = context.Users.Where(u => u.Email == _user.Email).FirstOrDefault();
            if (foundUser == null)
                context.Users.Add(_user);
            else
                context.Entry(foundUser).CurrentValues.SetValues(_user);
            context.SaveChanges();
        }
    }
}
