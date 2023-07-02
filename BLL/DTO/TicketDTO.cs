using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public int ClassId { get; set; }
        public int VisaId { get; set; }

        public override string ToString()
        {
            return $"{Id} - Flight({FlightId}) - Passenger({PassengerId}) - Class({ClassId}) - Visa({VisaId})";
        }
    }
}
