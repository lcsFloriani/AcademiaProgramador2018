using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class AddressXMLMapper : IMapper<AddressXMLModel, Address>
    {
        private AddressXMLModel _addressXMLModel;

        public AddressXMLModel Map(Address entity)
        {
            _addressXMLModel = new AddressXMLModel
            {
                Street = entity.Street,
                Number = entity.Number,
                Neighbourhood = entity.Neighbourhood,
                City = entity.City,
                State = entity.State.ToString(),
                Country = entity.Country.ToString()
            };

            return _addressXMLModel;
        }
    }
}
