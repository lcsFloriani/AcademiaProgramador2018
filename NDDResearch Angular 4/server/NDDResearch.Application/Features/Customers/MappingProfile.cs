using AutoMapper;
using NDDResearch.Application.Features.Customers.Commands;
using NDDResearch.Application.Features.Customers.Queries;
using NDDResearch.Domain.Features.Customers;

namespace NDDResearch.Application.Features.Customers
{
    /// <summary>
    /// 
    ///  Realiza o mapeamento entre o Command/Query e a entidade de domínio Customer
    ///  
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerRegisterCommand, Customer>();
            CreateMap<Customer, CustomerDetailQuery>();
            CreateMap<CustomerUpdateCommand, Customer>();
        }
    }
}
