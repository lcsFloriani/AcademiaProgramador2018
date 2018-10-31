using AutoMapper;
using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.ViewModels;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCommandRegister, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductCommandUpdate, Product>();
        }
    }
}
