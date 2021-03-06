using AxonCFS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AxonCFS.Infra.Data.Mappings
{
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasValueGenerator<GuidValueGenerator>();

            builder.HasOne(x => x.Type)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.TypeId);

            builder.HasOne(x => x.Responder)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.ResponderId);
        }
    }
}