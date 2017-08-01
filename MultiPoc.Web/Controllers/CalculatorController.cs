using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MultiPoc.Business;
using MultiPoc.Model;

namespace MultiPoc.Web.Controllers
{
    [RoutePrefix("Calculator")]
    public class CalculatorController : ApiController
    {
        private CalculatorBusiness calculatorBusiness;

        public CalculatorController()
        {
            calculatorBusiness = new CalculatorBusiness();
        }

        [HttpPost]
        [Route("calc")]
        public HttpResponseMessage Calcula(CalculatorRequest calculate)
        {
            var response = calculatorBusiness.Calculate(calculate);

            return Request.CreateResponse(
                String.IsNullOrEmpty(response) ? HttpStatusCode.OK : HttpStatusCode.ExpectationFailed,
                response);
        }
    }
}
