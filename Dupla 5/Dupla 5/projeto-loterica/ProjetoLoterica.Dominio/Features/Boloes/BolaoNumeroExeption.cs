using ProjetoLoterica.Dominio.Exceptions;

namespace ProjetoLoterica.Dominio.Features.Boloes
{
    public class BolaoNumeroExeption : BusinessException
    {
        public BolaoNumeroExeption() : base("Número não pode ser menor ou igual a zero!")
        {
        }
    }
}
