using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class FlagCarryingAirline
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AirCraft> AirCrafts { get; set; }
        public FlagCarryingAirline()
        {
            AirCrafts = new List<AirCraft>();
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
