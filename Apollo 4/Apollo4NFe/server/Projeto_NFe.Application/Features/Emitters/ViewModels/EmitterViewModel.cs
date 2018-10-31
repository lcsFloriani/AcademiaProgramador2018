using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Application.Features.Emitters.ViewModels
{
    public class EmitterViewModel
    {
        public long Id { get; set; }
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string StateRegistration { get; set; }
        public string MunicipalRegistration { get; set; }
        public Address Address { get; set; }
    }
}
