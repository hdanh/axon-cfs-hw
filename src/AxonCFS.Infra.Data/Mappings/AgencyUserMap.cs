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
    public class AgencyUserMap : IEntityTypeConfiguration<AgencyUser>
    {
        public void Configure(EntityTypeBuilder<AgencyUser> builder)
        {
            builder.HasKey(x => new { x.AgencyId, x.UserId });
        }
    }
}