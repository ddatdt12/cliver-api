using AutoMapper;
using CliverApi.DTOs;
using CliverApi.Models;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserDto>();
    CreateMap<UserDto, User>();
  }
}