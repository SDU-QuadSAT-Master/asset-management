using asset_management.Models.Antennas;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public interface IAntennaService
{
    IEnumerable<Antenna> GetAll();
    Antenna GetById(int id);
    Antenna Create(AntennaCreateRequest model);
    Antenna Update(int id, AntennaUpdateRequest model);
    void Delete(int id);
}

public class AntennaService : IAntennaService
{

    private DataContext _context;
    private readonly IMapper _mapper;
    public AntennaService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Antenna> GetAll()
    {
        return _context.Antennas;
    }

    public Antenna GetById(int id)
    {
        return getAntenna(id);
    }
    public Antenna Create(AntennaCreateRequest model)
    {
        var antenna = _mapper.Map<Antenna>(model);
        _context.Add(antenna);
        _context.SaveChanges();

        return antenna;
    }

    public Antenna Update(int id, AntennaUpdateRequest model)
    {
        var antenna = getAntenna(id);

        _mapper.Map(model, antenna);
        _context.Antennas.Update(antenna);
        _context.SaveChanges();

        return antenna;
    }

    public void Delete(int id)
    {
        var antenna = getAntenna(id);
        _context.Antennas.Remove(antenna);
        _context.SaveChanges();
    }



    // Helper Function
    private Antenna getAntenna(int id)
    {
        var antenna = _context.Antennas.Find(id);
        if (antenna == null) throw new KeyNotFoundException("Antenna not found");
        return antenna;
    }
}