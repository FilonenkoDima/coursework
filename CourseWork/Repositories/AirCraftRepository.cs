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
    public class AirCraftRepository : IRepository<AirCraft>
    {
        private AirlineTicketsContext db;

        public AirCraftRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<AirCraft> GetAll()
        {
            return db.AirCraft;
        }

        public AirCraft Get(int id)
        {
            return db.AirCraft.Find(id);
        }

        public void Create(AirCraft airCraft)
        {
            db.AirCraft.Add(airCraft);
        }

        public void Update(AirCraft airCraft)
        {
            db.Entry(airCraft).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<AirCraft> Find(Func<AirCraft, Boolean> predicate)
        {
            return db.AirCraft.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var airCraft = db.AirCraft.Find(id);
            if (airCraft != null)
                db.AirCraft.Remove(airCraft);
        }
    }
}
