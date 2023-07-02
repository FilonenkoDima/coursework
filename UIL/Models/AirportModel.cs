using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL.Models
{
    public class AirportModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int CityId { set; get; }

        public override string ToString()
        {
            return $"{Id} - {Name} - City({CityId})";
        }
    }
}
