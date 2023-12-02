using System;
using System.Linq;

class MathOperations
{
    public static T Add<T>(T a, T b)
    {
        dynamic dynamicA = a;
        dynamic dynamicB = b;
        return dynamicA + dynamicB;
    }

    // Implement other overloaded methods for subtraction, multiplication, etc.

    public static T[] AddArrays<T>(T[] array1, T[] array2)
    {
        if (array1.Length != array2.Length)
        {
            throw new ArgumentException("Arrays must have the same length.");
        }

        return array1.Select((x, i) => Add(x, array2[i])).ToArray();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(MathOperations.Add(5, 3));
        Console.WriteLine(MathOperations.Add(5.5, 3.7));

        int[] array1 = { 1, 2, 3 };
        int[] array2 = { 4, 5, 6 };
        var resultArray = MathOperations.AddArrays(array1, array2);
        Console.WriteLine(string.Join(", ", resultArray));
    }
}
