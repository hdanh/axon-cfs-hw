using AutoMapper;
using AxonCFS.Application.ViewModels;
using AxonCFS.Domain.Models;

namespace AxonCFS.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Event, EventViewModel>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EventNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.EventTypeCode, opt => opt.MapFrom(src => src.Type.Code))
                .ForMember(dest => dest.Responder, opt => opt.MapFrom(src => src.Responder.Code));
        }
    }
}