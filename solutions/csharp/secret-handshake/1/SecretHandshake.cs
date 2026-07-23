public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        List<string> actions = new();
        for (int i = 0; i < 5; i++)
        {
            if ((commandValue & 1 << i) != 0)
            {
                switch (i)
                {
                    case 0:
                        actions.Add("wink");
                        break;
                    case 1:
                        actions.Add("double blink");
                        break;
                    case 2:
                        actions.Add("close your eyes");
                        break;
                    case 3:
                        actions.Add("jump");
                        break;
                    case 4:
                        actions.Reverse();
                        break;
                }
            }
        }
        return actions.ToArray();
    }
}