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
    internal class CityMap : IEntityTypeConfiguration<City> 
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City").HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100).IsUnicode(true).HasColumnType("nvarchar");

            builder.HasOne(a => a.Country)
                .WithMany(a => a.Cities)
                .HasForeignKey(a => a.CountryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
