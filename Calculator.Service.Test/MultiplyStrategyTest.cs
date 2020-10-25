using NUnit.Framework;
using Calculator.Service.Strategies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Service.Test
{
    [TestFixture]
    public class MultiplyStrategyTest
    {
        [Test]
        public void MultiplyStrategy_Compute_HandlesEmptyInput()
        {
            MultiplyStrategy strategy = new MultiplyStrategy();
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(MockInputs.EmptyList));
        }

        [Test]
        public void MultiplyStrategy_Compute_HandlesNullInput()
        {
            MultiplyStrategy strategy = new MultiplyStrategy();
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(MockInputs.NullList));
        }

        [Test]
        public async Task MultiplyStrategy_Compute_ReturnsCorrectResult()
        {
            MultiplyStrategy strategy = new MultiplyStrategy();
            List<double> inputs = new List<double> { 3, 4.2, 6 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(75.6, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public void MultiplyStrategy_Compute_HandlesDoubleMaxValues()
        {
            MultiplyStrategy strategy = new MultiplyStrategy();
            List<double> inputs = new List<double> { -double.MaxValue, double.MaxValue };
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(inputs));
        }

        [Test]
        public async Task MultiplyStrategy_Compute_HandlesAllPositiveValues()
        {
            MultiplyStrategy strategy = new MultiplyStrategy();
            List<double> inputs = new List<double> { 1, 2, 3, 4, 5 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(120, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public async Task MultiplyStrategy_Compute_HandlesNegativeValues()
        {
            MultiplyStrategy strategy = new MultiplyStrategy();
            List<double> inputs = new List<double> { -1, 2, -4, 1, 7, 8, 12, 5730203 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(30805571328, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public async Task MultiplyStrategy_Compute_HandlesZero()
        {
            MultiplyStrategy strategy = new MultiplyStrategy();
            List<double> inputs = new List<double> { -1, 2, -4, 1, 7, 0, 8, 12, 5730203 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(0, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }
    }
}
