using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ChildTicket
    {
        public int Id { set; get; }
        public int PassengerId { set; get; }
        public int AccompanyingPersonTicketId { set; get; }
        public int ClassId { set; get; }
        public int VisaId { set; get; }

        public Passenger Passenger { set; get; }
        public Ticket AccompanyingPersonTicket { get; set; }
        public Class Class { get; set; }
        public Visa Visa { get; set; }

        public override string ToString()
        {
            return $"{Id} - AccompanyingPersonTicket({AccompanyingPersonTicket}) - Class({Class}) - Visa({Visa})";
        }
    }
}
