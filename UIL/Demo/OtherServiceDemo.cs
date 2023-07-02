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
    public static class OtherServiceDemo
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Menus.OtherMenu();
                ChooseOtherServices(Service.CheckNumber(1, 22));
            }
        }
        private static void ChooseOtherServices(int choose)
        {
            switch (choose)
            {
                case 1:
                    PrintVisaByName();
                    break;
                case 2:
                    PrintVisaById();
                    break;
                case 3:
                    PrintAllVisas();
                    break;
                case 4:
                    PrintClassByName();
                    break;
                case 5:
                    PrintClassById();
                    break;
                case 6:
                    PrintAllClasses();
                    break;
                case 7:
                    PrintFlagCarryingAirlineByName();
                    break;
                case 8:
                    PrintFlagCarryingAirlineById();
                    break;
                case 9:
                    PrintAllFlagCarryingAirlines();
                    break;
                case 10:
                    PrintCountryByName();
                    break;
                case 11:
                    PrintCountryById();
                    break;
                case 12:
                    PrintCountryByCityName();
                    break;
                case 13:
                    PrintAllCountries();
                    break;
                case 14:
                    PrintAirportByName();
                    break;
                case 15:
                    PrintAirportById();
                    break;
                case 16:
                    PrintAirportsByCityName();
                    break;
                case 17:
                    PrintAllAirports();
                    break;
                case 18:
                    PrintCityByName();
                    break;
                case 19:
                    PrintCityById();
                    break;
                case 20:
                    PrintAllCities();
                    break;
                case 21:
                    MainDemo.Start();
                    break;
                default:
                    Console.Write("Invalid operation. Try again.");
                    break;
            }
        }


        private static void PrintVisaByName()
        {
            Console.Write("Enter visa name: ");
            var visa = Config.otherBLL.GetVisa(Console.ReadLine());
            Console.WriteLine($"Id: {visa.Id}; Name: {visa.Name};");
            Console.ReadLine();
        }

        private static void PrintVisaById()
        {
            Console.Write("Enter visa id: ");
            var visa = Config.otherBLL.GetVisa(Service.CheckNumber(1));
            Console.WriteLine($"Id: {visa.Id}; Name: {visa.Name};");
            Console.ReadLine();
        }

        public static void PrintAllVisas()
        {
            foreach (var item in Config.otherBLL.GetVisa())
            {
                Console.WriteLine($"Id: {item.Id}; Name: {item.Name};");
            }
            Console.ReadLine();
        }


        private static void PrintClassByName()
        {
            Console.Write("Enter class name: ");
            var @class = Config.otherBLL.GetClass(Console.ReadLine());
            Console.WriteLine($"Id: {@class.Id}; Name: {@class.Name};");
            Console.ReadLine();
        }

        private static void PrintClassById()
        {
            Console.Write("Enter class id: ");
            var @class = Config.otherBLL.GetClass(Service.CheckNumber(1));
            Console.WriteLine($"Id: {@class.Id}; Name: {@class.Name};");
            Console.ReadLine();
        }

        public static void PrintAllClasses()
        {
            foreach (var item in Config.otherBLL.GetClass())
            {
                Console.WriteLine($"Id: {item.Id}; Name: {item.Name};");
            }
            Console.ReadLine();
        }


        private static void PrintFlagCarryingAirlineByName()
        {
            Console.Write("Enter flag carrying airline name: ");
            var flagCarryingAirline = Config.otherBLL.GetFlagCarryingAirline(Console.ReadLine());
            Console.WriteLine($"Id: {flagCarryingAirline.Id}; Name: {flagCarryingAirline.Name};");
            Console.ReadLine();
        }

        private static void PrintFlagCarryingAirlineById()
        {
            Console.Write("Enter flag carrying airline id: ");
            var flagCarryingAirline = Config.otherBLL.GetFlagCarryingAirline(Service.CheckNumber(1));
            Console.WriteLine($"Id: {flagCarryingAirline.Id}; Name: {flagCarryingAirline.Name};");
            Console.ReadLine();
        }

        public static void PrintAllFlagCarryingAirlines()
        {
            foreach (var item in Config.otherBLL.GetFlagCarryingAirline())
            {
                Console.WriteLine($"Id: {item.Id}; Name: {item.Name};");
            }
            Console.ReadLine();
        }


        private static void PrintCountryByName()
        {
            Console.Write("Enter country name: ");
            var country = Config.otherBLL.GetCountry(Console.ReadLine());
            Console.WriteLine($"Id: {country.Id}; Name: {country.Name};");
            Console.ReadLine();
        }

        private static void PrintCountryById()
        {
            Console.Write("Enter country id: ");
            var country = Config.otherBLL.GetCountry(Service.CheckNumber(1));
            Console.WriteLine($"Id: {country.Id}; Name: {country.Name};");
            Console.ReadLine();
        }
        private static void PrintCountryByCityName()
        {
            PrintAllCities();
            Console.Write("Enter city name: ");
            var country = Config.otherBLL.GetFlagCarryingAirline(Config.otherBLL.GetCity(Console.ReadLine()).CountryId);
            Console.WriteLine($"Id: {country.Id}; Name: {country.Name};");
            Console.ReadLine();
        }

        public static void PrintAllCountries()
        {
            foreach (var item in Config.otherBLL.GetCountry())
            {
                Console.WriteLine($"Id: {item.Id}; Name: {item.Name};");
            }
            Console.ReadLine();
        }


        private static void PrintAirportByName()
        {
            Console.Write("Enter airport name: ");
            var airport = Config.otherBLL.GetAirport(Console.ReadLine());
            Console.WriteLine($"Id: {airport.Id}; Name: {airport.Name}; City: {Config.otherBLL.GetCity(airport.CityId).Name};");
            Console.ReadLine();
        }

        private static void PrintAirportById()
        {
            Console.Write("Enter airport id: ");
            var airport = Config.otherBLL.GetAirport(Service.CheckNumber(1));
            Console.WriteLine($"Id: {airport.Id}; Name: {airport.Name}; City: {Config.otherBLL.GetCity(airport.CityId).Name};");
            Console.ReadLine();
        }

        private static void PrintAirportsByCityName()
        {
            //PrintAllCities();
            Console.Write("Enter city name: ");
            var airports = Config.otherBLL.GetAirport(Config.otherBLL.GetCity(Console.ReadLine()));
            foreach(var item in airports) 
            {
                Console.WriteLine($"Id: {item.Id}; Name: {item.Name}; City: {Config.otherBLL.GetCity(item.CityId).Name};");
            }
            Console.ReadLine();
        }

        public static void PrintAllAirports()
        {
            foreach (var item in Config.otherBLL.GetAirport())
            {
                Console.WriteLine($"Id: {item.Id}; Name: {item.Name}; City: {Config.otherBLL.GetCity(item.CityId).Name};");
            }
            Console.ReadLine();
        }


        private static void PrintCityByName()
        {
            Console.Write("Enter city name: ");
            var city = Config.otherBLL.GetCity(Console.ReadLine());
            Console.WriteLine($"Id: {city.Id}; Name: {city.Name}; Country: {Config.otherBLL.GetCountry(city.CountryId)};");
            Console.ReadLine();
        }

        private static void PrintCityById()
        {
            Console.Write("Enter city id: ");
            var city = Config.otherBLL.GetCity(Service.CheckNumber(1));
            Console.WriteLine($"Id: {city.Id}; Name: {city.Name}; Country: {Config.otherBLL.GetCountry(city.CountryId)};");
            Console.ReadLine();
        }

        public static void PrintAllCities()
        {
            foreach (var item in Config.otherBLL.GetCity())
            {
                Console.WriteLine($"Id: {item.Id}; Name: {item.Name}; Country: {Config.otherBLL.GetCountry(item.CountryId)};");
            }
            Console.ReadLine();
        }
    }
}
