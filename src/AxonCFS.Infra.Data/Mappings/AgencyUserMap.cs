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

            builder.HasData(new List<AgencyUser>()
            {
                new AgencyUser()
                {
                    AgencyId = new Guid("EFF6A082-31E3-412B-B661-BD340EAB29B6"),
                    UserId = "1"
                },
                new AgencyUser()
                {
                    AgencyId = new Guid("4B63867C-E27C-41DA-9C06-5E10817C1266"),
                    UserId = "2"
                }
            });
        }
    }
}