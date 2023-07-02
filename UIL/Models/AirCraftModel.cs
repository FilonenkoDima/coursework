using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL.Models
{
    public class AirCraftModel
    {
        public int Id { set; get; }
        public int FlagCarryingAirlineId { set; get; }
        public int NumberOfFirstClassPassengers { set; get; }
        public int NumberOfBussinessClassPassengers { set; get; }
        public int NumberOfEconomClassPassengers { set; get; }


        public override string ToString()
        {
            return $"{Id} - FlagCarryingAirline({FlagCarryingAirlineId}) - {NumberOfFirstClassPassengers} - " +
                $"{NumberOfBussinessClassPassengers} - {NumberOfEconomClassPassengers}";
        }
    }
}
