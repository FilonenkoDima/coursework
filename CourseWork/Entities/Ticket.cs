using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public int ClassId { get; set; }
        public int VisaId { get; set; }

        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }
        public Class Class { get; set; }
        public Visa Visa { get; set; }

        public List<ChildTicket> ChildTickets { get; set; }

        public Ticket()
        {
            ChildTickets = new List<ChildTicket>();
        }

        public override string ToString()
        {
            return $"{Id} - Flight({Flight}) - Passenger({Passenger}) - Class({Class}) - Visa({Visa})";
        }
    }
}
