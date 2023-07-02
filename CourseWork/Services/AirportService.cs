using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class AirportService
    {
        public static List<Airport> GetAirportList(string fileName = Config.airportFilePath)
        {
            List<Airport> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> airportInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Airport
                    {
                        Id = int.Parse(airportInfo[0]),
                        Name = airportInfo[1],
                        CityId = int.Parse(airportInfo[2])
                    }
                );
            }
            return result;
        }
    }
}
