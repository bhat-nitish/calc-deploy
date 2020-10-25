using Calculator.Service.Strategies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Service.Resolver
{
    public class ComputeResolver : IComputeResolver
    {
        private ICompute _computeStrategy;

        /// <summary>
        /// The SetComputeStrategy function is responsible for identifying the selected strategy and invoking the compute of the selected strategy
        /// </summary>
        /// <param name="computeStrategy">The compute strategy to be used - Add, Subtract, Multiple and Divide are available strategies</param>
        public void SetComputeStrategy(ICompute computeStrategy)
        {
            _computeStrategy = computeStrategy;
        }

        /// <summary>
        /// Return the result based on the compute function of the strategy selected
        /// </summary>
        /// <param name="inputs">list of inputs of double type</param>
        /// <returns>result in double</returns>
        public async Task<double> Compute(List<double> inputs)
        {
            return await _computeStrategy.Compute(inputs);
        }
    }
}
