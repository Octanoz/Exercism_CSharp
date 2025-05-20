public class GradeSchool
{
    private readonly IDictionary<string, int> students = new Dictionary<string, int>()
    {
        {"Alice", 4},
        {"Bob", 3},
        {"Charlie", 2},
        {"David", 1},
        {"Eva", 5},
        {"Frank", 4},
        {"Grace", 3},
        {"Hannah", 2},
        {"Ivan", 1},
        {"Julia", 5},
        {"Kevin", 4},
        {"Laura", 3},
        {"Michael", 2},
        {"Nora", 1},
        {"Oliver", 5},
        {"Pamela", 4},
        {"Quincy", 3},
        {"Rachel", 2},
        {"Sam", 1},
        {"Tina", 5}
    };

    public bool Add(string student, int grade)
    {
        if (!students.ContainsKey(student))
        {
            students.Add(student, grade);
            return true;
        }
        else
        {
            System.Console.WriteLine($"{student} is already registered.");
            return false;
        }
    }

    public IEnumerable<string> Roster()
    {
        return students.OrderBy(student => student.Value)
                        .ThenBy(student => student.Key)
                        .Select(student => student.Key);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return students.Where(student => student.Value == grade)
                        .OrderBy(student => student.Key)
                        .Select(student => student.Key);
    }
}