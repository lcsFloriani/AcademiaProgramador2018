using AutoMapper;
using NFe.Aplicacao.Features.Produtos.Commands;
using NFe.Aplicacao.Features.Produtos.Queries;
using NFe.Dominio.Features.Produtos;

namespace NFe.Aplicacao.Features.Produtos
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ProdutoRegisterCommand, Produto>().ForPath(dest => dest.ValorProduto.Unitario, opt => opt.MapFrom(src => src.ValorUnitario));
            CreateMap<ProdutoUpdateCommand, Produto>().ForPath(dest => dest.ValorProduto.Unitario, opt => opt.MapFrom(src => src.ValorUnitario));
            CreateMap<Produto, ProdutoQuery>()
                .ForMember(dest => dest.ValorUnitario, opt => opt.MapFrom(src => src.ValorProduto.Unitario))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.ValorProduto.Total))
                .ForMember(dest => dest.ICMS, opt => opt.MapFrom(src => src.ValorProduto.ICMS))
                .ForMember(dest => dest.Ipi, opt => opt.MapFrom(src => src.ValorProduto.Ipi));
        }
    }
}
