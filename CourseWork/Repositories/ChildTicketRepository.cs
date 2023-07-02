using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.EF;

namespace DAL.Repositories
{
    public class ChildTicketRepository : IRepository<ChildTicket>
    {
        private AirlineTicketsContext db;

        public ChildTicketRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<ChildTicket> GetAll()
        {
            return db.ChildTicket;
        }

        public ChildTicket Get(int id)
        {
            return db.ChildTicket.Find(id);
        }

        public void Create(ChildTicket childTicket)
        {
            db.ChildTicket.Add(childTicket);
        }

        public void Update(ChildTicket childTicket)
        {
            db.Entry(childTicket).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<ChildTicket> Find(Func<ChildTicket, Boolean> predicate)
        {
            return db.ChildTicket.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var childTicket = db.ChildTicket.Find(id);
            if (childTicket != null)
                db.ChildTicket.Remove(childTicket);
        }
    }
}
