using ProjetoLoterica.Dominio.Exceptions;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public class ConcursoNumeroException : BusinessException
    {
        public ConcursoNumeroException() : base("Número não pode ser menor ou igual a zero!")
        {
        }
    }
}
