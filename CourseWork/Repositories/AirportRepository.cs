using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml.Linq;

namespace DAL.Repositories
{
    public class AirportRepository : IRepository<Airport>
    {
        private AirlineTicketsContext db;

        public AirportRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Airport> GetAll()
        {
            return db.Airport;
        }

        public Airport Get(int id)
        {
            return db.Airport.Find(id);
        }

        public void Create(Airport airport)
        {
            db.Airport.Add(airport);
        }

        public void Update(Airport airport)
        {
            db.Entry(airport).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Airport> Find(Func<Airport, Boolean> predicate)
        {
            return db.Airport.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var airport = db.Airport.Find(id);
            if (airport != null)
                db.Airport.Remove(airport);
        }
    }
}
