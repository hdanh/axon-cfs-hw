using AxonCFS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AxonCFS.Infra.Data.Mappings
{
    public class ResponderMap : IEntityTypeConfiguration<Responder>
    {
        public void Configure(EntityTypeBuilder<Responder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasValueGenerator<GuidValueGenerator>();
        }
    }
}