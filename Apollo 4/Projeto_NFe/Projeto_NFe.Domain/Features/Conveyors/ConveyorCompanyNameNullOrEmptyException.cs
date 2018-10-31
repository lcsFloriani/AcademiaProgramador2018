using Projeto_NFe.Domain.Exceptions;


namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class ConveyorCompanyNameNullOrEmptyException : BusinessException
    {
        public ConveyorCompanyNameNullOrEmptyException() : base("A razão social é um campo obrigatório!")
        {
        }
    }
}
