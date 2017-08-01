using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPoc.RpcServer.RemoteMethods.Interface
{
    public interface ICalculator
    {
        double Sum(double x, double y);
        double Subtract(double first, double second);
        double Multiply(double value, double factor);
        double Divide(double value, double factor);
    }
}
