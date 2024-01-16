using WebApi.DTOs.CinemaDTOs;
using WebApi.Models;

namespace WebApi.Profile;

public class CinemaProfile : AutoMapper.Profile
{
    public CinemaProfile() => CreateCinemaMaps();

    private void CreateCinemaMaps()
    {
        CreateMap<CreateCinemaDTO, Cinema>();
        CreateMap<PutCinemaDTO, Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>()
         .ForMember(
            read => read.Endereco, 
            destinationMap => destinationMap.MapFrom(cinema => cinema.Endereco)
        );
    }
}
