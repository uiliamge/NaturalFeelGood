
using AutoMapper;
using NaturalFeelGood.Application.Features.ElementType.Dtos;

namespace NaturalFeelGood.Application.Features.ElementType.Mappings
{
    public class ElementTypeProfile : Profile
    {
        public ElementTypeProfile()
        {
            CreateMap<Domain.Entities.ElementType, ElementTypeDto>().ReverseMap();
            CreateMap<CreateElementTypeDto, Domain.Entities.ElementType>();
            CreateMap<UpdateElementTypeDto, Domain.Entities.ElementType>();
        }
    }
}
