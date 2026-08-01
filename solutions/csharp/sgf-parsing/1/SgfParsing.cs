using System.Text.RegularExpressions;

public class SgfTree
{
    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }

    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }
}

public class SgfParser
{
    public static SgfTree ParseTree(string input)
    {
        if (!input.StartsWith("(;") || !input.EndsWith(')')) throw new ArgumentException();
        return Parse(input[2..^1]);
    }
    private static SgfTree Parse(string input)
    {
        var data = ParseProperties(ref input);
        List<SgfTree> children = [];
        while (input.Length > 0)
        {
            switch (input[0])
            {
                case '(':
                    children.Add(ParseTree(ExtractTree(ref input)));
                    break;
                case ';':
                    children.Add(Parse(ExtractNode(ref input)));
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        return new SgfTree(data, children.ToArray());
    }
    
    private static Dictionary<string, string[]> ParseProperties(ref string input)
    {
        Dictionary<string, string[]> data = [];
        while (true)
        {
            var keyMatch = Regex.Match(input, @"^([A-Z]+)");
            if (!keyMatch.Success) break;
            string key = keyMatch.Groups[1].Value;
            input = input[key.Length..];
            List<string> values = [];
            while (true)
            {
                var valueMatch = Regex.Match(input, @"^\[(.*?)\]");
                if (!valueMatch.Success) break;
                values.Add(valueMatch.Groups[1].Value);
                input = input[valueMatch.Length..];
            }
            if (values.Count == 0) throw new ArgumentException();
            data.Add(key, values.ToArray());
        }
        return data;
    }

    private static string ExtractTree(ref string input)
    {
        int depth = 0;
        bool inValue = false;
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '[':
                    inValue = true;
                    break;
                case ']':
                    inValue = false;
                    break;
                case '(' when !inValue:
                    depth++;
                    break;
                case ')' when !inValue:
                    depth--;
                    if (depth == 0)
                    {
                        string tree = input[..(i + 1)];
                        input = input[(i + 1)..];
                        return tree;
                    }
                    break;
            }
        }
        throw new ArgumentException();
    }
    
    private static string ExtractNode(ref string input)
    {
        bool inValue = false;
        for (int i = 1; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '[':
                    inValue = true;
                    break;
                case ']':
                    inValue = false;
                    break;
                case ';' or '(' when !inValue:
                {
                    string node = input[1..i];
                    input = input[i..];
                    return node;
                }
            }
        }
        string lastNode = input[1..];
        input = string.Empty;
        return lastNode;
    }
}