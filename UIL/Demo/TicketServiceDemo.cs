using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using BLL;
using BLL.Services;
using AutoMapper;
using BLL.DTO;
using UIL.Models;
using Microsoft.Extensions.Options;
using BLL.Infrastucture;
using DAL.Entities;
using System.Net.Sockets;
using UIL.Services;
using UIL.Configurations;
using UIL.Menu;

namespace UIL.Demo
{
    public static class TicketServiceDemo
    {

        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Menus.TicketMenu();
                ChooseTicketServices(Service.CheckNumber(1, 13));
            }
        }
        private static void ChooseTicketServices(int choose)
        {
            switch (choose)
            {
                case 1:
                    RegistrationNewPassenger();
                    break;
                case 2:
                    PrintPassengerById();
                    break;
                case 3:
                    PrintPassengerBySurname();
                    break;
                case 4:
                    PrintAllPassengers();
                    break;
                case 5:
                    RegistrationNewTicket();
                    break;
                case 6:
                    PrintTicketById();
                    break;
                case 7:
                    PrintDurationFlightTime();
                    break;
                case 8:
                    RegistrationNewChildTicket();
                    break;
                case 9:
                    PrintChildTicketById();
                    break;
                case 10:
                    PrintChildTicketByAccompanyingPersonTicketId();
                    break;
                case 11:
                    PrintAllChildTickets();
                    break;
                case 12:
                    MainDemo.Start();
                    break;
                default:
                    Console.Write("Invalid operation. Try again.");
                    break;
            }
        }

        private static void RegistrationNewPassenger()
        {
            PassengerModel passenger = new PassengerModel();

            passenger.Id = default(int);

            Console.Write("Enter patronomic: ");
            passenger.Patronomic = Console.ReadLine();

            Console.Write("Enter name: ");
            passenger.Name = Console.ReadLine();

            Console.Write("Enter surname: ");
            passenger.Surname = Console.ReadLine();

            foreach (var item in Config.otherBLL.GetCity())
                Console.WriteLine($"Id: {item.Id};\tName: {item.Name}");
            Console.Write("Choose number of city: ");
            passenger.CityResidenceId = Service.CheckNumber(0);

            Console.Write("Enter residence: ");
            passenger.Residence = Console.ReadLine();

            Console.Write("Enter date of birthday(DD/MM/YYYY HH:MM:SS): ");
            passenger.DateOfBirthday = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter phone number: ");
            passenger.PhoneNumber = Console.ReadLine();

            Console.Write("Enter email adress: ");
            passenger.EmailAddress = Console.ReadLine();

            Console.Write("Enter citizenship: ");
            passenger.Citizenship = Console.ReadLine();

            try
            {
                var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PassengerModel, PassengerDTO>()));
                Config.ticketBLL.AddNewPassenger(Mapper.Map<PassengerModel, PassengerDTO>(passenger));
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.WriteLine("New ticket added successfully"); }
            Console.ReadLine();
        }

        private static void PrintPassengerBySurname()
        {
            Console.Write("Enter passenger surname: ");
            var passengers = Config.ticketBLL.GetPassengers(Console.ReadLine());
            foreach (var item in passengers)
                Console.WriteLine($"Id: {item.Id}; Patronomic: {item.Patronomic}; Name: {item.Name}; " +
                    $"Surname: {item.Surname}; City residence: {Config.otherBLL.GetCity(item.CityResidenceId).Name}; " +
                    $"Residence: {item.Residence}; Date of birthday: {item.DateOfBirthday}; PhoneNumber: {item.PhoneNumber}; " +
                    $"Email address: {item.EmailAddress}; Citizenship: {item.Citizenship}");
            Console.ReadLine();
        }

        private static void PrintPassengerById()
        {
            Console.Write("Enter passenger id: ");
            int numberId = Service.CheckNumber(1);
            var passenger = Config.ticketBLL.GetPassenger(numberId);
            Console.WriteLine($"Id: {passenger.Id}; Patronomic: {passenger.Patronomic}; Name: {passenger.Name}; " +
                $"Surname: {passenger.Surname}; City residence: {Config.otherBLL.GetCity(passenger.CityResidenceId).Name}; " +
                $"Residence: {passenger.Residence}; Date of birthday: {passenger.DateOfBirthday}; PhoneNumber: {passenger.PhoneNumber}; " +
                $"Email address: {passenger.EmailAddress}; Citizenship: {passenger.Citizenship}");
            Console.ReadLine();
        }

        public static void PrintAllPassengers()
        {
            foreach (var item in Config.ticketBLL.GetPassengers())
                Console.WriteLine($"Id: {item.Id}; Patronomic: {item.Patronomic}; Name: {item.Name}; " +
                    $"Surname: {item.Surname}; City residence: {Config.otherBLL.GetCity(item.CityResidenceId).Name}; " +
                    $"Residence: {item.Residence}; Date of birthday: {item.DateOfBirthday}; PhoneNumber: {item.PhoneNumber}; " +
                    $"Email address: {item.EmailAddress}; Citizenship: {item.Citizenship}; ");

            Console.ReadLine();
        }


        private static void RegistrationNewTicket()
        {
            TicketModel ticket = new TicketModel();

            ticket.Id = default(int);

            FlightServiceDemo.PrintAllFlights();
            Console.Write("Enter flight number: ");
            ticket.FlightId = Service.CheckNumber(1);

            Console.Write("Enter passenger id: ");
            ticket.PassengerId = Service.CheckNumber(1);

            OtherServiceDemo.PrintAllClasses();
            Console.Write("Enter class id: ");
            ticket.ClassId = Service.CheckNumber(1);

            OtherServiceDemo.PrintAllVisas();
            Console.Write("Enter visa id: ");
            ticket.VisaId = Service.CheckNumber(1);

            try
            {
                var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketModel, TicketDTO>()));
                Config.ticketBLL.AddNewTicket(Mapper.Map<TicketModel, TicketDTO>(ticket));
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.WriteLine("New ticket added successfully"); }
            Console.ReadLine();
        }

        private static void PrintTicketById()
        {
            Console.Write("Enter ticket id: ");
            var ticket = Config.ticketBLL.GetTicket(Service.CheckNumber(1));
            Console.WriteLine($"Id: {ticket.Id}; Flight id: {ticket.FlightId}; PassengerId: {ticket.PassengerId}; " +
                $"Full name: {Config.ticketBLL.GetPassenger(ticket.PassengerId).Surname} {Config.ticketBLL.GetPassenger(ticket.PassengerId).Name} " +
                $"{Config.ticketBLL.GetPassenger(ticket.PassengerId).Patronomic}; " +
                $"Class: {Config.otherBLL.GetClass(ticket.ClassId).Name}; " +
                $"Visa: {Config.otherBLL.GetVisa(ticket.VisaId).Name}; ");
            Console.ReadLine();
        }

        private static void PrintDurationFlightTime()
        {
            Console.Write("Enter ticket id: ");
            var duration = Config.ticketBLL.GetDurationFlightTime(Service.CheckNumber(1));
            Console.WriteLine($"Duration: Days - {duration.Days}, Hours - {duration.Hours}, Minutes - {duration.Minutes}, " +
                $"Seconds - {duration.Seconds}");
            Console.ReadLine();
        }


        private static void RegistrationNewChildTicket()
        {
            ChildTicketModel childTicket = new ChildTicketModel();

            childTicket.Id = default(int);

            Console.Write("Enter passenger id: ");
            childTicket.PassengerId = Service.CheckNumber(1);

            Console.Write("Enter accompanying person ticket id: ");
            childTicket.AccompanyingPersonTicketId = Service.CheckNumber(1);

            OtherServiceDemo.PrintAllClasses();
            Console.Write("Enter class id: ");
            childTicket.ClassId = Service.CheckNumber(1);

            OtherServiceDemo.PrintAllVisas();
            Console.Write("Enter visa id: ");
            childTicket.VisaId = Service.CheckNumber(1);

            try
            {
                var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ChildTicketModel, ChildTicketDTO>()));
                Config.ticketBLL.AddNewChildTicket(Mapper.Map<ChildTicketModel, ChildTicketDTO>(childTicket));
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.WriteLine("New child ticket added successfully"); }
            Console.ReadLine();
        }

        private static void PrintChildTicketById()
        {
            Console.Write("Enter child ticket id: ");
            var childTicket = Config.ticketBLL.GetChildTicket(Service.CheckNumber(1));
            Console.WriteLine($"Id: {childTicket.Id}; PassengerId: {childTicket.PassengerId}; " +
                $"Full name: {Config.ticketBLL.GetPassenger(childTicket.PassengerId).Surname} {Config.ticketBLL.GetPassenger(childTicket.PassengerId).Name} " +
                $"{Config.ticketBLL.GetPassenger(childTicket.PassengerId).Patronomic}; " +
                $"accompanying person ticket id: {childTicket.AccompanyingPersonTicketId}; " +
                $"Full name of accompanying person ticket: {Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(childTicket.AccompanyingPersonTicketId).PassengerId).Surname} " +
                $"{Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(childTicket.AccompanyingPersonTicketId).PassengerId).Name} " +
                $"{Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(childTicket.AccompanyingPersonTicketId).PassengerId).Patronomic}; " +
                $"Class: {Config.otherBLL.GetClass(childTicket.ClassId).Name}; " +
                $"Visa: {Config.otherBLL.GetVisa(childTicket.VisaId).Name}; ");
            Console.ReadLine();
        }

        private static void PrintChildTicketByAccompanyingPersonTicketId()
        {
            Console.Write("Enter child ticket id: ");
            var childTickets = Config.ticketBLL.GetChildTicketByAccompanyingPersonTicketId(Service.CheckNumber(1));
            foreach (var item in childTickets)
                Console.WriteLine($"Id: {item.Id}; PassengerId: {item.PassengerId}; " +
                    $"Full name: {Config.ticketBLL.GetPassenger(item.PassengerId).Surname} {Config.ticketBLL.GetPassenger(item.PassengerId).Name} " +
                    $"{Config.ticketBLL.GetPassenger(item.PassengerId).Patronomic}; " +
                    $"accompanying person ticket id: {item.AccompanyingPersonTicketId}; " +
                    $"Full name of accompanying person ticket: {Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(item.AccompanyingPersonTicketId).PassengerId).Surname} " +
                    $"{Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(item.AccompanyingPersonTicketId).PassengerId).Name} " +
                    $"{Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(item.AccompanyingPersonTicketId).PassengerId).Patronomic}; " +
                    $"Class: {Config.otherBLL.GetClass(item.ClassId).Name}; " +
                    $"Visa: {Config.otherBLL.GetVisa(item.VisaId).Name}; ");
            Console.ReadLine();
        }

        public static void PrintAllChildTickets()
        {
            foreach (var item in Config.ticketBLL.GetChildTicket())
                Console.WriteLine($"Id: {item.Id}; PassengerId: {item.PassengerId}; " +
                    $"Full name: {Config.ticketBLL.GetPassenger(item.PassengerId).Surname} {Config.ticketBLL.GetPassenger(item.PassengerId).Name} " +
                    $"{Config.ticketBLL.GetPassenger(item.PassengerId).Patronomic}; " +
                    $"accompanying person ticket id: {item.AccompanyingPersonTicketId}; " +
                    $"Full name of accompanying person ticket: {Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(item.AccompanyingPersonTicketId).PassengerId).Surname} " +
                    $"{Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(item.AccompanyingPersonTicketId).PassengerId).Name} " +
                    $"{Config.ticketBLL.GetPassenger(Config.ticketBLL.GetTicket(item.AccompanyingPersonTicketId).PassengerId).Patronomic}; " +
                    $"Class: {Config.otherBLL.GetClass(item.ClassId).Name}; " +
                    $"Visa: {Config.otherBLL.GetVisa(item.VisaId).Name}; ");

            Console.ReadLine();
        }
    }
}
