using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket").HasKey(p => p.Id);

            builder
                .HasOne(a => a.Flight)
                .WithMany(a => a.Tickets)
                .HasForeignKey(a => a.FlightId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Passenger)
                .WithMany(a => a.Tickets)
                .HasForeignKey(a => a.PassengerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Class)
                .WithMany(a => a.Tickets)
                .HasForeignKey(a => a.ClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Visa)
                .WithMany(a => a.Tickets)
                .HasForeignKey(a => a.VisaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
