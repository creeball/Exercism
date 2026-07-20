public class GradeSchool
{
    private readonly Dictionary<string, int> _students = new();
    public bool Add(string student, int grade) =>
        _students.TryAdd(student, grade);

    public IEnumerable<string> Roster() =>
        from student in _students
        orderby student.Value, student.Key
        select student.Key;

    public IEnumerable<string> Grade(int grade) => 
        from student in _students
        where student.Value == grade
        orderby student.Key
        select student.Key;
}