using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPoc.Model;
using MultiPoc.Service;
using Newtonsoft.Json;

namespace MultiPoc.Business
{
    public class CalculatorBusiness
    {
        RabbitRpc rabbit;
        public CalculatorBusiness()
        {
            this.rabbit = new RabbitRpc("");
        }

        public string Calculate(CalculatorRequest calc) {

            string requestMessage = JsonConvert.SerializeObject(calc);

            return rabbit.Call(requestMessage);
        }

    }
}
