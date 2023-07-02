using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class FlagCarryingAirlineService
    {
        public static List<FlagCarryingAirline> GetFlagCarryingAirlineList(string fileName = Config.flagCarryingAirlineFilePath)
        {
            List<FlagCarryingAirline> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> flagCarryingAirlineInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new FlagCarryingAirline
                    {
                        Id = int.Parse(flagCarryingAirlineInfo[0]),
                        Name = flagCarryingAirlineInfo[1]
                    }
                );
            }
            return result;
        }

    }
}
