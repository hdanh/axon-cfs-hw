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
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Type)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.TypeId);

            builder.HasOne(x => x.Responder)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.ResponderId);

            builder.HasOne(x => x.Agency)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.AgencyId);
        }
    }
}