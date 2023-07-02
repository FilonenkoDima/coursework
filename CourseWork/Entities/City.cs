using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set;}

        public Country Country { get; set; }

        public List<Airport> Airports { get; set; }
        public List<Passenger> Passengers { get; set; }

        public City()
        {
            Airports = new List<Airport>();
            Passengers = new List<Passenger>();
        }

        public override string ToString()
        {
            return $"{Id} - Country({Country}) - {Name}";
        }
    }
}