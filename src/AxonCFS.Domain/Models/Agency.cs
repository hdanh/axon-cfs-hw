using System;
using System.Collections.Generic;

namespace AxonCFS.Domain.Models
{
    public class Agency : BaseEntity<Guid>
    {
        public string Code { get; set; }

        public virtual List<Responder> Responders { get; set; }
        public virtual List<AgencyUser> AgencyUsers { get; set; }
    }
}