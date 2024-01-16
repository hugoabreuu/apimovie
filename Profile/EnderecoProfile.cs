using WebApi.DTOs.EnderecoDTOs;
using WebApi.Models;

namespace WebApi.Profile;

public class EnderecoProfile : AutoMapper.Profile
{
    public EnderecoProfile() => CreateEnderecoMaps();

    private void CreateEnderecoMaps()
    {
        CreateMap<CreateEnderecoDTO, Endereco>();
        CreateMap<PutEnderecoDTO, Endereco>();
        CreateMap<Endereco, ReadEnderecoDTO>();
    }
}
