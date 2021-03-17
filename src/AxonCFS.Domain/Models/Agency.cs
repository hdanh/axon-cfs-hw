using System.Collections.Generic;

namespace AxonCFS.Domain.Models
{
    public class Agency : BaseEntity<string>
    {
        public string Code { get; set; }

        public virtual List<Event> Events { get; set; }
        public virtual List<Responder> Responders { get; set; }
        public virtual List<AgencyUser> AgencyUsers { get; set; }
    }
}