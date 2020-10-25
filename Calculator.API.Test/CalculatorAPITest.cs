using Calculator.API.Services;
using Calculator.API.ViewModels.Response;
using Calculator.Service.Resolver;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Calculator.Service;
using System;

namespace Calculator.API.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task AddStrategy_Success_Handled()
        {
            List<double> inputs = new List<double> { 1, 2, 3 };
            CalculatorResponse expectedResponse = new CalculatorResponse();
            expectedResponse.SetResult(6, true, 200, new List<string>());
            var computeResolver = new Mock<IComputeResolver>();
            computeResolver.Setup(cr => cr.Compute(inputs)).ReturnsAsync(6);
            ICalculatorService calculator = new CalculatorService(computeResolver.Object);
            var result = await calculator.Add(inputs);
            expectedResponse.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task AddStrategy_Failure_Handled()
        {
            List<double> inputs = new List<double> { 1, 2, 3 };
            CalculatorResponse expectedResponse = new CalculatorResponse();
            expectedResponse.SetResult(double.NaN, false, 500, new List<string>() { Resources.GenericException});
            var computeResolver = new Mock<IComputeResolver>();
            computeResolver.Setup(cr => cr.Compute(inputs)).ThrowsAsync(new Exception(Resources.GenericException));
            ICalculatorService calculator = new CalculatorService(computeResolver.Object);
            var result = await calculator.Add(inputs);
            expectedResponse.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task MultiplyStrategy_Success_Handled()
        {
            List<double> inputs = new List<double> { 1, 2, 3 };
            CalculatorResponse expectedResponse = new CalculatorResponse();
            expectedResponse.SetResult(6, true, 200, new List<string>());
            var computeResolver = new Mock<IComputeResolver>();
            computeResolver.Setup(cr => cr.Compute(inputs)).ReturnsAsync(6);
            ICalculatorService calculator = new CalculatorService(computeResolver.Object);
            var result = await calculator.Add(inputs);
            expectedResponse.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task MultiplyStrategy_Failure_Handled()
        {
            List<double> inputs = new List<double> { 1, 2, 3 };
            CalculatorResponse expectedResponse = new CalculatorResponse();
            expectedResponse.SetResult(double.NaN, false, 500, new List<string>() { Resources.GenericException });
            var computeResolver = new Mock<IComputeResolver>();
            computeResolver.Setup(cr => cr.Compute(inputs)).ThrowsAsync(new Exception(Resources.GenericException));
            ICalculatorService calculator = new CalculatorService(computeResolver.Object);
            var result = await calculator.Add(inputs);
            expectedResponse.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task DivideStrategy_Success_Handled()
        {
            List<double> inputs = new List<double> { 1, 2, 3 };
            CalculatorResponse expectedResponse = new CalculatorResponse();
            expectedResponse.SetResult(0.16666, true, 200, new List<string>());
            var computeResolver = new Mock<IComputeResolver>();
            computeResolver.Setup(cr => cr.Compute(inputs)).ReturnsAsync(0.16666);
            ICalculatorService calculator = new CalculatorService(computeResolver.Object);
            var result = await calculator.Add(inputs);
            expectedResponse.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task DivideStrategy_Failure_Handled()
        {
            List<double> inputs = new List<double> { 1, 2, 3 };
            CalculatorResponse expectedResponse = new CalculatorResponse();
            expectedResponse.SetResult(double.NaN, false, 500, new List<string>() { Resources.GenericException });
            var computeResolver = new Mock<IComputeResolver>();
            computeResolver.Setup(cr => cr.Compute(inputs)).ThrowsAsync(new Exception(Resources.GenericException));
            ICalculatorService calculator = new CalculatorService(computeResolver.Object);
            var result = await calculator.Add(inputs);
            expectedResponse.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task SubtractStrategy_Success_Handled()
        {
            List<double> inputs = new List<double> { 1, 2, 3 };
            CalculatorResponse expectedResponse = new CalculatorResponse();
            expectedResponse.SetResult(-4, true, 200, new List<string>());
            var computeResolver = new Mock<IComputeResolver>();
            computeResolver.Setup(cr => cr.Compute(inputs)).ReturnsAsync(-4);
            ICalculatorService calculator = new CalculatorService(computeResolver.Object);
            var result = await calculator.Add(inputs);
            expectedResponse.Should().BeEquivalentTo(result);
        }

        [Test]
        public async Task SubtractStrategy_Failure_Handled()
        {
            List<double> inputs = new List<double> { 1, 2, 3 };
            CalculatorResponse expectedResponse = new CalculatorResponse();
            expectedResponse.SetResult(double.NaN, false, 500, new List<string>() { Resources.GenericException });
            var computeResolver = new Mock<IComputeResolver>();
            computeResolver.Setup(cr => cr.Compute(inputs)).ThrowsAsync(new Exception(Resources.GenericException));
            ICalculatorService calculator = new CalculatorService(computeResolver.Object);
            var result = await calculator.Add(inputs);
            expectedResponse.Should().BeEquivalentTo(result);
        }
    }
}
