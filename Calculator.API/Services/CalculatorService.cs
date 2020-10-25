using Calculator.API.ViewModels.Response;
using Calculator.Service;
using Calculator.Service.Resolver;
using Calculator.Service.Strategies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.API.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IComputeResolver _computeResolver;

        public CalculatorService(IComputeResolver computeResolver)
        {
            _computeResolver = computeResolver;
        }

        public async Task<CalculatorResponse> Add(List<double> inputs)
        {
            CalculatorResponse response = new CalculatorResponse();
            try
            {
                _computeResolver.SetComputeStrategy(new AddStrategy());
                double result = await _computeResolver.Compute(inputs);
                response.SetResult(result, true, 200, new List<string>());
            }
            catch (CalculatorException ex)
            {
                // the response code is 200 as this is a handled operation even if there was an exception
                response.SetResult(double.NaN, false, 200, new List<string>(new string[] { ex.Message }));
            }
            catch
            {
                // the response code is 500 as this is an unhandled exception which is generic
                response.SetResult(double.NaN, false, 500, new List<string>(new string[] { Resources.GenericException }));
            }
            return response;
        }

        public async Task<CalculatorResponse> Subtract(List<double> inputs)
        {
            CalculatorResponse response = new CalculatorResponse();
            try
            {
                _computeResolver.SetComputeStrategy(new SubtractStrategy());
                double result = await _computeResolver.Compute(inputs);
                response.SetResult(result, true, 200, new List<string>());
            }
            catch (CalculatorException ex)
            {
                // the response code is 200 as this is a handled operation even if there was an exception
                response.SetResult(double.NaN, false, 200, new List<string>(new string[] { ex.Message }));
            }
            catch
            {
                // the response code is 500 as this is an unhandled exception which is generic
                response.SetResult(double.NaN, false, 500, new List<string>(new string[] { Resources.GenericException }));
            }
            return response;
        }

        public async Task<CalculatorResponse> Multiply(List<double> inputs)
        {
            CalculatorResponse response = new CalculatorResponse();
            try
            {
                _computeResolver.SetComputeStrategy(new MultiplyStrategy());
                double result = await _computeResolver.Compute(inputs);
                response.SetResult(result, true, 200, new List<string>());
            }
            catch (CalculatorException ex)
            {
                // the response code is 200 as this is a handled operation even if there was an exception
                response.SetResult(double.NaN, false, 200, new List<string>(new string[] { ex.Message }));
            }
            catch
            {
                // the response code is 500 as this is an unhandled exception which is generic
                response.SetResult(double.NaN, false, 500, new List<string>(new string[] { Resources.GenericException }));
            }
            return response;
        }


        public async Task<CalculatorResponse> Divide(List<double> inputs)
        {
            CalculatorResponse response = new CalculatorResponse();
            try
            {
                _computeResolver.SetComputeStrategy(new DivideStrategy());
                double result = await _computeResolver.Compute(inputs);
                response.SetResult(result, true, 200, new List<string>());
            }
            catch (CalculatorException ex)
            {
                // the response code is 200 as this is a handled operation even if there was an exception
                response.SetResult(double.NaN, false, 200, new List<string>(new string[] { ex.Message }));
            }
            catch
            {
                // the response code is 500 as this is an unhandled exception which is generic
                response.SetResult(double.NaN, false, 500, new List<string>(new string[] { Resources.GenericException }));
            }
            return response;
        }
    }
}
