using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxonCFS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AxonCFS.Infra.Data.Mappings
{
    public class AgencyMap : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.AgencyUsers)
                .WithOne(x => x.Agency)
                .HasForeignKey(x => x.AgencyId);

            builder.HasMany(x => x.Responders)
                .WithOne(x => x.Agency)
                .HasForeignKey(x => x.AgencyId);

            builder.HasMany(x => x.Events)
                .WithOne(x => x.Agency)
                .HasForeignKey(x => x.AgencyId);
        }
    }
}