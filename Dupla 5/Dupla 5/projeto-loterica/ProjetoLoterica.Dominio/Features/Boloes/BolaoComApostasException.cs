using ProjetoLoterica.Dominio.Exceptions;

namespace ProjetoLoterica.Dominio.Features.Boloes
{
    public class BolaoComApostasException : BusinessException
    {
        public BolaoComApostasException() : base("Você não pode apagar um bolão com apostas!")
        {
        }
    }
}
