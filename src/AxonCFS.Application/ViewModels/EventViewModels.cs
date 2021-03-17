using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxonCFS.Application.ViewModels
{
    public class SearchEventViewModel
    {
        public List<EventViewModel> Events { get; set; }
        public int Total { get; set; }
    }

    public class EventViewModel
    {
        public string AgencyId { get; set; }
        public string EventId { get; set; }
        public string EventNumber { get; set; }
        public string EventTypeCode { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime DispatchTime { get; set; }
        public string Responder { get; set; }
    }
}