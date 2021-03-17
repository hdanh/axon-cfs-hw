using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxonCFS.Domain.Models
{
    public class EventType : BaseEntity<int>
    {
        public string Code { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}