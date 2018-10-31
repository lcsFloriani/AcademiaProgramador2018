using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class ReceiverXMLMapper : IMapper<ReceiverXMLModel, Receiver>
    {
        private AddressXMLMapper _addressXMLMapper;
        private ReceiverXMLModel _receiverXMLModel;
        public ReceiverXMLModel Map(Receiver entity)
        {
            _addressXMLMapper = new AddressXMLMapper();

            _receiverXMLModel = new ReceiverXMLModel();

            if (entity.Type == PersonType.PHYSICAL)
            {
                _receiverXMLModel.Cpf = entity.Cpf.Value;
            }
            else
            {
                _receiverXMLModel.Cnpj = entity.Cnpj.Value;
                _receiverXMLModel.StateRegistration = entity.StateRegistration;
            }

            _receiverXMLModel.NameCompanyName = entity.NameCompanyName;
            _receiverXMLModel.Address = _addressXMLMapper.Map(entity.Address);

            return _receiverXMLModel;
        }
    }
}
