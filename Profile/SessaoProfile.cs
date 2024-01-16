using WebApi.DTOs.SessaoDTO;
using WebApi.Models;

namespace WebApi.Profile;

public class SessaoProfile : AutoMapper.Profile
{
    public SessaoProfile()
    {
        this.CreateMap<CreateSessaoDTO, Sessao>();
        this.CreateMap<Sessao, ReadSessaoDTO>();
    }
}
