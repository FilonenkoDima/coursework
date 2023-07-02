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
    public class ChildTicketMap : IEntityTypeConfiguration<ChildTicket> 
    {
        public void Configure(EntityTypeBuilder<ChildTicket> builder)
        {
            builder.ToTable("ChildTicket").HasKey(x => x.Id);

            builder
                .HasOne(a => a.Passenger)
                .WithMany(a => a.ChildTickets)
                .HasForeignKey(a => a.PassengerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.AccompanyingPersonTicket)
                .WithMany(a => a.ChildTickets)
                .HasForeignKey(a => a.AccompanyingPersonTicketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Class)
                .WithMany(a => a.ChildTickets)
                .HasForeignKey(a => a.ClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Visa)
                .WithMany(a => a.ChildTickets)
                .HasForeignKey(a => a.VisaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
