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
    public class FlagCarryingAirlineRepository : IRepository<FlagCarryingAirline>
    {
        private AirlineTicketsContext db;

        public FlagCarryingAirlineRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<FlagCarryingAirline> GetAll()
        {
            return db.FlagCarryingAirline;
        }

        public FlagCarryingAirline Get(int id)
        {
            return db.FlagCarryingAirline.Find(id);
        }

        public void Create(FlagCarryingAirline flagCarryingAirline)
        {
            db.FlagCarryingAirline.Add(flagCarryingAirline);
        }

        public void Update(FlagCarryingAirline flagCarryingAirline)
        {
            db.Entry(flagCarryingAirline).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<FlagCarryingAirline> Find(Func<FlagCarryingAirline, Boolean> predicate)
        {
            return db.FlagCarryingAirline.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var flagCarryingAirline = db.FlagCarryingAirline.Find(id);
            if (flagCarryingAirline != null)
                db.FlagCarryingAirline.Remove(flagCarryingAirline);
        }
    }
}
