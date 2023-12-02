using System;

public class Calculator<T>
{
    public delegate T ArithmeticOperation(T a, T b);

    public ArithmeticOperation Add { get; set; }
    public ArithmeticOperation Subtract { get; set; }
    public ArithmeticOperation Multiply { get; set; }
    public ArithmeticOperation Divide { get; set; }

    public Calculator()
    {
        // Initialize operations for numeric types
        Add = (a, b) => (dynamic)a + b;
        Subtract = (a, b) => (dynamic)a - b;
        Multiply = (a, b) => (dynamic)a * b;
        Divide = (a, b) => (dynamic)a / b;
    }

    public T PerformOperation(ArithmeticOperation operation, T a, T b)
    {
        return operation(a, b);
    }
}

class Program
{
    static void Main()
    {
        Calculator<int> intCalculator = new Calculator<int>();
        Console.WriteLine($"Add: {intCalculator.PerformOperation(intCalculator.Add, 5, 3)}");

        Calculator<double> doubleCalculator = new Calculator<double>();
        Console.WriteLine($"Multiply: {doubleCalculator.PerformOperation(doubleCalculator.Multiply, 2.5, 4.0)}");
    }
}
