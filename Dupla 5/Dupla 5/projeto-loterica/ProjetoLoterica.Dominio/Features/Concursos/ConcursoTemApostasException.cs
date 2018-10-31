using ProjetoLoterica.Dominio.Exceptions;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public class ConcursoTemApostasException : BusinessException
    {
        public ConcursoTemApostasException() : base("Você não pode apagar um concurso que contem apostas")
        {
        }
    }
}
