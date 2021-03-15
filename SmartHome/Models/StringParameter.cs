using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class StringParameter
    {
        public long StringParameterId { get; set; }
        public string StringParameterName { get; set; }
        public bool StringParameterValue { get; set; }
        public DeviceParameterCurrentValue DeviceParameterCurrentValue { get; set; }
        //public long DeviceParameterCurrentValueId { get; set; }
    }
}
