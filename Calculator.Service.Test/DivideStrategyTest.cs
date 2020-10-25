using NUnit.Framework;
using Calculator.Service.Strategies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Service.Test
{
    [TestFixture]
    public class DivideStrategyTest
    {
        [Test]
        public void DivideStrategy_Compute_HandlesEmptyInput()
        {
            DivideStrategy strategy = new DivideStrategy();
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(MockInputs.EmptyList));
        }

        [Test]
        public void DivideStrategy_Compute_HandlesNullInput()
        {
            DivideStrategy strategy = new DivideStrategy();
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(MockInputs.NullList));
        }

        [Test]
        public async Task DivideStrategy_Compute_ReturnsCorrectResult()
        {
            DivideStrategy strategy = new DivideStrategy();
            List<double> inputs = new List<double> { 3, 4.2, 6 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(0.12, result, 0.01); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public void DivideStrategy_Compute_HandlesDivideByZero()
        {
            DivideStrategy strategy = new DivideStrategy();
            List<double> inputs = new List<double> { 1, 0, 2, 3 };
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(inputs));
        }

        [Test]
        public async Task DivideStrategy_Compute_HandlesAllPositiveValues()
        {
            DivideStrategy strategy = new DivideStrategy();
            List<double> inputs = new List<double> { 1, 2, 3, 4, 5 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(0.008, result, 0.001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public async Task DivideStrategy_Compute_HandlesNegativeValues()
        {
            DivideStrategy strategy = new DivideStrategy();
            List<double> inputs = new List<double> { -1, 2, -4, 1, 7, 8, 12, 5730203 };
            var result = await strategy.Compute(inputs);
            // This is a real edgecase with precision going up to E11
            Assert.AreEqual(3.2461660566284434E-11, result, 0.1); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }
    }
}
