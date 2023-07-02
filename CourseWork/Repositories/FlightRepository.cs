using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        private AirlineTicketsContext db;

        public FlightRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Flight> GetAll()
        {
            return db.Flight;
        }

        public Flight Get(int id)
        {
            return db.Flight.Find(id);
        }

        public void Create(Flight flight)
        {
            db.Flight.Add(flight);
        }

        public void Update(Flight flight)
        {
            db.Entry(flight).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Flight> Find(Func<Flight, Boolean> predicate)
        {
            return db.Flight.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var flight = db.Flight.Find(id);
            if (flight != null)
                db.Flight.Remove(flight);
        }
    }
}
