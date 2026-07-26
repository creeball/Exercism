public static class Wordy
{
    public static int Answer(string question)
    {
        question = question.Trim();
        if (!question.StartsWith("What is ") || !question.EndsWith('?')) throw new ArgumentException();
        question = question[8..^1];
        var strings = question.Trim().Split(' ').ToList();
        if (strings.Count < 1 || !int.TryParse(strings[0], out int result)) throw new ArgumentException();
        for (int i = 1; i < strings.Count; i += 2)
        {
            if (strings[i] == "multiplied" || strings[i] == "divided")
            {
                if (i + 1 == strings.Count) throw new ArgumentException();
                strings[i] += $" {strings[i + 1]}";
                strings.RemoveAt(i + 1);
            }
            if (i + 1 == strings.Count || !int.TryParse(strings[i + 1], out var num)) throw new ArgumentException();
            result = strings[i] switch
            {
                "plus" => result + num,
                "minus" => result - num,
                "multiplied by" => result * num,
                "divided by" => result / num,
                _ => throw new ArgumentException()
            };
        }
        return result;
    }
}