using DAL.Entities;
using DAL.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class AirlineTicketsContext : DbContext
    {
        public DbSet<AirCraft> AirCraft { get; set; } = null!;
        public DbSet<Airport> Airport { get; set; } = null!;
        public DbSet<ChildTicket> ChildTicket { get; set; } = null!;
        public DbSet<City> City { get; set; } = null!;
        public DbSet<Class> Class { get; set; } = null!;
        public DbSet<Country> Country { get; set; } = null!;
        public DbSet<FlagCarryingAirline> FlagCarryingAirline { get; set; } = null!;
        public DbSet<Flight> Flight { get; set; } = null!;
        public DbSet<Passenger> Passenger { get; set; } = null!;
        public DbSet<Ticket> Ticket { get; set; } = null!;
        public DbSet<Visa> Visa { get; set; } = null!;

        private string stringConnection;

        public AirlineTicketsContext(string stringConection = @"Server=(localdb)\mssqllocaldb;Database=TicketAirline;Trusted_Connection=True;")
        {
            this.stringConnection = stringConection;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(stringConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyAllConfiguration(modelBuilder);

            SetDefaultData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private void ApplyAllConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AirCraftMap());
            modelBuilder.ApplyConfiguration(new AirportMap());
            modelBuilder.ApplyConfiguration(new ChildTicketMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new FlagCarryingAirlineMap());
            modelBuilder.ApplyConfiguration(new FlightMap());
            modelBuilder.ApplyConfiguration(new PassengerMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
            modelBuilder.ApplyConfiguration(new VisaMap());
        }

        private void SetDefaultData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visa>().HasData(Services.VisaService.GetVisaList());
            modelBuilder.Entity<Class>().HasData(Services.ClassService.GetClassList());
            modelBuilder.Entity<Country>().HasData(Services.CountryService.GetCountryList());
            modelBuilder.Entity<City>().HasData(Services.CityService.GetCityList());
            modelBuilder.Entity<Airport>().HasData(Services.AirportService.GetAirportList());
            modelBuilder.Entity<FlagCarryingAirline>().HasData(Services.FlagCarryingAirlineService.GetFlagCarryingAirlineList());
            modelBuilder.Entity<AirCraft>().HasData(Services.AirCraftService.GetAirCraftList());
            modelBuilder.Entity<Flight>().HasData(Services.FlightService.GetFlightList());
            modelBuilder.Entity<Passenger>().HasData(Services.PassengerService.GetPassengerList());
            modelBuilder.Entity<Ticket>().HasData(Services.TicketService.GetTicketList());
            modelBuilder.Entity<ChildTicket>().HasData(Services.ChildTicketService.GetChildTicketList());
        }
    }
}
