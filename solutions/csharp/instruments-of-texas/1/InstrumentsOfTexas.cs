public class CalculationException(int operand1, int operand2, string message, Exception inner)
    : Exception(message, inner)
{
    public int Operand1 { get; } = operand1;
    public int Operand2 { get; } = operand2;
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (CalculationException e) when (e.Operand1 < 0 && e.Operand2 < 0)
        {
            return "Multiply failed for negative operands. " + e.Message;
        }
        catch (CalculationException e) when (e.Operand1 > 0 || e.Operand2 > 0)
        {
            return "Multiply failed for mixed or positive operands. " + e.Message;
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException e)
        {
            throw new CalculationException(x, y, e.Message, e);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}