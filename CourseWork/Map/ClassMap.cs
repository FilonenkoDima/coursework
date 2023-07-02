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
    public class ClassMap : IEntityTypeConfiguration<Class>
    {

        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class").HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(70).IsUnicode(true).HasColumnType("nvarchar");
        }
    }
}
