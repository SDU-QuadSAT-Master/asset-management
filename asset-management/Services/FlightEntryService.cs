using asset_management.Models.FlightEntrys;
using AutoMapper;

public interface IFlightEntryService
{
    IEnumerable<FlightEntry> GetAll();
    FlightEntry GetById(int id);
    FlightEntry Create(FlightEntryCreateRequest model);
}

public class FlightEntryService : IFlightEntryService
{

    private DataContext _context;
    private readonly IMapper _mapper;
    public FlightEntryService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<FlightEntry> GetAll()
    {
        return _context.FlightEntrys;
    }

    public FlightEntry GetById(int id)
    {
        return getFlightEntry(id);
    }
    public FlightEntry Create(FlightEntryCreateRequest model)
    {
        var fe = _mapper.Map<FlightEntry>(model);
        _context.Add(fe);
        _context.SaveChanges();

        return fe;
    }

    // Helper Function
    private FlightEntry getFlightEntry(int id)
    {
        var fe = _context.FlightEntrys.Find(id);
        if (fe == null) throw new KeyNotFoundException("Flight Entry not found");
        return fe;
    }
}