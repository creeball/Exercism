using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        var count = 0;

        foreach (var item in input)
            count++;
            
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        var output = new List<T>(input.Count);
        
        for (int i = input.Count - 1; i >= 0; i--)
            output.Add(input[i]);

        return output;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        var output = new List<TOut>(input.Count);

        foreach (var item in input)
            output.Add(map(item));

        return output;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        var output = new List<T>(input.Count);

        foreach (var item in input)
            if (predicate(item))
                output.Add(item);

        return output;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        var result = start;

        foreach (var item in input)
            result = func(result, item);

        return result;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {        
        var result = start;

        for (int i = input.Count - 1; i >= 0; i--)
            result = func(input[i], result);

        return result;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var output = new List<T>();

        foreach (var list in input)
            foreach (var item in list)
                output.Add(item);

        return output;
    }

    public static List<T> Append<T>(List<T> left, List<T> right) =>
        Concat(new List<List<T>> { left, right });
}