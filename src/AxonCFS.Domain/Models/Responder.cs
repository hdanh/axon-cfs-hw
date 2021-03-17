using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxonCFS.Domain.Models
{
    public class Responder : BaseEntity<string>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}