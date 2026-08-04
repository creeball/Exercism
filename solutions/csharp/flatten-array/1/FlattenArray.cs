using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var obj in input)
        {
            if (obj is IEnumerable enumerable)
                foreach (var item in Flatten(enumerable)) yield return item;
            else if (obj != null) yield return obj;
        }
    }
}