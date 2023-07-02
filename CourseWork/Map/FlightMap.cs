using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
    public class FlightMap : IEntityTypeConfiguration<Flight> 
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flight").HasKey(p => p.Id);
            builder.Property(p => p.DateTimeOfLeaving).IsRequired();
            builder.Property(p => p.DateTimeOfArriving).IsRequired();

            builder
                .HasOne(a => a.AirCraft)
                .WithMany(a => a.Flights)
                .HasForeignKey(a => a.AirCraftId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.LeavingAirport)
                .WithMany(a => a.FlightLeavingAirport)
                .HasForeignKey(a => a.LeavingAirportId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.ArrivingAirport)
                .WithMany(a => a.FlightArrivingAirport)
                .HasForeignKey(a => a.ArrivingAirportId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
