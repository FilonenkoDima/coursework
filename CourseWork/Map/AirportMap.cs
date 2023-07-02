using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
    public class AirportMap : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.ToTable("Airport").HasKey(x => x.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150).IsUnicode(true).HasColumnType("nvarchar");

            builder.HasOne(a => a.City)
                .WithMany(a => a.Airports)
                .HasForeignKey(a => a.CityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
