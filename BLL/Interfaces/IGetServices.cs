using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGetServices
    {
        VisaDTO GetVisa(string name);
        VisaDTO GetVisa(int? id);
        IEnumerable<VisaDTO> GetVisa();
        ClassDTO GetClass(string name);
        ClassDTO GetClass(int? id);
        IEnumerable<ClassDTO> GetClass();
        FlagCarryingAirlineDTO GetFlagCarryingAirline(string name);
        FlagCarryingAirlineDTO GetFlagCarryingAirline(int? id);
        IEnumerable<FlagCarryingAirlineDTO> GetFlagCarryingAirline();
        CountryDTO GetCountry(string name);
        CountryDTO GetCountry(int? id);
        CountryDTO GetCountry(CityDTO city);
        IEnumerable<CountryDTO> GetCountry();
        AirportDTO GetAirport(string name);
        AirportDTO GetAirport(int? id);
        IEnumerable<AirportDTO> GetAirport(CityDTO city);
        IEnumerable<AirportDTO> GetAirport();
        CityDTO GetCity(string name);
        CityDTO GetCity(int? id);
        IEnumerable<CityDTO> GetCity();
        void Dispose();
    }
}
