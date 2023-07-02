using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIL.Menu;
using UIL.Services;

namespace UIL.Demo
{
    public static class MainDemo
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Menus.MainMenu();
                ChooseServices(Service.CheckNumber(1, 4));
            }
        }

        private static void ChooseServices(int choose)
        {
            switch (choose)
            {
                case 1:
                    TicketServiceDemo.Start();
                    break;
                case 2:
                    FlightServiceDemo.Start();
                    break;
                case 3:
                    OtherServiceDemo.Start();
                    break;
                case 4:
                    return;
                default:
                    Console.Write("Invalid operation. Try again.");
                    break;
            }
        }
    }
}
