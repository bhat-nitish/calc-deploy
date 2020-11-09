using Calculator.Service.Strategies;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Service.Test
{
    [TestFixture]
    public class SubtractStrategyTest
    {

        [Test]
        public void SubtractStrategy_Compute_HandlesEmptyInput()
        {
            SubtractStrategy strategy = new SubtractStrategy();
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(MockInputs.EmptyList));
        }

        [Test]
        public void SubtractStrategy_Compute_HandlesNullInput()
        {
            SubtractStrategy strategy = new SubtractStrategy();
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(MockInputs.NullList));
        }

        [Test]
        public async Task SubtractStrategy_Compute_ReturnsCorrectResult()
        {
            SubtractStrategy strategy = new SubtractStrategy();
            List<double> inputs = new List<double> { 3, 4.2, 6 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(-7.2, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public void SubtractStrategy_Compute_HandlesDoubleMaxValues()
        {
            SubtractStrategy strategy = new SubtractStrategy();
            List<double> inputs = new List<double> { -double.MaxValue, double.MaxValue };
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(inputs));
        }

        [Test]
        public async Task SubtractStrategy_Compute_HandlesAllPositiveValues()
        {
            SubtractStrategy strategy = new SubtractStrategy();
            List<double> inputs = new List<double> { 1, 2, 3, 4, 5 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(-13, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public async Task SubtractStrategy_Compute_HandlesPositiveValues()
        {
            SubtractStrategy strategy = new SubtractStrategy();
            List<double> inputs = new List<double> { -1, 2, -4, 1, 7, 0, 8, 0, 12, 5730203 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(-5730228, result, 0.0001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public void SubtractStrategy_Compute_HandlesDoubleMaxValuesWithZero()
        {
            SubtractStrategy strategy = new SubtractStrategy();
            List<double> inputs = new List<double> { 0, double.MaxValue };
            Assert.DoesNotThrowAsync(() => strategy.Compute(inputs), Resources.ListOutOfRange);
        }
    }
}
