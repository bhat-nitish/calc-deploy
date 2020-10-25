using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Service.Strategies
{
    public class DivideStrategy : ICompute
    {
        public async Task<double> Compute(List<double> inputs)
        {
            try
            {
                if (inputs==null || inputs.Count == 0)
                    throw new InvalidOperationException(Resources.ListEmpty);
                // for division, the as parallel needs to be ordered as division is order dependent
                double quotient = inputs.AsParallel().AsOrdered().Aggregate((a, b) => a / b);
                bool isInfinity = double.IsInfinity(quotient);
                if (isInfinity)
                    throw new ArgumentOutOfRangeException(Resources.ListOutOfRange);
                return quotient;
            }
            catch (Exception ex)
            {
                //since double is being used here , divide by zero exception is handled with isInfinity check
                // divide by zero is handled in double but not in int.
                if (ex is ArgumentOutOfRangeException || ex is InvalidOperationException)
                {
                    throw new CalculatorException(ex.Message);
                }

                throw ex; // throw can be better if stack trace needs to be preserved
            }
        }
    }
}
