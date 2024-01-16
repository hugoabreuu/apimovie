using WebApi.DTOs.MovieDTOs;
using WebApi.Models;

namespace WebApi.Profile;

public class FilmeProfile : AutoMapper.Profile
{
    public FilmeProfile() =>   CreateFilmeMaps();
    private void CreateFilmeMaps()
    {
        CreateMap<AddFilmeDTO, Filme>();
        CreateMap<Filme, GetFilmeDTO>().ForMember
        (
            read => read.Sessoes,
            destinationMap => destinationMap.MapFrom(filme => filme.Sessoes)
        );
        CreateMap<PutFilmeDTO, Filme>();
    }
}
