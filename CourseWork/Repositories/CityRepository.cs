using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private AirlineTicketsContext db;

        public CityRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<City> GetAll()
        {
            return db.City;
        }

        public City Get(int id)
        {
            return db.City.Find(id);
        }

        public void Create(City city)
        {
            db.City.Add(city);
        }

        public void Update(City city)
        {
            db.Entry(city).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<City> Find(Func<City, Boolean> predicate)
        {
            return db.City.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var city = db.City.Find(id);
            if (city != null)
                db.City.Remove(city);
        }
    }
}
