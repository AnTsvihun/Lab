using System;
using System.Collections.Generic;

public class FunctionCache<TKey, TResult>
{
    private readonly Dictionary<TKey, TResult> cache = new Dictionary<TKey, TResult>();
    private readonly Func<TKey, TResult> userFunction;

    public FunctionCache(Func<TKey, TResult> function)
    {
        userFunction = function ?? throw new ArgumentNullException(nameof(function));
    }

    public TResult GetResult(TKey key)
    {
        if (cache.TryGetValue(key, out var cachedResult))
        {
            Console.WriteLine($"Retrieving cached result for key: {key}");
            return cachedResult;
        }

        Console.WriteLine($"Executing user function for key: {key}");
        var result = userFunction(key);
        cache[key] = result;
        return result;
    }
}

class Program
{
    static void Main()
    {
        Func<string, int> stringLengthFunction = s => s.Length;

        FunctionCache<string, int> stringLengthCache = new FunctionCache<string, int>(stringLengthFunction);

        Console.WriteLine(stringLengthCache.GetResult("hello"));
        Console.WriteLine(stringLengthCache.GetResult("world"));
        Console.WriteLine(stringLengthCache.GetResult("hello")); // Should retrieve from cache
    }
}
