using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set;}


        public override string ToString()
        {
            return $"{Id} - Country({CountryId}) - {Name}";
        }
    }
}

