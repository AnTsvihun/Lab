using System;

class Converter
{
    private double usd;
    private double eur;
    private double pln;

    public Converter(double usd, double eur, double pln)
    {
        this.usd = usd;
        this.eur = eur;
        this.pln = pln;
    }

    public double ConvertToUSD(double uah)
    {
        return uah / usd;
    }

    public double ConvertToEUR(double uah)
    {
        return uah / eur;
    }

    public double ConvertToPLN(double uah)
    {
        return uah / pln;
    }

    public double ConvertFromUSD(double amount)
    {
        return amount * usd;
    }

    public double ConvertFromEUR(double amount)
    {
        return amount * eur;
    }

    public double ConvertFromPLN(double amount)
    {
        return amount * pln;
    }
}

class Program
{
    static void Main()
    {
        Converter converter = new Converter(28.0, 33.5, 7.5);

        double amountInUAH = 1000.0;

        Console.WriteLine($"{amountInUAH} UAH is approximately:");
        Console.WriteLine($"{converter.ConvertToUSD(amountInUAH):0.00} USD");
        Console.WriteLine($"{converter.ConvertToEUR(amountInUAH):0.00} EUR");
        Console.WriteLine($"{converter.ConvertToPLN(amountInUAH):0.00} PLN");

        double amountInUSD = 50.0;
        Console.WriteLine($"{amountInUSD} USD is approximately {converter.ConvertFromUSD(amountInUSD):0.00} UAH");
    }
}
