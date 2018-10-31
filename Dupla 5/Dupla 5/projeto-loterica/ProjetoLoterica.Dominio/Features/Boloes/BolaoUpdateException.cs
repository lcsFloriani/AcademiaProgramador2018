using ProjetoLoterica.Dominio.Exceptions;

namespace ProjetoLoterica.Dominio.Features.Boloes
{
    public class BolaoUpdateException : BusinessException
    {
        public BolaoUpdateException() : base("Você não pode atualizar um bolão!")
        {
        }
    }
}
