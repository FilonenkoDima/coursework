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
    public class AirCraftMap : IEntityTypeConfiguration<AirCraft>
    {

        public void Configure(EntityTypeBuilder<AirCraft> builder)
        {
            builder.ToTable("AirCraft").HasKey(x => x.Id);

            builder.HasOne(a => a.FlagCarryingAirline)
                    .WithMany(a => a.AirCrafts)
                    .HasForeignKey(a => a.FlagCarryingAirlineId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
