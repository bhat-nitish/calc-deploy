using Calculator.API.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.API.Services
{
    public interface ICalculatorService
    {
        Task<CalculatorResponse> Add(List<double> inputs);

        Task<CalculatorResponse> Subtract(List<double> inputs);

        Task<CalculatorResponse> Multiply(List<double> inputs);

        Task<CalculatorResponse> Divide(List<double> inputs);
    }
}
