using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Device
    {
        public long DeviceId { get; set; }
        public string DeviceName { get; set; }
        public Home Home { get; set; }
        public long HomeId { get; set; }
        public DeviceType DeviceType { get; set; }
        public long DeviceTypeId { get; set; }

        
    }
}
