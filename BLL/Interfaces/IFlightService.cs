using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFlightService
    {
        IEnumerable<FlightDTO> FindFlightByCityLeaving(CityDTO city);
        IEnumerable<FlightDTO> FindFlightByCityArriving(CityDTO city);
        FlightDTO GetFlight(int? id);
        IEnumerable<FlightDTO> GetFlight();

        AirCraftDTO GetAirCraft(int? id);
        IEnumerable<AirCraftDTO> GetAirCraft();
        void Dispose();
    }
}
