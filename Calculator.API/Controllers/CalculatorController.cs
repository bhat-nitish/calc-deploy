using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.API.Services;
using Calculator.API.ViewModels;
using Calculator.API.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost("add")]
        public async Task<CalculatorResponse> Add([FromBody] CalculatorRequest request)
        {
            return await _calculatorService.Add(request.inputs);
        }

        [HttpPost("subtract")]
        public async Task<CalculatorResponse> Subtract([FromBody] CalculatorRequest request)
        {
            return await _calculatorService.Subtract(request.inputs);
        }

        [HttpPost("multiply")]
        public async Task<CalculatorResponse> Multiply([FromBody] CalculatorRequest request)
        {
            return await _calculatorService.Multiply(request.inputs);
        }

        [HttpPost("divide")]
        public async Task<CalculatorResponse> Divide([FromBody] CalculatorRequest request)
        {
            return await _calculatorService.Divide(request.inputs);
        }
    }
}
