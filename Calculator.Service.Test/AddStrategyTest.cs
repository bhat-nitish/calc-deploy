using Calculator.Service.Strategies;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Service.Test
{
    [TestFixture]
    public class AddStrategyTest
    {
        [Test]
        public void AddStrategy_Compute_HandlesEmptyInput()
        {
            AddStrategy strategy = new AddStrategy();
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(MockInputs.EmptyList));
        }

        [Test]
        public void AddStrategy_Compute_HandlesNullInput()
        {
            AddStrategy strategy = new AddStrategy();
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(MockInputs.NullList));
        }

        [Test]
        public async Task AddStrategy_Compute_ReturnsCorrectResult()
        {
            AddStrategy strategy = new AddStrategy();
            List<double> inputs = new List<double> { 3, 4.2, 6 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(13.2, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public void AddStrategy_Compute_HandlesDoubleMaxValues()
        {
            AddStrategy strategy = new AddStrategy();
            List<double> inputs = new List<double> { double.MaxValue, double.MaxValue };
            Assert.ThrowsAsync<CalculatorException>(() => strategy.Compute(inputs));
        }

        [Test]
        public async Task AddStrategy_Compute_HandlesAllNegativeValues()
        {
            AddStrategy strategy = new AddStrategy();
            List<double> inputs = new List<double> { -1, -2, -3, -4, -5 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(-15, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public async Task AddStrategy_Compute_HandlesNegativeValues()
        {
            AddStrategy strategy = new AddStrategy();
            List<double> inputs = new List<double> { -1, 2, -4, 1, 7, 0, 8, 0, 12, 5730203 };
            var result = await strategy.Compute(inputs);
            Assert.AreEqual(5730228, result, 0.00000001); // The tolerance delta used here is due to the fact that double is used instead of decimal for speed
        }

        [Test]
        public void AddStrategy_Compute_HandlesDoubleMaxValuesWithZero()
        {
            AddStrategy strategy = new AddStrategy();
            List<double> inputs = new List<double> { 0, double.MaxValue };
            Assert.DoesNotThrowAsync(() => strategy.Compute(inputs), Resources.ListOutOfRange);
        }
    }
}
