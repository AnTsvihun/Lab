using System;

class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OS { get; set; }
}

interface IConnectable
{
    void Connect(Computer target);
    void Disconnect(Computer target);
    void TransferData(Computer target, string data);
}

class Server : Computer, IConnectable
{
    public int StorageCapacity { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Server {IPAddress} is connecting to {target.IPAddress}.");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Server {IPAddress} is disconnecting from {target.IPAddress}.");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Server {IPAddress} is transferring data to {target.IPAddress}: {data}");
    }
}

class Workstation : Computer, IConnectable
{
    public string Department { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Workstation {IPAddress} is connecting to {target.IPAddress}.");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Workstation {IPAddress} is disconnecting from {target.IPAddress}.");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Workstation {IPAddress} is transferring data to {target.IPAddress}: {data}");
    }
}

class Router : Computer, IConnectable
{
    public int Range { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Router {IPAddress} is connecting to {target.IPAddress}.");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Router {IPAddress} is disconnecting from {target.IPAddress}.");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Router {IPAddress} is transferring data to {target.IPAddress}: {data}");
    }
}

class Network
{
    public void SimulateConnection(IConnectable device1, IConnectable device2)
    {
        device1.Connect((Computer)device2);
        device1.TransferData((Computer)device2, "Sample data");
        device1.Disconnect((Computer)device2);
    }
}

class Program
{
    static void Main()
    {
        Server server = new Server { IPAddress = "192.168.1.1", Power = 1000, OS = "Windows", StorageCapacity = 500 };
        Workstation workstation = new Workstation { IPAddress = "192.168.1.2", Power = 500, OS = "Linux", Department = "IT" };
        Router router = new Router { IPAddress = "192.168.1.254", Power = 200, OS = "RouterOS", Range = 50 };

        Network network = new Network();
        network.SimulateConnection(server, workstation);
        network.SimulateConnection(workstation, router);
    }
}
