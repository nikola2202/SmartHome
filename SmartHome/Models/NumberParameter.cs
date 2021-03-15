using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class NumberParameter
    {
        public long NumberParameterId { get; set; }
        public string Name { get; set; }
        public long MaxValue { get; set; }
        public long MinValue { get; set; }
        public long DefaultValue { get; set; }
        public IList<NumberParameter> NumberParameters { get; set; }


    }
}
