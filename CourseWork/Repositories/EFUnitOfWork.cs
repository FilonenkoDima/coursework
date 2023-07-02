using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private AirlineTicketsContext db;
        private AirCraftRepository airCraftRepository;
        private AirportRepository airportRepository;
        private ChildTicketRepository childTicketRepository;
        private CityRepository cityRepository;
        private ClassRepository classRepository;
        private CountryRepository countryRepository;
        private FlagCarryingAirlineRepository flagCarryingAirlineRepository;
        private FlightRepository flightRepository;
        private PassengerRepository passengerRepository;
        private TicketRepository ticketRepository;
        private VisaRepository visaRepository;

        public EFUnitOfWork(string connectionString = @"Server=(localdb)\mssqllocaldb;Database=TicketAirline;Trusted_Connection=True;")
        {
            db = new AirlineTicketsContext(connectionString);
        }
        public IRepository<AirCraft> AirCrafts
        {
            get
            {
                if (airCraftRepository == null)
                    airCraftRepository = new AirCraftRepository(db);
                return airCraftRepository;
            }
        }

        public IRepository<Airport> Airports
        {
            get
            {
                if (airportRepository == null)
                    airportRepository = new AirportRepository(db);
                return airportRepository;
            }
        }

        public IRepository<ChildTicket> ChildTickets
        {
            get
            {
                if (childTicketRepository == null)
                    childTicketRepository = new ChildTicketRepository(db);
                return childTicketRepository;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(db);
                return cityRepository;
            }
        }

        public IRepository<Class> Classes
        {
            get
            {
                if (classRepository == null)
                    classRepository = new ClassRepository(db);
                return classRepository;
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new CountryRepository(db);
                return countryRepository;
            }
        }

        public IRepository<FlagCarryingAirline> FlagCarryingAirlines
        {
            get
            {
                if (flagCarryingAirlineRepository == null)
                    flagCarryingAirlineRepository = new FlagCarryingAirlineRepository(db);
                return flagCarryingAirlineRepository;
            }
        }

        public IRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository(db);
                return flightRepository;
            }
        }

        public IRepository<Passenger> Passengers
        {
            get
            {
                if (passengerRepository == null)
                    passengerRepository = new PassengerRepository(db);
                return passengerRepository;
            }
        }
        
        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(db);
                return ticketRepository;
            }
        }
        
        public IRepository<Visa> Visas
        {
            get
            {
                if (visaRepository == null)
                    visaRepository = new VisaRepository(db);
                return visaRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
