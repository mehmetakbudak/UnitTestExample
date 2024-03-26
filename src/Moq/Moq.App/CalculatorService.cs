namespace Moq.App
{
    public class CalculatorService : ICalculatorService
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            if (a == 0)
            {
                throw new Exception("a'nın değeri 0 olamaz!");
            }

            return a * b;
        }

    }
}
