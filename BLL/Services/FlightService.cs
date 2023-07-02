using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using BLL.Infrastucture;

namespace BLL.Services
{
    public class FlightService : IFlightService
    {
        IUnitOfWork DataBase { get; set; }

        public FlightService(IUnitOfWork DataBase)
        {
            this.DataBase = DataBase;
        }

        public IEnumerable<FlightDTO> FindFlightByCityArriving(CityDTO city)
        {

            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Flight, FlightDTO>()));
            IEnumerable<Flight> flights = DataBase.Flights.Find(flight => flight.ArrivingAirportId == city.Id);
            return Mapper.Map<IEnumerable<Flight>, List<FlightDTO>>(flights);

        }

        public IEnumerable<FlightDTO> FindFlightByCityLeaving(CityDTO city)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Flight, FlightDTO>()));
            IEnumerable<Flight> flights = DataBase.Flights.Find(flight => flight.LeavingAirportId == city.Id);
            return Mapper.Map<IEnumerable<Flight>, List<FlightDTO>>(flights);
        }
        public FlightDTO GetFlight(int? id)
        {
            if (id == null)
                throw new ValidationException("Flight id not set", "");
            var flight = DataBase.Flights.Get(id.Value);
            if (flight == null)
                throw new ValidationException("Flight not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Flight, FlightDTO>()));
            return Mapper.Map<Flight, FlightDTO>(flight);
        }

        public IEnumerable<FlightDTO> GetFlight()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Flight, FlightDTO>()));
            return Mapper.Map<IEnumerable<Flight>, List<FlightDTO>>(DataBase.Flights.GetAll());
        }

        public AirCraftDTO GetAirCraft(int? id)
        {
            if (id == null)
                throw new ValidationException("AirCraft id not set", "");
            var airCraft = DataBase.AirCrafts.Get(id.Value);
            if (airCraft == null)
                throw new ValidationException("AirCraft not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<AirCraft, AirCraftDTO>()));
            return Mapper.Map<AirCraft, AirCraftDTO>(airCraft);
        }

        public IEnumerable<AirCraftDTO> GetAirCraft()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<AirCraft, AirCraftDTO>()));
            return Mapper.Map<IEnumerable<AirCraft>, List<AirCraftDTO>>(DataBase.AirCrafts.GetAll());
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
