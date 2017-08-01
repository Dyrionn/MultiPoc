using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPoc.RpcServer.RemoteMethods.Interface;

namespace MultiPoc.RpcServer.RemoteMethods.Implementation
{
    public class Calculator : ICalculator
    {
        public double Divide(double value, double factor)
        {
            return value / factor;
        }

        public double Multiply(double value, double factor)
        {
            return value * factor;
        }

        public double Subtract(double first, double second)
        {
            return first - second;
        }

        public double Sum(double x, double y)
        {
            return x + y;
        }
    }
}

