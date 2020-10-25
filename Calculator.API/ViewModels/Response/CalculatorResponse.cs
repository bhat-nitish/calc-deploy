using Calculator.API.ViewModels.Dto;
using System.Collections.Generic;

namespace Calculator.API.ViewModels.Response
{
    public class CalculatorResponse : BaseResponse
    {
        public CalculatorResultDto ComputeResult { get; private set; }

        public CalculatorResponse()
        {
            ComputeResult = new CalculatorResultDto();
        }

        public void SetResult(double result, bool success, int statusCode, List<string> errors)
        {
            ComputeResult.Result = result;
            SetBaseResponseData(success, statusCode, errors);
        }
    }
}
