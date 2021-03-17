using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxonCFS.Domain.Models
{
    public class AgencyUser
    {
        public Guid AgencyId { get; set; }
        public Agency Agency { get; set; }

        public string UserId { get; set; }
    }
}