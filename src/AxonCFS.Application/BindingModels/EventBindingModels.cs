using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxonCFS.Application.BindingModels
{
    public class PostEventBindingModel
    {
        public string EventNumber { get; set; }
        public string EventCode { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime DispatchTime { get; set; }
        public string Responder { get; set; }
    }
}