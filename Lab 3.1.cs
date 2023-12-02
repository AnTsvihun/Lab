using System;

class LivingOrganism
{
    public double Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }
}

interface IReproducible
{
    void Reproduce();
}

interface IPredator
{
    void Hunt(LivingOrganism target);
}

class Animal : LivingOrganism, IReproducible, IPredator
{
    public string Species { get; set; }

    public void Reproduce()
    {
        Console.WriteLine($"Animal of species {Species} is reproducing.");
    }

    public void Hunt(LivingOrganism target)
    {
        Console.WriteLine($"Animal of species {Species} is hunting.");
        // Logic for hunting and consuming energy
    }
}

class Plant : LivingOrganism, IReproducible
{
    public string Type { get; set; }

    public void Reproduce()
    {
        Console.WriteLine($"Plant of type {Type} is reproducing.");
    }
}

class Microorganism : LivingOrganism, IReproducible
{
    public string Strain { get; set; }

    public void Reproduce()
    {
        Console.WriteLine($"Microorganism of strain {Strain} is reproducing.");
    }
}

class Ecosystem
{
    public void Interact(LivingOrganism organism1, LivingOrganism organism2)
    {
        // Logic for interaction between organisms (e.g., competition, cooperation)
    }
}

class Program
{
    static void Main()
    {
        Animal lion = new Animal { Species = "Lion", Energy = 100, Age = 5, Size = 2.5 };
        Plant oakTree = new Plant { Type = "Oak Tree", Energy = 50, Age = 10, Size = 10.0 };

        Ecosystem ecosystem = new Ecosystem();
        ecosystem.Interact(lion, oakTree);

        lion.Hunt(oakTree);
        lion.Reproduce();
        oakTree.Reproduce();
    }
}
