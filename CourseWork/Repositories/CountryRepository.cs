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
    public class CountryRepository : IRepository<Country>
    {
        private AirlineTicketsContext db;

        public CountryRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Country> GetAll()
        {
            return db.Country;
        }

        public Country Get(int id)
        {
            return db.Country.Find(id);
        }

        public void Create(Country country)
        {
            db.Country.Add(country);
        }

        public void Update(Country country)
        {
            db.Entry(country).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Country> Find(Func<Country, Boolean> predicate)
        {
            return db.Country.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var country = db.Country.Find(id);
            if (country != null)
                db.Country.Remove(country);
        }
    }
}
