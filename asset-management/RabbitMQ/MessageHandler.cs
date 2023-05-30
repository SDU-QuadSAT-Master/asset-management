using Newtonsoft.Json;

namespace asset_management.RabbitMQ
{
    public class MessageHandler
    {
        DataContext _context = new DataContext();

        public void AddToDatabase(Drone droneLog) {
            _context.Add(droneLog);
            _context.SaveChanges();
        }
        public void AddToDatabase(FlightEntry flightEntry) {
            _context.Add(flightEntry);
            _context.SaveChanges();
        }

    }
}
