using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class DeviceType
    {
        public long DeviceTypeId { get; set; }
        public string DeviceTypeName { get; set; }
        public IList<Device> Devices { get; set; }
    }
}
