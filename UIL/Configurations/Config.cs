using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Services;
using DAL.Repositories;

namespace UIL.Configurations
{
    public static class Config
    {
        public static EFUnitOfWork db = new BLL.Infrastucture.ServiceModule().InitDatabase();

        public static TicketService ticketBLL = new TicketService(db);
        public static FlightService flightBLL = new FlightService(db);
        public static GetService otherBLL = new GetService(db);

    }
}
