using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using BLL.Infrastucture;
using System.Net.Sockets;
using System.Diagnostics.Metrics;

namespace BLL.Services
{
    public class GetService : IGetServices
    {
        IUnitOfWork DataBase { get; set; }

        public GetService(IUnitOfWork DataBase)
        {
            this.DataBase = DataBase;
        }


        public AirportDTO GetAirport(string name)
        {
            if (name == null || name == "")
                throw new ValidationException("Airport name not set", "");
            Airport airport = DataBase.Airports.Find(airport => airport.Name == name).FirstOrDefault();
            if (airport == null)
                throw new ValidationException("Airport not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Airport, AirportDTO>()));
            return Mapper.Map<Airport, AirportDTO>(airport);
        }

        public AirportDTO GetAirport(int? id)
        {
            if (id == null)
                throw new ValidationException("Airport id not set", "");
            var airport = DataBase.Airports.Get(id.Value);
            if (airport == null)
                throw new ValidationException("Airport not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Airport, AirportDTO>()));
            return Mapper.Map<Airport, AirportDTO>(airport);
        }

        public IEnumerable<AirportDTO> GetAirport(CityDTO city)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Airport, AirportDTO>()));
            IEnumerable<Airport> airport = DataBase.Airports.Find(airport => airport.CityId == city.Id);
            return Mapper.Map<IEnumerable<Airport>, List<AirportDTO>>(airport);
        }

        public IEnumerable<AirportDTO> GetAirport()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Airport, AirportDTO>()));
            IEnumerable<Airport> airports = DataBase.Airports.GetAll();
            return Mapper.Map<IEnumerable<Airport>, List<AirportDTO>>(airports);
        }


        public ClassDTO GetClass(string name)
        {
            if (name == null || name == "")
                throw new ValidationException("Class name not set", "");
            Class classObject = DataBase.Classes.Find(classObject => classObject.Name == name).FirstOrDefault();
            if (classObject == null)
                throw new ValidationException("Class not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Class, ClassDTO>()));
            return Mapper.Map<Class, ClassDTO>(classObject);
        }

        public ClassDTO GetClass(int? id)
        {
            if (id == null)
                throw new ValidationException("Class id not set", "");
            var classObject = DataBase.Classes.Get(id.Value);
            if (classObject == null)
                throw new ValidationException("Class not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Class, ClassDTO>()));
            return Mapper.Map<Class, ClassDTO>(classObject);
        }

        public IEnumerable<ClassDTO> GetClass()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Class, ClassDTO>()));
            IEnumerable<Class> @class = DataBase.Classes.GetAll();
            return Mapper.Map<IEnumerable<Class>, List<ClassDTO>>(@class);
        }


        public CountryDTO GetCountry(string name)
        {
            if (name == null || name == "")
                throw new ValidationException("Country name not set", "");
            Country country = DataBase.Countries.Find(country => country.Name == name).FirstOrDefault();
            if (country == null)
                throw new ValidationException("Country not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>()));
            return Mapper.Map<Country, CountryDTO>(country);
        }

        public CountryDTO GetCountry(int? id)
        {
            if (id == null)
                throw new ValidationException("Country name not set", "");
            var country = DataBase.Countries.Get(id.Value);
            if (country == null)
                throw new ValidationException("Country not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>()));
            return Mapper.Map<Country, CountryDTO>(country);
        }

        public CountryDTO GetCountry(CityDTO city)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>()));
            Country country = DataBase.Countries.Find(country => city.CountryId == country.Id).FirstOrDefault();
            return Mapper.Map<Country, CountryDTO>(country);
        }
        public IEnumerable<CountryDTO> GetCountry()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>()));
            IEnumerable<Country> countries = DataBase.Countries.GetAll();
            return Mapper.Map<IEnumerable<Country>, List<CountryDTO>>(countries);
        }


        public FlagCarryingAirlineDTO GetFlagCarryingAirline(string name)
        {
            if (name == null || name == "")
                throw new ValidationException("Flag carrying airline name not set", "");
            FlagCarryingAirline flagCarryingAirline = DataBase.FlagCarryingAirlines.Find(flagCarryingAirlines => flagCarryingAirlines.Name == name).FirstOrDefault();
            if (flagCarryingAirline == null)
                throw new ValidationException("Flag carrying airline not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<FlagCarryingAirline, FlagCarryingAirlineDTO>()));
            return Mapper.Map<FlagCarryingAirline, FlagCarryingAirlineDTO>(flagCarryingAirline);
        }

        public FlagCarryingAirlineDTO GetFlagCarryingAirline(int? id)
        {
            if (id == null)
                throw new ValidationException("Flag carrying airline id not set", "");
            var flagCarryingAirline = DataBase.FlagCarryingAirlines.Get(id.Value);
            if (flagCarryingAirline == null)
                throw new ValidationException("Flag carrying airline not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<FlagCarryingAirline, FlagCarryingAirlineDTO>()));
            return Mapper.Map<FlagCarryingAirline, FlagCarryingAirlineDTO>(flagCarryingAirline);
        }

        public IEnumerable<FlagCarryingAirlineDTO> GetFlagCarryingAirline()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<FlagCarryingAirline, FlagCarryingAirlineDTO>()));
            IEnumerable<FlagCarryingAirline> flagCarryingAirline = DataBase.FlagCarryingAirlines.GetAll();
            return Mapper.Map<IEnumerable<FlagCarryingAirline>, List<FlagCarryingAirlineDTO>>(flagCarryingAirline);
        }


        public VisaDTO GetVisa(string name)
        {
            if (name == null || name == "")
                throw new ValidationException("Visa name not set", "");
            Visa visa = DataBase.Visas.Find(visa => visa.Name == name).FirstOrDefault();
            if (visa == null)
                throw new ValidationException("Visa not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Visa, VisaDTO>()));
            return Mapper.Map<Visa, VisaDTO>(visa);
        }

        public VisaDTO GetVisa(int? id)
        {
            if (id == null)
                throw new ValidationException("Visa id not set", "");
            var visa = DataBase.Visas.Get(id.Value);
            if (visa == null)
                throw new ValidationException("Visa not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Visa, VisaDTO>()));
            return Mapper.Map<Visa, VisaDTO>(visa);
        }

        public IEnumerable<VisaDTO> GetVisa()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Visa, VisaDTO>()));
            IEnumerable<Visa> visa = DataBase.Visas.GetAll();
            return Mapper.Map<IEnumerable<Visa>, List<VisaDTO>>(visa);
        }


        public CityDTO GetCity(string name)
        {
            if (name == null || name == "")
                throw new ValidationException("City name not set", "");
            City city = DataBase.Cities.Find(city => city.Name == name).FirstOrDefault();
            if (city == null)
                throw new ValidationException("City not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()));
            return Mapper.Map<City, CityDTO>(city);
        }

        public CityDTO GetCity(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            City city = DataBase.Cities.Get(id.Value);
            if (city == null)
                throw new ValidationException("Телефон не найден", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()));
            return Mapper.Map<City, CityDTO>(city);
        }

        public IEnumerable<CityDTO> GetCity()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()));
            IEnumerable<City> city = DataBase.Cities.GetAll();
            return Mapper.Map<IEnumerable<City>, List<CityDTO>>(city);
        }


        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
