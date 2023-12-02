using System;

// Common interface for all graphs
public interface IGraph
{
    void Draw();
}

// Concrete implementation of a Line Graph
public class LineGraph : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Line Graph");
    }
}

// Concrete implementation of a Bar Chart
public class BarChart : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Bar Chart");
    }
}

// Concrete implementation of a Pie Chart
public class PieChart : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
    }
}

// Factory interface
public interface IGraphFactory
{
    IGraph CreateGraph();
}

// Concrete factory for Line Graph
public class LineGraphFactory : IGraphFactory
{
    public IGraph CreateGraph()
    {
        return new LineGraph();
    }
}

// Concrete factory for Bar Chart
public class BarChartFactory : IGraphFactory
{
    public IGraph CreateGraph()
    {
        return new BarChart();
    }
}

// Concrete factory for Pie Chart
public class PieChartFactory : IGraphFactory
{
    public IGraph CreateGraph()
    {
        return new PieChart();
    }
}

// GraphFactory that uses Factory Method
public class GraphFactory
{
    public IGraph CreateGraph(string graphType)
    {
        switch (graphType.ToLower())
        {
            case "line":
                return new LineGraphFactory().CreateGraph();
            case "bar":
                return new BarChartFactory().CreateGraph();
            case "pie":
                return new PieChartFactory().CreateGraph();
            default:
                throw new ArgumentException("Invalid graph type");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of graph (line, bar, pie):");
        string graphType = Console.ReadLine();

        GraphFactory graphFactory = new GraphFactory();
        IGraph graph = graphFactory.CreateGraph(graphType);

        graph.Draw();
    }
}
