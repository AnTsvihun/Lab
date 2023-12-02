using System;
using System.Collections.Generic;
using System.Linq;

abstract class Vehicle
{
    public double Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

class Human
{
    public double Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is walking.");
    }
}

class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Car is driving.");
    }
}

class Bus : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Bus is moving.");
    }
}

class Train : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Train is moving on tracks.");
    }
}

class TransportNetwork
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void ControlMovement()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

    public void CalculateOptimalRoute(Route route, Vehicle vehicle)
    {
        // Logic to calculate the optimal route based on the type of vehicle
        Console.WriteLine($"Optimal route calculated for {vehicle.GetType().Name} on route from {route.StartPoint} to {route.EndPoint}.");
    }
}

class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
}

class Program
{
    static void Main()
    {
        TransportNetwork transportNetwork = new TransportNetwork();

        Car car = new Car { Speed = 60, Capacity = 4 };
        Bus bus = new Bus { Speed = 40, Capacity = 30 };
        Train train = new Train { Speed = 100, Capacity = 200 };

        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        transportNetwork.ControlMovement();

        Route route = new Route { StartPoint = "A", EndPoint = "B" };
        transportNetwork.CalculateOptimalRoute(route, car);
    }
}
