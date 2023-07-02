using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class PassengerService
    {
        public static List<Passenger> GetPassengerList(string fileName = Config.passengerFilePath)
        {
            List<Passenger> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> passengerInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Passenger
                    {
                        Id = int.Parse(passengerInfo[0]),
                        Patronomic = passengerInfo[1],
                        Name = passengerInfo[2],
                        Surname = passengerInfo[3],
                        CityResidenceId = int.Parse(passengerInfo[4]),
                        Residence = passengerInfo[5],
                        DateOfBirthday = DateTime.Parse(passengerInfo[6]),
                        PhoneNumber = passengerInfo[7],
                        EmailAddress = passengerInfo[8],
                        Citizenship = passengerInfo[9],
                    }
                );
            }
            return result;
        }
    }
}
