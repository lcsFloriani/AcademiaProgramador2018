using ProjetoLoterica.Dominio.Exceptions;

namespace ProjetoLoterica.Dominio.Features.Apostas
{
    public class ApostaConcursoException : BusinessException
    {
        public ApostaConcursoException() : base("O concurso não pode ser nulo!")
        {
        }
    }
}
