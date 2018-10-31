using Projeto_NFe.Domain.Exceptions;


namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class ConveyorCnpjNullException : BusinessException
    {
        public ConveyorCnpjNullException() : base("O CNPJ é um campo obrigatório!")
        {
        }
    }
}
