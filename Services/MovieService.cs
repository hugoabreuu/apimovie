using AutoMapper;
using WebApi.Data;
using WebApi.DTOs.MovieDTOs;
using WebApi.Models;

namespace WebApi.Services;

public class MovieService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MovieService(AppDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }
    public GetFilmeDTO Get(int id)
    {
        var filme = _context.Filmes!.FirstOrDefault(x => x.FilmeId == id)!;
        return _mapper.Map<GetFilmeDTO>(filme);
    }
    public IEnumerable<GetFilmeDTO> Get(int skip = 0, int take = 25)
    {
        var filmes = _context.Filmes!.Skip(skip).Take(take).ToList();
        return _mapper.Map<IEnumerable<GetFilmeDTO>>(filmes);
    }
    public Filme Add(AddFilmeDTO filmeDTO)
    {
        var filme = _mapper.Map<Filme>(filmeDTO);

        _context.Filmes!.Add(filme);
        _context.SaveChanges();
        return filme;
    }
    public Filme Put(int id, PutFilmeDTO filmeDTO)
    {
        if (id == 0)
            throw new ArgumentException(nameof(id));
            
        var filme = _mapper.Map<Filme>(filmeDTO);
        filme.FilmeId = id;
        _context.Filmes!.Update(filme);
        _context.SaveChanges();

        return filme;
    }
    public bool Remove(int id)
    {
        var filme = _context.Filmes!.FirstOrDefault(x => x.FilmeId == id)!;
        if (filme == null) return false;

        _context.Filmes!.Remove(filme);
        _context.SaveChanges();
        return true;
    }
}
