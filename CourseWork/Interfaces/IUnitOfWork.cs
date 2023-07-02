using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AirCraft> AirCrafts { get; }
        IRepository<Airport> Airports { get;}
        IRepository<ChildTicket> ChildTickets { get;}
        IRepository<City> Cities { get; }
        IRepository<Class> Classes { get; }
        IRepository<Country> Countries { get; }
        IRepository<FlagCarryingAirline> FlagCarryingAirlines { get; }
        IRepository<Flight> Flights { get; }
        IRepository<Passenger> Passengers { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<Visa> Visas { get; }
        void Save();
    }
}
