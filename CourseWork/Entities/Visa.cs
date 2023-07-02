using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Visa
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ChildTicket> ChildTickets { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Visa()
        {
            ChildTickets = new List<ChildTicket>();
            Tickets = new List<Ticket>();
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
