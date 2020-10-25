using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Service.Strategies
{
    public class MultiplyStrategy : ICompute
    {
        public async Task<double> Compute(List<double> inputs)
        {
            try
            {
                if (inputs == null || inputs.Count == 0)
                    throw new InvalidOperationException(Resources.ListEmpty);
                if (inputs.Contains(0))
                    return 0;
                double product = inputs.AsParallel().Aggregate((a, b) => a * b);
                bool isInfinity = double.IsInfinity(product);
                if (isInfinity)
                    throw new ArgumentOutOfRangeException(Resources.ListOutOfRange);
                return product;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException || ex is InvalidOperationException)
                {
                    throw new CalculatorException(ex.Message);
                }

                throw ex; // throw can be better if stack trace needs to be preserved
            }
        }
    }
}
