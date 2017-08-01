using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPoc.Model
{
    public class CalculatorRequest
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public string Operation { get; set; }
        public string Expression { get; set; }
    }
}
