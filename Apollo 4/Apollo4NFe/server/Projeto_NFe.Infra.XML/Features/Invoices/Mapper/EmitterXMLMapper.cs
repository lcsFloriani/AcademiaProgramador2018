using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class EmitterXMLMapper : IMapper<EmitterXMLModel, Emitter>
    {
        private AddressXMLMapper _addressXMLMapper;
        private EmitterXMLModel _emitterXMLModel;

        public EmitterXMLModel Map(Emitter entity)
        {
            _addressXMLMapper = new AddressXMLMapper();

            _emitterXMLModel = new EmitterXMLModel
            {
                Cnpj = entity.Cnpj,
                CompanyName = entity.CompanyName,
                FantasyName = entity.FantasyName,
                StateRegistration = entity.StateRegistration,
                MunicipalRegistration = entity.MunicipalRegistration,
                Address = _addressXMLMapper.Map(entity.Address)
            };

            return _emitterXMLModel;
        }
    }
}
