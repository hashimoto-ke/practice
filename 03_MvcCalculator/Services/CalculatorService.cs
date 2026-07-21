namespace _03_MvcCalculator.Services;

public class CalculatorService : ICalculatorService
{
    public int Tashizan(int a, int b)
    {
        return a + b;
    }

    public int Hikizan(int a, int b)
    {
        return a - b;
    }
}
