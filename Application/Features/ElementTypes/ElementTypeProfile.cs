
using AutoMapper;
using NaturalFeelGood.Application.Features.ElementTypes.Dtos;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Application.Features.ElementTypes.Mappings
{
    public class ElementTypeProfile : Profile
    {
        public ElementTypeProfile()
        {
            CreateMap<ElementType, ElementTypeDto>().ReverseMap();
            CreateMap<CreateElementTypeDto, ElementType>();
            CreateMap<UpdateElementTypeDto, ElementType>();
        }
    }
}
