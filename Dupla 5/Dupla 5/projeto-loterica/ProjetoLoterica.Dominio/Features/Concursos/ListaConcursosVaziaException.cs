
using ProjetoLoterica.Dominio.Exceptions;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public class ListaConcursosVaziaException : BusinessException
    {
        public ListaConcursosVaziaException() : base("Não é possível gerar um arquivo CSV sem concursos cadastrados!")
        {
        }
    }
}
