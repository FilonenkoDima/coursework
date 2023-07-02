using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITicketService
    {
        void AddNewPassenger(PassengerDTO passengerDTO);
        PassengerDTO GetPassenger(int? id);
        IEnumerable<PassengerDTO> GetPassengers(string surname);
        IEnumerable<PassengerDTO> GetPassengers();
        void AddNewTicket(TicketDTO ticketDTO);
        TicketDTO GetTicket(int? id);
        TimeSpan GetDurationFlightTime(int? idTicket);
        void AddNewChildTicket(ChildTicketDTO childTicket);
        ChildTicketDTO GetChildTicket(int? id);
        IEnumerable<ChildTicketDTO> GetChildTicketByAccompanyingPersonTicketId(int? id);
        IEnumerable<ChildTicketDTO> GetChildTicket();
        void Dispose();
    }
}
