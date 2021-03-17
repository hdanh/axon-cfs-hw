using System;
using System.Collections.Generic;

namespace AxonCFS.Domain.Models
{
    public class Event : BaseEntity<Guid>
    {
        public string Number { get; set; }
        public int TypeId { get; set; }
        public virtual EventType Type { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime DispatchTime { get; set; }
        public Guid ResponderId { get; set; }
        public virtual Responder Responder { get; set; }
    }
}