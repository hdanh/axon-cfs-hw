using System;
using System.Collections.Generic;
using AxonCFS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AxonCFS.Infra.Data.Mappings
{
    public class AgencyMap : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasValueGenerator<GuidValueGenerator>();

            builder.HasMany(x => x.AgencyUsers)
                .WithOne(x => x.Agency)
                .HasForeignKey(x => x.AgencyId);

            builder.HasMany(x => x.Responders)
                .WithOne(x => x.Agency)
                .HasForeignKey(x => x.AgencyId);

            builder.HasData(Agencies);
        }

        public static IEnumerable<Agency> Agencies => new List<Agency>()
        {
            new Agency()
            {
                Id = new Guid("EFF6A082-31E3-412B-B661-BD340EAB29B6"),
                Code = "Agency1"
            },
            new Agency()
            {
                Id = new Guid("4B63867C-E27C-41DA-9C06-5E10817C1266"),
                Code = "Agency2"
            }
        };
    }
}