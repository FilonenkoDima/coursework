using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIL.Configurations;
using UIL.Menu;
using UIL.Services;

namespace UIL.Demo
{
    public static class FlightServiceDemo
    {

        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Menus.FlightMenu();
                ChooseFlightServices(Service.CheckNumber(1, 4));
            }
        }
        private static void ChooseFlightServices(int choose)
        {
            switch (choose)
            {
                case 1:
                    PrintFlightByCityLeaving();
                    break;
                case 2:
                    PrintFlightByCityArriving();
                    break;
                case 3:
                    PrintFlightById();
                    break;
                case 4:
                    PrintAllFlights();
                    break;
                case 5:
                    PrintAirCrafttById();
                    break;
                case 6:
                    PrintAllAirCrafts();
                    break;
                case 7:
                    MainDemo.Start();
                    break;
                default:
                    Console.Write("Invalid operation. Try again.");
                    break;
            }
        }


        private static void PrintFlightByCityLeaving()
        {
            Console.Write("Enter city leaving name: ");
            var flightByCityLeaving = Config.flightBLL.FindFlightByCityLeaving(Config.otherBLL.GetCity(Console.ReadLine()));
            foreach (var item in flightByCityLeaving)
                Console.WriteLine($"Id: {item.Id}; Aircraft registration number: {item.AirCraftId}; " +
                    $"Flag carrying airline: {Config.otherBLL.GetFlagCarryingAirline(Config.flightBLL.GetAirCraft(item.AirCraftId).Id).Name}; " +
                    $"Leaving airport name: {Config.otherBLL.GetAirport(item.LeavingAirportId).Name}; " +
                    $"Leaving city name: {Config.otherBLL.GetCity(Config.otherBLL.GetAirport(item.LeavingAirportId).Id).Name}; " +
                    $"Date time of leaving: {item.DateTimeOfLeaving}; " +
                    $"Arriving airport name: {Config.otherBLL.GetAirport(item.ArrivingAirportId).Name}; " +
                    $"Arriving city name: {Config.otherBLL.GetCity(Config.otherBLL.GetAirport(item.ArrivingAirportId).Id).Name}; " +
                    $"Date time of arriving: {item.DateTimeOfArriving}; ");
            Console.ReadLine();
        }

        private static void PrintFlightByCityArriving()
        {
            Console.Write("Enter city arriving name: ");
            var flightByCityArriving = Config.flightBLL.FindFlightByCityArriving(Config.otherBLL.GetCity(Console.ReadLine()));
            foreach (var item in flightByCityArriving)
                Console.WriteLine($"Id: {item.Id}; Aircraft registration number: {item.AirCraftId}; " +
                    $"Flag carrying airline: {Config.otherBLL.GetFlagCarryingAirline(Config.flightBLL.GetAirCraft(item.AirCraftId).Id).Name}; " +
                    $"Leaving airport name: {Config.otherBLL.GetAirport(item.LeavingAirportId).Name}; " +
                    $"Leaving city name: {Config.otherBLL.GetCity(Config.otherBLL.GetAirport(item.LeavingAirportId).Id).Name}; " +
                    $"Date time of leaving: {item.DateTimeOfLeaving}; " +
                    $"Arriving airport name: {Config.otherBLL.GetAirport(item.ArrivingAirportId).Name}; " +
                    $"Arriving city name: {Config.otherBLL.GetCity(Config.otherBLL.GetAirport(item.ArrivingAirportId).Id).Name}; " +
                    $"Date time of arriving: {item.DateTimeOfArriving}; ");
            Console.ReadLine();
        }

        private static void PrintFlightById()
        {
            Console.Write("Enter flight id: ");
            var flight = Config.flightBLL.GetFlight(Service.CheckNumber(1));
            Console.WriteLine($"Id: {flight.Id}; Aircraft registration number: {flight.AirCraftId}; " +
                $"Flag carrying airline: {Config.otherBLL.GetFlagCarryingAirline(Config.flightBLL.GetAirCraft(flight.AirCraftId).Id).Name}; " +
                $"Leaving airport name: {Config.otherBLL.GetAirport(flight.LeavingAirportId).Name}; " +
                $"Leaving city name: {Config.otherBLL.GetCity(Config.otherBLL.GetAirport(flight.LeavingAirportId).Id).Name}; " +
                $"Date time of leaving: {flight.DateTimeOfLeaving}; " +
                $"Arriving airport name: {Config.otherBLL.GetAirport(flight.ArrivingAirportId).Name}; " +
                $"Arriving city name: {Config.otherBLL.GetCity(Config.otherBLL.GetAirport(flight.ArrivingAirportId).Id).Name}; " +
                $"Date time of arriving: {flight.DateTimeOfArriving}; ");
            Console.ReadLine();
        }

        public static void PrintAllFlights()
        {
            foreach (var item in Config.flightBLL.GetFlight())
            {
                Console.WriteLine($"Id: {item.Id}; Aircraft registration number: {item.AirCraftId}; " +
                    //$"Flag carrying airline: {Config.otherBLL.GetFlagCarryingAirline(Config.flightBLL.GetAirCraft(item.AirCraftId).Id).Name}; " +
                    $"Leaving airport name: {Config.otherBLL.GetAirport(item.LeavingAirportId).Name}; " +
                    //$"Leaving city name: {Config.otherBLL.GetCity(Config.otherBLL.GetAirport(item.LeavingAirportId).Id).Name}; " +
                    $"Date time of leaving: {item.DateTimeOfLeaving}; " +
                    $"Arriving airport name: {Config.otherBLL.GetAirport(item.ArrivingAirportId).Name}; " +
                    //$"Arriving city name: {Config.otherBLL.GetCity(Config.otherBLL.GetAirport(item.ArrivingAirportId).Id).Name}; " +
                    $"Date time of arriving: {item.DateTimeOfArriving}; ");
            }
            Console.ReadLine();
        }


        private static void PrintAirCrafttById()
        {
            Console.Write("Enter flight id: ");
            var airCraft = Config.flightBLL.GetAirCraft(Service.CheckNumber(1));
            Console.WriteLine($"Id: {airCraft.Id}; " +
                $"Flag carrying airline: {Config.otherBLL.GetFlagCarryingAirline(airCraft.FlagCarryingAirlineId).Name}; " +
                $"Number of first class passengers: {airCraft.NumberOfFirstClassPassengers}; " +
                $"Number of bussiness class passengers: {airCraft.NumberOfBussinessClassPassengers}; " +
                $"Number of econom class passengers: {airCraft.NumberOfEconomClassPassengers}; ");
        }

        public static void PrintAllAirCrafts()
        {
            foreach (var item in Config.flightBLL.GetAirCraft())
            {
                Console.WriteLine($"Id: {item.Id}; " +
                    $"Flag carrying airline: {Config.otherBLL.GetFlagCarryingAirline(item.FlagCarryingAirlineId).Name}; " +
                    $"Number of first class passengers: {item.NumberOfFirstClassPassengers}; " +
                    $"Number of bussiness class passengers: {item.NumberOfBussinessClassPassengers}; " +
                    $"Number of econom class passengers: {item.NumberOfEconomClassPassengers}; ");
            }
            Console.ReadLine();
        }
    }
}
