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
    public class VisaRepository : IRepository<Visa>
    {
        private AirlineTicketsContext db;

        public VisaRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Visa> GetAll()
        {
            return db.Visa;
        }

        public Visa Get(int id)
        {
            return db.Visa.Find(id);
        }

        public void Create(Visa visa)
        {
            db.Visa.Add(visa);
        }

        public void Update(Visa visa)
        {
            db.Entry(visa).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Visa> Find(Func<Visa, Boolean> predicate)
        {
            return db.Visa.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var visa = db.Visa.Find(id);
            if (visa != null)
                db.Visa.Remove(visa);
        }
    }
}
