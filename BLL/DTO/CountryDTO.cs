﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
