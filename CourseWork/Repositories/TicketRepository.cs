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
    public class TicketRepository : IRepository<Ticket>
    {
        private AirlineTicketsContext db;

        public TicketRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return db.Ticket;
        }

        public Ticket Get(int id)
        {
            return db.Ticket.Find(id);
        }

        public void Create(Ticket ticket)
        {
            db.Ticket.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            db.Entry(ticket).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Ticket> Find(Func<Ticket, Boolean> predicate)
        {
            return db.Ticket.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var ticket = db.Ticket.Find(id);
            if (ticket != null)
                db.Ticket.Remove(ticket);
        }
    }
}
