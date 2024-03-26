namespace Moq.App
{
    public class Calculator
    {
        private readonly ICalculatorService _calculatorService;

        public Calculator(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public int Sum(int a, int b)
        {
            return _calculatorService.Sum(a, b);
        }

        public int Multiply(int a, int b)
        {
            return _calculatorService.Multiply(a, b);
        }
    }
}
