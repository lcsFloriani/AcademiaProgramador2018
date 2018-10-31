using AutoMapper;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BancoTabajara.Aplicacao.Mappers
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }

        public static void Reset() => Mapper.Reset();
    }
}
