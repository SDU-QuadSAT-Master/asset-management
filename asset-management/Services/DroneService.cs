using asset_management.Models.Drones;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public interface IDroneService
{
    IEnumerable<Drone> GetAll();
    Drone GetById(int id);
    Drone Create(DroneCreateRequest model);
    Drone Update(int id, DroneUpdateRequest model);
    void Delete(int id);
}

public class DroneService : IDroneService
{

    private DataContext _context;
    private readonly IMapper _mapper;
    public DroneService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Drone> GetAll()
    {
        return _context.Drones.Include(d => d.FlightsEntrys).ToList();
    }

    public Drone GetById(int id)
    {
        return getDrone(id);
    }
    public Drone Create(DroneCreateRequest model)
    {
        var drone = _mapper.Map<Drone>(model);
        _context.Add(drone);
        _context.SaveChanges();

        return drone;
    }

    public Drone Update(int id, DroneUpdateRequest model)
    {
        var drone = getDrone(id);

        _mapper.Map(model, drone);
        _context.Drones.Update(drone);
        _context.SaveChanges();

        return drone;
    }

    public void Delete(int id)
    {
        var drone = getDrone(id);
        _context.Drones.Remove(drone);
        _context.SaveChanges();
    }



    // Helper Function
    private Drone getDrone(int id)
    {
        var drone = _context.Drones.Find(id);
        if (drone == null) throw new KeyNotFoundException("Drone not found");
        return drone;
    }
}