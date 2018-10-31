using AutoMapper;
using NDDResearch.Application.Features.Sites.Commands;
using NDDResearch.Application.Features.Sites.Queries;
using NDDResearch.Domain.Features.Sites;

namespace NDDResearch.Application.Features.Sites
{
    /// <summary>
    /// 
    ///  Realiza o mapeamento entre o Command/Query e a entidade de domínio Site
    ///  
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SiteRegisterCommand, Site>();
            CreateMap<SiteUpdateCommand, Site>();
            CreateMap<Site, SiteQuery>();
        }
    }
}
