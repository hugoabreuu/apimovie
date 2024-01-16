using WebApi.DTOs.UserDTOs;
using WebApi.Models;

namespace WebApi.Profile;

public class UserProfile : AutoMapper.Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
    }
}
