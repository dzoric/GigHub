using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<Gig, GigDto>().ReverseMap();
            CreateMap<Notification, NotificationDto>().ReverseMap();
        }
    }
}