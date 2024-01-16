using AutoMapper;
using WebApi.Data;
using WebApi.DTOs.SessaoDTO;
using WebApi.Models;

namespace WebApi.Services;

public class SessaoService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public SessaoService(AppDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }
    public ReadSessaoDTO Get(int filmeId, int cinemaId)
    {
        var sessao = _context.Sessoes!
            .FirstOrDefault(x => x.FilmeId == filmeId && x.CinemaId == cinemaId)!;
        return _mapper.Map<ReadSessaoDTO>(sessao);
    }
    public IEnumerable<ReadSessaoDTO> GetAll(int skip = 0, int take = 25)
    {
        var sessaos = _context.Sessoes!.Skip(skip).Take(take).ToList();
        return _mapper.Map<IEnumerable<ReadSessaoDTO>>(sessaos);
    }
    public Sessao Add(CreateSessaoDTO sessaoDTO)
    {
        var sessao = _mapper.Map<Sessao>(sessaoDTO);

        _context.Sessoes!.Add(sessao);
        _context.SaveChanges();
        return sessao;
    }
}

