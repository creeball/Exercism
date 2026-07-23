public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private readonly char[][] _map;
    private readonly string[] _students = ["Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"];
    public KindergartenGarden(string diagram)
    {
        var split = diagram.Split('\n');
        _map = [split[0].ToCharArray(), split[1].ToCharArray()];
    }

    public IEnumerable<Plant> Plants(string student)
    {
        int index = _students.IndexOf(student) * 2;
        char[] plants = [_map[0][index], _map[0][index + 1], _map[1][index], _map[1][index + 1]];
        return plants.Select(c => c switch
        {
            'G' => Plant.Grass,
            'C' => Plant.Clover,
            'R' => Plant.Radishes,
            _ => Plant.Violets
        });
    }
}