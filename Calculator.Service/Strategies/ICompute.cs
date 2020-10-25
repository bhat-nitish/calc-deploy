using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Service.Strategies
{
    public interface ICompute
    {
        Task<double> Compute(List<double> inputs);
    }
}
