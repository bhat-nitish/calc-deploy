using Calculator.Service.Strategies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Service.Resolver
{
    public interface IComputeResolver
    {
        void SetComputeStrategy(ICompute computeStrategy);

        Task<double> Compute(List<double> inputs);
    }
}
