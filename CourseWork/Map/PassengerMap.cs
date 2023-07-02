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
    public class PassengerMap : IEntityTypeConfiguration<Passenger> 
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("Passenger").HasKey(p => p.Id);
            builder.Property(p => p.Patronomic).IsRequired(false).HasMaxLength(50).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(50).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.Residence).IsRequired().HasMaxLength(50).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.DateOfBirthday).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(25).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.PhoneNumber).IsRequired(false).HasMaxLength(100).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.Citizenship).IsRequired().HasMaxLength(70).IsUnicode(true).HasColumnType("nvarchar");

            builder
                .HasOne(a => a.CityResidence)
                .WithMany(a => a.Passengers)
                .HasForeignKey(a => a.CityResidenceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
