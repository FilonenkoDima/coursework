using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Infrastucture;

namespace BLL.Services
{
    public class TicketService : ITicketService
    {
        IUnitOfWork DataBase { get; set; }

        public TicketService(IUnitOfWork DataBase)
        {
            this.DataBase = DataBase;
        }


        public void AddNewPassenger(PassengerDTO passengerDTO)
        {
            City cityResidence = DataBase.Cities.Get(passengerDTO.CityResidenceId);

            if (cityResidence == null)
                throw new ValidationException("City residence not found", "");

            Passenger passenger = new Passenger()
            {
                Patronomic = passengerDTO.Patronomic,
                Name = passengerDTO.Name,
                Surname = passengerDTO.Surname,
                CityResidenceId = cityResidence.Id,
                Residence = passengerDTO.Residence,
                DateOfBirthday = passengerDTO.DateOfBirthday,
                PhoneNumber = passengerDTO.PhoneNumber,
                EmailAddress = passengerDTO.EmailAddress,
                Citizenship = passengerDTO.Citizenship,
            };
            DataBase.Passengers.Create(passenger);
            DataBase.Save();
        }

        public PassengerDTO GetPassenger(int? id)
        {
            if (id == null)
                throw new ValidationException("Passenger id not set", "");
            var passenger = DataBase.Passengers.Get(id.Value);
            if (passenger == null)
                throw new ValidationException("Passenger not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Passenger, PassengerDTO>()));
            return Mapper.Map<Passenger, PassengerDTO>(passenger);
        }

        public IEnumerable<PassengerDTO> GetPassengers(string surname)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Passenger, PassengerDTO>()));
            IEnumerable<Passenger> passengers = DataBase.Passengers.Find(passengers => passengers.Surname == surname);
            return Mapper.Map<IEnumerable<Passenger>, List<PassengerDTO>>(passengers);
        }

        public IEnumerable<PassengerDTO> GetPassengers()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Passenger, PassengerDTO>()));
            IEnumerable<Passenger> passengers = DataBase.Passengers.GetAll();
            return Mapper.Map<IEnumerable<Passenger>, List<PassengerDTO>>(passengers);
        }


        public void AddNewTicket(TicketDTO ticketDTO)
        {
            Flight flight = DataBase.Flights.Get(ticketDTO.FlightId);
            Passenger passenger = DataBase.Passengers.Get(ticketDTO.PassengerId);
            Class @class = DataBase.Classes.Get(ticketDTO.ClassId);
            Visa visa = DataBase.Visas.Get(ticketDTO.VisaId);

            if (flight == null)
                throw new ValidationException("Flight not found", "");
            if (passenger == null)
                throw new ValidationException("Passenger not found", "");
            if (@class == null)
                throw new ValidationException("Class not found", "");
            if (visa == null)
                throw new ValidationException("Visa not found", "");

            Ticket ticket = new Ticket
            {
                FlightId = flight.Id,
                PassengerId = passenger.Id,
                ClassId = @class.Id,
                VisaId = visa.Id,
            };
            DataBase.Tickets.Create(ticket);
            DataBase.Save();
        }

        public TicketDTO GetTicket(int? id)
        {
            if (id == null)
                throw new ValidationException("Ticket id not set", "");
            var ticket = DataBase.Tickets.Get(id.Value);
            if (ticket == null)
                throw new ValidationException("Ticket not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()));
            return Mapper.Map<Ticket, TicketDTO>(ticket);
        }

        public TimeSpan GetDurationFlightTime(int? idTicket)
        {
            if (idTicket == null)
                throw new ValidationException("Ticket id not set", "");

            var ticket = DataBase.Tickets.Get(idTicket.Value);
            if (ticket == null)
                throw new ValidationException("Ticket not found", "");

            var flight = DataBase.Flights.Get(ticket.FlightId);
            if (flight == null)
                throw new ValidationException("Flight not found", "");

            return (flight.DateTimeOfArriving - flight.DateTimeOfLeaving).Duration();
        }


        public void AddNewChildTicket(ChildTicketDTO childTicketDTO)
        {
            Passenger passenger = DataBase.Passengers.Get(childTicketDTO.PassengerId);
            Ticket accompanyingPersonTicket = DataBase.Tickets.Get(childTicketDTO.AccompanyingPersonTicketId);
            Class @class = DataBase.Classes.Get(childTicketDTO.ClassId);
            Visa visa = DataBase.Visas.Get(childTicketDTO.VisaId);

            if (passenger == null)
                throw new ValidationException("Passenger residence not found", "");
            if (accompanyingPersonTicket == null)
                throw new ValidationException("AccompanyingPersonTicket residence not found", "");
            if (@class == null)
                throw new ValidationException("Class residence not found", "");
            if (visa == null)
                throw new ValidationException("Visa residence not found", "");

            ChildTicket childTicket = new ChildTicket()
            {
                PassengerId = passenger.Id,
                AccompanyingPersonTicketId = accompanyingPersonTicket.Id,
                ClassId = @class.Id,
                VisaId = visa.Id,
            };
            DataBase.ChildTickets.Create(childTicket);
            DataBase.Save();
        }

        public ChildTicketDTO GetChildTicket(int? id)
        {
            if (id == null)
                throw new ValidationException("Child ticket id not set", "");
            var childTicket = DataBase.ChildTickets.Get(id.Value);
            if (childTicket == null)
                throw new ValidationException("Child ticket not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ChildTicket, ChildTicketDTO>()));
            return Mapper.Map<ChildTicket, ChildTicketDTO>(childTicket);
        }

        public IEnumerable<ChildTicketDTO> GetChildTicketByAccompanyingPersonTicketId(int? id)
        {
            if (id == null)
                throw new ValidationException("Child ticket id not set", "");
            var ticket = DataBase.Tickets.Get(id.Value);
            if (ticket == null)
                throw new ValidationException("Ticket not found", "");
            var childTicket = DataBase.ChildTickets.Find(childTicket => childTicket.AccompanyingPersonTicketId == ticket.Id);
            if (childTicket == null)
                throw new ValidationException("Child ticket not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ChildTicket, ChildTicketDTO>()));
            return Mapper.Map<IEnumerable<ChildTicket>, List<ChildTicketDTO>>(childTicket);
        }

        public IEnumerable<ChildTicketDTO> GetChildTicket()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ChildTicket, ChildTicketDTO>()));
            IEnumerable<ChildTicket> childTickets = DataBase.ChildTickets.GetAll();
            return Mapper.Map<IEnumerable<ChildTicket>, List<ChildTicketDTO>>(childTickets);
        }
        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
