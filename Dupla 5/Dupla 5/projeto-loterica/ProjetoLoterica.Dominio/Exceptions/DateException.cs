
namespace ProjetoLoterica.Dominio.Exceptions
{
    public class DateException : BusinessException
    {
        public DateException() : base("Data não pode ser antes de hoje!")
        {
        }
    }
}
