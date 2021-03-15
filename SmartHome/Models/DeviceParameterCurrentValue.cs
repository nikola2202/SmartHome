using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceParameterCurrentValue
    {
        public long Id { get; set; }
        public StringParameter StringParameter { get; set; }
        public long StringParameterId { get; set; }
        public NumberParameter NumberParameter { get; set; }
        public long NumberParameterId { get; set; }
    }
}
