public class RelativeDistance
{
    private Dictionary<string, HashSet<string>> FamilyTree { get; } = [];

    public RelativeDistance(Dictionary<string, string[]> familyTree)
    {
        foreach (var tree in familyTree)
        {
            if (!FamilyTree.ContainsKey(tree.Key)) FamilyTree.Add(tree.Key, []);
            foreach (var family in tree.Value)
            {
                FamilyTree[tree.Key].Add(family);
                if (!FamilyTree.ContainsKey(family)) FamilyTree.Add(family, []);
                foreach (var other in tree.Value) FamilyTree[family].Add(other);
                FamilyTree[family].Remove(family);
                FamilyTree[family].Add(tree.Key);
            }
        }
    }

    public int DegreeOfSeparation(string personA, string personB)
    {
        HashSet<string> history = [];
        HashSet<string> next = FamilyTree[personA];
        int count = 0;
        while (next.Count != 0)
        {
            var current = next;
            next = [];
            count++;
            foreach (var person in current)
            {
                if (person == personB) return count;
                foreach (var family in FamilyTree[person])
                {
                    if (!history.Add(family)) continue;
                    next.Add(family);
                }
            }
        }
        return -1;
    }
}
