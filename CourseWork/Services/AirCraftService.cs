using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Services
{
    public static class AirCraftService
    {
        public static List<AirCraft> GetAirCraftList(string fileName = Config.airCraftFilePath)
        {
            List<AirCraft> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> airCraftInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new AirCraft
                    {
                        Id = int.Parse(airCraftInfo[0]),
                        FlagCarryingAirlineId = int.Parse(airCraftInfo[1]),
                        NumberOfFirstClassPassengers = int.Parse(airCraftInfo[2]),
                        NumberOfBussinessClassPassengers = int.Parse(airCraftInfo[3]),
                        NumberOfEconomClassPassengers = int.Parse(airCraftInfo[4])
                    }
                );
            }
            return result;
        }
    }
}