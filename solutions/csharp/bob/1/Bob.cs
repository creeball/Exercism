public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();
        if (string.IsNullOrEmpty(statement))
            return "Fine. Be that way!";
        bool isQuestion = statement.EndsWith('?');
        bool hasLowerChar = false;
        bool hasUpperChar = false;
        foreach (var c in statement)
        {
            if (char.IsUpper(c))
                hasUpperChar = true;
            else if (char.IsLower(c))
                hasLowerChar = true;
            if (hasLowerChar && hasUpperChar)
                break;
        }
        bool isShooting = !hasLowerChar && hasUpperChar;
        if (isQuestion)
            return isShooting ? "Calm down, I know what I'm doing!" : "Sure.";
        return isShooting ? "Whoa, chill out!" : "Whatever.";
    }
}