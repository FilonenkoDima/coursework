using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AirCraft
    {
        public int Id { set; get; }
        public int FlagCarryingAirlineId { set; get; }
        public int NumberOfFirstClassPassengers { set; get; }
        public int NumberOfBussinessClassPassengers { set; get; }
        public int NumberOfEconomClassPassengers { set; get; }


        public FlagCarryingAirline FlagCarryingAirline { set; get; }
        public List<Flight> Flights { get; set; }

        public AirCraft() 
        { 
            Flights = new List<Flight>();
        }

        public override string ToString()
        {
            return $"{Id} - FlagCarryingAirline({FlagCarryingAirline}) - {NumberOfFirstClassPassengers} - " +
                $"{NumberOfBussinessClassPassengers} - {NumberOfEconomClassPassengers}";
        }
    }
}
