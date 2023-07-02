using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UIL.Models
{
    public class FlightModel
    {
        public int Id { get; set; }
        public int AirCraftId { get; set; }
        public int LeavingAirportId { get; set; }
        public DateTime DateTimeOfLeaving { get; set; }
        public int ArrivingAirportId { get; set; }
        public DateTime DateTimeOfArriving { get; set; }

        public override string ToString()
        {
            return $"{Id} - AirCraft({AirCraftId}) - LeavingAirport({LeavingAirportId}) - " +
                $"{DateTimeOfLeaving} - ArrivingAirport({ArrivingAirportId}) - {DateTimeOfArriving}";
        }
    }
}
