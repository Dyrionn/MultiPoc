using MultiPoc.Model;
using MultiPoc.RpcServer.RemoteMethods.Implementation;

namespace MultiPoc.RpcServer.RemoteBusiness
{
    public class CalculatorRequestBusiness
    {
        public double? Calculate(CalculatorRequest request) {

            double? operationResult = null;
            var calMachine = new Calculator();

            if (request.Operation.ToLowerInvariant() == "+" || request.Operation.ToLowerInvariant() == "sum")
            {
                operationResult += calMachine.Sum(request.Value1, request.Value2);
            }
            else if (request.Operation.ToLowerInvariant() == "-" || request.Operation.ToLowerInvariant() == "subtract")
            {
                operationResult += calMachine.Subtract(request.Value1, request.Value2);
            }
            else if (request.Operation.ToLowerInvariant() == "*" || request.Operation.ToLowerInvariant() == "multiply")
            {
                operationResult += calMachine.Multiply(request.Value1, request.Value2);
            }
            else if (request.Operation.ToLowerInvariant() == "/" || request.Operation.ToLowerInvariant() == "divide")
            {
                operationResult += calMachine.Divide(request.Value1, request.Value2);
            }

            return operationResult;
        }
    }
}
