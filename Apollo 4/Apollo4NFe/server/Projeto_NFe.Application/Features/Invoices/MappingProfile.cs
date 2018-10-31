using AutoMapper;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.ViewModels;
using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<InvoiceProcessCommandRegister, InvoiceInProcess>();
            CreateMap<InvoiceInProcess, InvoiceInProcessViewModel>();
            CreateMap<InvoiceProcessCommandUpdate, InvoiceInProcess>();
        }
    }
}
