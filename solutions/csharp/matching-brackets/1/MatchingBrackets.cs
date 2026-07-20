public static class MatchingBrackets
{
    private static readonly Dictionary<char, char> MatchedBracket = new ()
    {
        [')'] = '(',
        [']'] = '[',
        ['}'] = '{'
    };
    public static bool IsPaired(string input)
    { 
        Stack<char> stack = new();
        foreach (var c in input)
        {
            if (IsLeftBracket(c))
            {
                stack.Push(c);
            }
            else if (IsRightBracket(c))
            {
                if (stack.Count == 0) return false;
                if (MatchedBracket[c] != stack.Pop()) return false;
            }
        }
        return stack.Count == 0;
    }

    private static bool IsLeftBracket(char c)
    {
        return c is '(' or '[' or '{';
    }

    private static bool IsRightBracket(char c)
    {
        return c is ')' or ']' or '}';
    }
}