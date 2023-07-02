using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class FlightService
    {
        public static List<Flight> GetFlightList(string fileName = Config.flightFilePath)
        {
            List<Flight> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> flightInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Flight
                    {
                        Id = int.Parse(flightInfo[0]),
                        AirCraftId = int.Parse(flightInfo[1]),
                        LeavingAirportId = int.Parse(flightInfo[2]),
                        DateTimeOfLeaving = DateTime.Parse(flightInfo[3]),
                        ArrivingAirportId = int.Parse(flightInfo[4]),
                        DateTimeOfArriving = DateTime.Parse(flightInfo[5]),
                    }
                );
            }
            return result;
        }
    }
}
