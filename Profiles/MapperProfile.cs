using AutoMapper;
using CliverApi.DTOs;
using CliverApi.Models;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();

        CreateMap<CreatePostDto, Post>()
            .ForMember(p => p.Tags, options => options.MapFrom(p => string.Join(';', p.Tags)));

        CreateMap<UpdatePostDto, Post>()
            .ForMember(p => p.Tags, options => options.MapFrom(p => string.Join(';', p.Tags)))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Post, PostDto>()
            .ForMember(pDto => pDto.Tags, options => options.MapFrom(p => p.Tags.Split(';', StringSplitOptions.None)))
            .ForMember(pDto => pDto.Images, options => options.MapFrom(p => p.Images.Split(';', StringSplitOptions.None)));
    }
}