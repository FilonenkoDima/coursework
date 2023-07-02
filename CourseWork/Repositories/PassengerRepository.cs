using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PassengerRepository : IRepository<Passenger>
    {
        private AirlineTicketsContext db;

        public PassengerRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Passenger> GetAll()
        {
            return db.Passenger;
        }

        public Passenger Get(int id)
        {
            return db.Passenger.Find(id);
        }

        public void Create(Passenger passenger)
        {
            db.Passenger.Add(passenger);
        }

        public void Update(Passenger passenger)
        {
            db.Entry(passenger).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Passenger> Find(Func<Passenger, Boolean> predicate)
        {
            return db.Passenger.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var passenger = db.Passenger.Find(id);
            if (passenger != null)
                db.Passenger.Remove(passenger);
        }
    }
}
