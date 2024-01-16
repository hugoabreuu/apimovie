using AutoMapper;
using WebApi.Data;
using WebApi.DTOs.EnderecoDTOs;
using WebApi.Models;

namespace WebApi.Services;

public class EnderecoService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EnderecoService(AppDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }
    public ReadEnderecoDTO Get(int id)
    {
        var Endereco = _context.Enderecos!.FirstOrDefault(x => x.Id == id)!;
        return _mapper.Map<ReadEnderecoDTO>(Endereco);
    }
    public IEnumerable<ReadEnderecoDTO> Get(int skip = 0, int take = 25)
    {
        var Enderecos = _context.Enderecos!.Skip(skip).Take(take).ToList();
        return _mapper.Map<IEnumerable<ReadEnderecoDTO>>(Enderecos);
    }
    public Endereco Add(CreateEnderecoDTO EnderecoDTO)
    {
        var Endereco = _mapper.Map<Endereco>(EnderecoDTO);

        _context.Enderecos!.Add(Endereco);
        _context.SaveChanges();
        return Endereco;
    }
    public Endereco Put(int id, PutEnderecoDTO EnderecoDTO)
    {
        if (id == 0)
            throw new ArgumentException(nameof(id));

        var Endereco = _mapper.Map<Endereco>(EnderecoDTO);
        Endereco.Id = id;
        _context.Enderecos!.Update(Endereco);
        _context.SaveChanges();

        return Endereco;
    }
    public bool Remove(int id)
    {
        var Endereco = _context.Enderecos!.FirstOrDefault(x => x.Id == id)!;
        if (Endereco == null) return false;

        _context.Enderecos!.Remove(Endereco);
        _context.SaveChanges();
        return true;
    }
}
