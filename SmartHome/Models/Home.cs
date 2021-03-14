using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Home
    {

        public long HomeId { get; set; }
        public string Adress { get; set; }
        public IList<UserHome> UserHomes { get; set; }
        public IList<Device> Devices { get; set; }
    }
}
