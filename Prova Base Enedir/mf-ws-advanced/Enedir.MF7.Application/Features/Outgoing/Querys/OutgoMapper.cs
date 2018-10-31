using AutoMapper;
using Enedir.MF7.Application.Features.Outgoing.Commands;
using Enedir.MF7.Application.Features.Outgoing.ViewModels;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Application.Features.Outgoing
{
    public static class OutgoMapper
    {
        public static OutgoViewModel ConvertToViewModel(this Outgo customer)
        {
            return Mapper.Map<Outgo, OutgoViewModel>(customer);
        }

        public static Outgo ConvertToObject(this OutgoRegisterCommand command)
        {
            return Mapper.Map<OutgoRegisterCommand, Outgo>(command);
        }

        public static Outgo ConvertToObject(this OutgoDeleteCommand command)
        {
            return Mapper.Map<OutgoDeleteCommand, Outgo>(command);
        }
    }
}
