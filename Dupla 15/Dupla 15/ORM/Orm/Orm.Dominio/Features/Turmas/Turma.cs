using Orm.Dominio.Base;

namespace Orm.Dominio.Features.Turmas
{
    public class Turma : Entidade
    {
        public string Descricao { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Descricao))
                throw new TurmaDescricaoVaziaException();
        }
    }
}
