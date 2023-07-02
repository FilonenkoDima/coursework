using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL.Menu
{
    public static class Menus
    {
        public static void MainMenu()
        {
            Console.Write("\tMenu\n" +
                "1 - Ticket service\n" +
                "2 - Flight service\n" +
                "3 - Other service\n" +
                "4 - Exit\n" +
                "Operation: ");
        }
        public static void TicketMenu()
        {
            Console.Write("\tTicket services\n" +
                "1 - Registration new passenger\n" +
                "2 - Get passenger by id\n" +
                "3 - Get passengers by surname\n" +
                "4 - Get all passengers\n" +
                "5 - Registration new ticket\n" +
                "6 - Get ticket by id\n" +
                "7 - Get duration flight time\n" +
                "8 - Registration new child ticket\n" +
                "9 - Get child ticket by id\n" +
                "10 - Get child ticket by accompanying person ticket id\n" +
                "11 - Get all child tickets" +
                "12 - Back\n" +
                "Operation: ");
        }

        public static void FlightMenu()
        {
            Console.Write("\tFlight services\n" +
                "1 - Get flight by city leaving name\n" +
                "2 - Get flight by city arriving name\n" +
                "3 - Get flight by id\n" +
                "4 - Get all flights\n" +
                "5 - Get aircraft by id\n" +
                "6 - Get all aircrafts\n" +
                "7 - Back\n" +
                "Operation: ");
        }

        public static void OtherMenu()
        {
            Console.Write("\tOther services\n" +
                "1 - Get visa by name\n" +
                "2 - Get visa by id\n" +
                "3 - Get all visas\n" +
                "4 - Get class by name\n" +
                "5 - Get class by id\n" +
                "6 - Get all classes\n" +
                "7 - Get flag carrying airline by name\n" +
                "8 - Get flag carrying airline by id\n" +
                "9 - Get all flag carrying airline\n" +
                "10 - Get country by name\n" +
                "11 - Get country by id\n" +
                "12 - Get country by city name\n" +
                "13 - Get all country\n" +
                "14 - Get airport by name\n" +
                "15 - Get airport by id\n" +
                "16 - Get airports by city name\n" +
                "17 - Get all airports\n" +
                "18 - Get city by name\n" +
                "19 - Get city by id\n" +
                "20 - Get all cities\n" +
                "21 - Back\n" +
                "Operation: ");
        }
    }
}
