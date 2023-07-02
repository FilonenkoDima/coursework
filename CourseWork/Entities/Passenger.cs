﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Patronomic { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CityResidenceId { get; set; }
        public string Residence { get; set;}
        public DateTime DateOfBirthday { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set;}
        public string Citizenship { get; set;}

        public City CityResidence { get; set; } 

        public List<Ticket> Tickets { get; set; }
        public List<ChildTicket> ChildTickets { get; set; }

        public Passenger() 
        {
            Tickets = new List<Ticket>();
            ChildTickets = new List<ChildTicket>();
        }

        public override string ToString()
        {
            return $"{Id} - {Patronomic} - {Name} - {Surname} - CityResidence({CityResidence}) - {Residence} - " +
                $"{DateOfBirthday} - {PhoneNumber} - {EmailAddress} - {Citizenship}";
        }
    }
}
