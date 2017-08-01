using MultiPoc.Model;
using MultiPoc.Service;
using Newtonsoft.Json;
using Xunit;

namespace MultiPoc.Tests
{

    public class ServiceRabbitRpcTest
    {

        [Fact(DisplayName = "CalculatorRequestSum_Success")]
        public void CalculatorRequestSum_Success() {

            //Arrange
            RabbitRpc rabbit = new RabbitRpc("");
            CalculatorRequest request = new CalculatorRequest();
            request.Expression = "2+5";

            string requestMessage = JsonConvert.SerializeObject(request);
            string expected = "7";
            //Act
            string actual = rabbit.Call(requestMessage);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
