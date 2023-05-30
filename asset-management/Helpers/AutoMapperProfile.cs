using asset_management.Models.Antennas;
using asset_management.Models.Drones;
using asset_management.Models.FlightEntrys;

using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<DroneCreateRequest, Drone>();
        CreateMap<DroneUpdateRequest, Drone>();

        CreateMap<FlightEntryCreateRequest, FlightEntry>();
      
        CreateMap<AntennaCreateRequest, Antenna>();
        CreateMap<AntennaUpdateRequest, Antenna>();
    }
}