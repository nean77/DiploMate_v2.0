using AutoMapper;
using DiploMate.DAL.Models;
using DiploMate.DAL.Repositories;
using DiploMate.User;

namespace DiploMate.Other;

public class DiploMateMappingProfile : Profile
{
    public DiploMateMappingProfile()
    {
        CreateMap<RegisterUser, RegisterUserDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
            .ForMember(dest=>dest.RoleId, opt =>opt.MapFrom(src=>src.Role))
            .ReverseMap()
            .ForMember(dest => dest.Role,
                opt => opt.MapFrom(src => Enum.GetName(typeof(Role), src.RoleId)));

        CreateMap<Login, LoginDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToUpper()))
            .ReverseMap();

        CreateMap<StudentDto, Student.Student>()
            .ReverseMap()
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
    }
}