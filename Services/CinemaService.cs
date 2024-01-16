using AutoMapper;
using WebApi.Data;
using WebApi.DTOs.CinemaDTOs;
using WebApi.Models;

namespace WebApi.Services;

public class CinemaService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public CinemaService(AppDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public ReadCinemaDTO Get(int id)
    {
        var cinema = _context.Cinemas!.FirstOrDefault(x => x.Id == id)!;
        return _mapper.Map<ReadCinemaDTO>(cinema);
    }
    public IEnumerable<ReadCinemaDTO> Get(int skip = 0, int take = 25)
    {
        var cinemas = _context.Cinemas!.Skip(skip).Take(take).ToList();
        return _mapper.Map<IEnumerable<ReadCinemaDTO>>(cinemas);
    }
    public Cinema Add(CreateCinemaDTO cinemaDTO)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDTO);

        _context.Cinemas!.Add(cinema);
        _context.SaveChanges();
        return cinema;
    }
    public Cinema Put(int id, PutCinemaDTO cinemaDTO)
    {
        if (id == 0)
            throw new ArgumentException(nameof(id));

        var cinema = _mapper.Map<Cinema>(cinemaDTO);
        cinema.Id = id;
        _context.Cinemas!.Update(cinema);
        _context.SaveChanges();

        return cinema;
    }
    public bool Remove(int id)
    {
        var cinema = _context.Cinemas!.FirstOrDefault(x => x.Id == id)!;
        if (cinema == null) return false;

        _context.Cinemas!.Remove(cinema);
        _context.SaveChanges();
        return true;
    }
}
