using Moq.App;

namespace Moq.Test
{
    public class CalculatorTest
    {
        private Mock<ICalculatorService> _calculatorService;
        private Calculator _calculator;
        public CalculatorTest()
        {
            _calculatorService = new Mock<ICalculatorService>();
            _calculator = new Calculator(_calculatorService.Object);
        }

        [Theory]
        [InlineData(2, 5, 7)]
        public void Sum_SimpleValues_ReturnTotal(int a, int b, int expected)
        {
            _calculatorService.Setup(x => x.Sum(a, b)).Returns(expected);

            var result = _calculator.Sum(a, b);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 5, 15)]
        public void Multiply_SimpleValues_ReturnMultiplyValue(int a, int b, int expected)
        {
            _calculatorService.Setup(x => x.Multiply(a, b)).Returns(expected);

            Assert.Equal(expected, _calculator.Multiply(a, b));

            _calculatorService.Verify(x => x.Multiply(a, b), Times.Once);
            _calculatorService.Verify(x => x.Sum(a, b), Times.Never);
        }

        [Theory]
        [InlineData(0, 5)]
        public void Multiply_ZeroValues_ReturnException(int a, int b)
        {
            _calculatorService.Setup(x => x.Multiply(a, b)).Throws(new Exception("a'nýn deðeri 0 olamaz!"));
            Exception exception = Assert.Throws<Exception>(() => _calculator.Multiply(a, b));
            Assert.Equal("a'nýn deðeri 0 olamaz!", exception.Message);
        }

        [Theory]
        [InlineData(3, 5, 15)]
        public void Multiply_SimpleValuesWithItIsAny_ReturnMultipleValue(int a, int b, int expected)
        {
            int actualMultip = 0;

            _calculatorService.Setup(x => x.Multiply(It.IsAny<int>(), It.IsAny<int>())).Callback<int, int>((x, y) => actualMultip = x * y);

            _calculator.Multiply(a, b);

            Assert.Equal(expected, actualMultip);

            _calculator.Multiply(2, 50);

            Assert.Equal(100, actualMultip);
        }
    }
}