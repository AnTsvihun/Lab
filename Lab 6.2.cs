using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T>
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public List<T> Find(Func<T, bool> criteria)
    {
        return items.Where(criteria).ToList();
    }
}

class Program
{
    static void Main()
    {
        Repository<int> intRepository = new Repository<int>();
        intRepository.AddItem(1);
        intRepository.AddItem(2);
        intRepository.AddItem(3);

        var result = intRepository.Find(x => x > 1);
        Console.WriteLine(string.Join(", ", result));
    }
}
