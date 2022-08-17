using AutoMapper;
using Server.Data.CoreEntities;
using Shared.Models.DTOs.Admin;

namespace Server.Data.Profiles
{
    public class EstateProfile : Profile
    {
        public EstateProfile()
        {
            //CreateMap<Estate, EstateDto>()
            //    .ForMember(
            //    dest => dest.Street,
            //    opt => opt.MapFrom(src => src.Address.Street))
            //    .ForMember(
            //    dest => dest.City,
            //    opt => opt.MapFrom(src => src.Address.City))
            //    .ForMember(
            //    dest => dest.PostalCode,
            //    opt => opt.MapFrom(src => src.Address.PostalCode))
            //    .ForMember(
            //    dest => dest.State,
            //    opt => opt.MapFrom(src => src.Address.State))
            //    .ForMember(
            //    dest => dest.Country,
            //    opt => opt.MapFrom(src => src.Address.Country))
            //    .ReverseMap();

            //CreateMap<Estate, EstateForCreation>()
            //    .ForMember(
            //    dest => dest.Street,
            //    opt => opt.MapFrom(src => src.Address.Street))
            //    .ForMember(
            //    dest => dest.City,
            //    opt => opt.MapFrom(src => src.Address.City))
            //    .ForMember(
            //    dest => dest.PostalCode,
            //    opt => opt.MapFrom(src => src.Address.PostalCode))
            //    .ForMember(
            //    dest => dest.State,
            //    opt => opt.MapFrom(src => src.Address.State))
            //    .ForMember(
            //    dest => dest.Country,
            //    opt => opt.MapFrom(src => src.Address.Country))
            //    .ReverseMap();

            //CreateMap<Estate, EstateForUpdate>()
            //    .ForMember(
            //    dest => dest.Street,
            //    opt => opt.MapFrom(src => src.Address.Street))
            //    .ForMember(
            //    dest => dest.City,
            //    opt => opt.MapFrom(src => src.Address.City))
            //    .ForMember(
            //    dest => dest.PostalCode,
            //    opt => opt.MapFrom(src => src.Address.PostalCode))
            //    .ForMember(
            //    dest => dest.State,
            //    opt => opt.MapFrom(src => src.Address.State))
            //    .ForMember(
            //    dest => dest.Country,
            //    opt => opt.MapFrom(src => src.Address.Country))
            //    .ReverseMap();
        }
    }
}
