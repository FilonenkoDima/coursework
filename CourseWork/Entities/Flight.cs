using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public int AirCraftId { get; set; }
        public int LeavingAirportId { get; set; }
        public DateTime DateTimeOfLeaving { get; set; }
        public int ArrivingAirportId { get; set; }
        public DateTime DateTimeOfArriving { get; set; }

        public Airport LeavingAirport { get; set; }
        public Airport ArrivingAirport { get; set; }
        public AirCraft AirCraft { get; set; }

        public List<Ticket> Tickets { get; set; }

        public Flight()
        {
            Tickets = new List<Ticket>();
        }

        public override string ToString()
        {
            return $"{Id} - AirCraft({AirCraft}) - LeavingAirport({LeavingAirport}) - " +
                $"{DateTimeOfLeaving} - ArrivingAirport({ArrivingAirport}) - {DateTimeOfArriving}";
        }
    }
}
