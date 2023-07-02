using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class VisaService
    {
        public static List<Visa> GetVisaList(string fileName = Config.visaFilePath)
        {
            List<Visa> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> visaInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Visa
                    {
                        Id = int.Parse(visaInfo[0]),
                        Name = visaInfo[1]
                    }
                );
            }
            return result;
        }
    }
}
