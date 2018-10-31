using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.ORM.Comum.Base.Funcionalidades;
using System.Data.Entity;

namespace Floriani.ORM.Comum.Base.Seed
{
    public class SeedDb<T> : DropCreateDatabaseAlways<FlorianiOrmContexto>
    {
        protected override void Seed(FlorianiOrmContexto context)
        {
            var projeto = ObjectMother.ProjetoValido();

            var dependente = ObjectMother.DependenteValido();

            context.Dependentes.Add(dependente);

            context.SaveChanges();

            context.Projetos.Add(projeto);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
