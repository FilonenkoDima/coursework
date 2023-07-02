using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL.Models
{
    public class ChildTicketModel
    {
        public int Id { set; get; }
        public int PassengerId { set; get; }
        public int AccompanyingPersonTicketId { set; get; }
        public int ClassId { set; get; }
        public int VisaId { set; get; }

        public override string ToString()
        {
            return $"{Id} - AccompanyingPersonTicket({AccompanyingPersonTicketId}) - Class({ClassId}) - Visa({VisaId})";
        }
    }
}
