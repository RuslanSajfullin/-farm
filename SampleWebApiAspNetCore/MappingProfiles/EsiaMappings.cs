using AutoMapper;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Entities;

namespace SampleWebApiAspNetCore.MappingProfiles
{
    public class EsiaMappings : Profile
    {
        public EsiaMappings()
        {
            CreateMap<EsiaItem, EsiaItemDto>().ReverseMap();
            CreateMap<EsiaItem, EsiaUpdateDto>().ReverseMap();
            CreateMap<EsiaItem, EsiaCreateDto>().ReverseMap();
        }
    }
}
