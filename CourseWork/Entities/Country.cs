using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
