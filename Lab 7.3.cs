using System;

// Abstract Product A
public interface IScreen
{
    void Display();
}

// Concrete Product A1
public class OLEDScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("Displaying on OLED Screen");
    }
}

// Concrete Product A2
public class LCDScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("Displaying on LCD Screen");
    }
}

// Abstract Product B
public interface IProcessor
{
    void Process();
}

// Concrete Product B1
public class SnapDragonProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Processing with SnapDragon Processor");
    }
}

// Concrete Product B2
public class A12BionicProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Processing with A12 Bionic Processor");
    }
}

// Abstract Factory
public interface ITechnologyFactory
{
    IScreen CreateScreen();
    IProcessor CreateProcessor();
}

// Concrete Factory 1
public class SamsungFactory : ITechnologyFactory
{
    public IScreen CreateScreen()
    {
        return new OLEDScreen();
    }

    public IProcessor CreateProcessor()
    {
        return new SnapDragonProcessor();
    }
}

// Concrete Factory 2
public class AppleFactory : ITechnologyFactory
{
    public IScreen CreateScreen()
    {
        return new LCDScreen();
    }

    public IProcessor CreateProcessor()
    {
        return new A12BionicProcessor();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of product (Samsung, Apple):");
        string productType = Console.ReadLine();

        ITechnologyFactory technologyFactory;
        if (productType.ToLower() == "samsung")
        {
            technologyFactory = new SamsungFactory();
        }
        else if (productType.ToLower() == "apple")
        {
            technologyFactory = new AppleFactory();
        }
        else
        {
            throw new ArgumentException("Invalid product type");
        }

        IScreen screen = technologyFactory.CreateScreen();
        IProcessor processor = technologyFactory.CreateProcessor();

        screen.Display();
        processor.Process();
    }
}
