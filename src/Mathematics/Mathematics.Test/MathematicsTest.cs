namespace Mathematics.Test
{
    public class MathematicsTest
    {
        public App.Mathematics _mathematics;

        public MathematicsTest()
        {
            _mathematics = new App.Mathematics();
        }

        [Fact]
        public void SumTest()
        {
            #region Arrange
            // kaynaklar hazýrlanýyor

            int number1 = 10;
            int number2 = 20;
            int excepted = 30;

            #endregion

            #region Act

            int result = _mathematics.Sum(number1, number2);

            #endregion

            #region Assert

            Assert.Equal(excepted, result);

            #endregion
        }

        [Theory]
        [InlineData(5, 2, 3)]
        public void Subtract_SimpleValues_ReturnValue(int number1, int number2, int expected)
        {
            var result = _mathematics.Subtract(number1, number2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 0, 0)]
        public void Multiply_ZeroValues_ReturnZero(int number1, int number2, int expected)
        {
            var result = _mathematics.Multiply(number1, number2);
            Assert.Equal(expected, result);
        }
    }
}