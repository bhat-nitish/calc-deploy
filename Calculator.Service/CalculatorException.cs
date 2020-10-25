using System;

namespace Calculator.Service
{
    public class CalculatorException : Exception
    {
        public CalculatorException(string message)
       : base(message)
        {
        }
    }
}
