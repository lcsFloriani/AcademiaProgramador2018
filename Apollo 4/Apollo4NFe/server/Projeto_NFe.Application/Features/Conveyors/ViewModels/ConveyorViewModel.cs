using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Features.Addresses;

namespace Projeto_NFe.Application.Features.Conveyors.ViewModels
{
    public class ConveyorViewModel
    {
        public long Id { get; set; }
        public PersonType PersonType { get; set; }
        public string NameCompanyName { get; set; }
        public FreightResponsibility FreightResponsibility { get; set; }
        public string CpfCnpj { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
