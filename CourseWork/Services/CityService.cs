using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class CityService
    {
        public static List<City> GetCityList(string fileName = Config.cityFilePath)
        {
            List<City> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> cityInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new City
                    {
                        Id = int.Parse(cityInfo[0]),
                        Name = cityInfo[1],
                        CountryId = int.Parse(cityInfo[2])
                    }
                );
            }
            return result;
        }
    }
}
