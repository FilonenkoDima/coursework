using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class ChildTicketService
    {
        public static List<ChildTicket> GetChildTicketList(string fileName = Config.childTicketFilePath)
        {
            List<ChildTicket> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> childTicketInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new ChildTicket
                    {
                        Id = int.Parse(childTicketInfo[0]),
                        PassengerId = int.Parse(childTicketInfo[1]),
                        AccompanyingPersonTicketId = int.Parse(childTicketInfo[2]),
                        ClassId = int.Parse(childTicketInfo[3]),
                        VisaId = int.Parse(childTicketInfo[4]),
                    }
                );
            }
            return result;
        }
    }
}
