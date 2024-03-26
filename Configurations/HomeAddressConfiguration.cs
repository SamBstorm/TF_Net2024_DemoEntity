using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Net2024_DemoEntity.Entities;

namespace TF_Net2024_DemoEntity.Configurations
{
    public class HomeAddressConfiguration : IEntityTypeConfiguration<HomeAddress>
    {
        public void Configure(EntityTypeBuilder<HomeAddress> builder)
        {
            builder.ToTable("HomeAddresses");

            builder.HasKey(h => h.HomeId);
            builder.Property(h => h.HomeId)
                .ValueGeneratedOnAdd();

            builder.Property(h => h.Street)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(h => h.City)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(h => h.Number)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(h => h.ZipCode)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(h => h.Country)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasMany(h => h.Habitants)
                .WithOne(p => p.Home)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
