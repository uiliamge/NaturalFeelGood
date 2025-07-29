
using AutoMapper;
using NaturalFeelGood.Application.Features.ElementTypes.Dtos;

namespace NaturalFeelGood.Application.Features.ElementTypes.Mappings
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
