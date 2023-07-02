using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class TicketService
    {
        public static List<Ticket> GetTicketList(string fileName = Config.ticketFilePath)
        {
            List<Ticket> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> ticketInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Ticket
                    {
                        Id = int.Parse(ticketInfo[0]),
                        FlightId = int.Parse(ticketInfo[1]),
                        PassengerId = int.Parse(ticketInfo[2]),
                        ClassId = int.Parse(ticketInfo[3]),
                        VisaId = int.Parse(ticketInfo[4]),
                    }
                );
            }
            return result;
        }
    }
}
