using AutoMapper;
using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Functionaries.ViewModels;
using Enedir.MF7.Domain.Features.Functionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Application.Features.Functionaries
{
    public static class FunctionaryMapper
    {
        public static FunctionaryViewModel ConvertToViewModel(this Functionary customer)
        {
            return Mapper.Map<Functionary, FunctionaryViewModel>(customer);
        }

        public static Functionary ConvertToObject(this FunctionaryRegisterCommand command)
        {
            return Mapper.Map<FunctionaryRegisterCommand, Functionary>(command);
        }

        public static Functionary ConvertToObject(this FunctionaryUpdateCommand command)
        {
            return Mapper.Map<FunctionaryUpdateCommand, Functionary>(command);
        }

        public static Functionary ConvertToObject(this FunctionaryDeleteCommand command)
        {
            return Mapper.Map<FunctionaryDeleteCommand, Functionary>(command);
        }

        public static Functionary ConvertToObject(this FunctionaryChangeStatusCommand command)
        {
            return Mapper.Map<FunctionaryChangeStatusCommand, Functionary>(command);
        }
    }
}
