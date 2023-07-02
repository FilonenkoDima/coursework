using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Airport
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int CityId { set; get; }
        
        public City City { set; get; }

        public List<Flight> FlightLeavingAirport { get; set; }
        public List<Flight> FlightArrivingAirport { get; set; }

        public Airport()
        {
            FlightArrivingAirport = new List<Flight>();
            FlightLeavingAirport = new List<Flight>();
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - City({City})";
        }
    }
}
