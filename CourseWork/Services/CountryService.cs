using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class CountryService
    {
        public static List<Country> GetCountryList(string fileName = Config.countryFilePath)
        {
            List<Country> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> countryInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Country
                    {
                        Id = int.Parse(countryInfo[0]),
                        Name = countryInfo[1]
                    }
                );
            }
            return result;
        }
    }
}
