public class TreeBuildingRecord
{
    public int ParentId { get; set; }

    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    
    public int ParentId { get; set; }
    
    public List<Tree> Children { get; set; } = [];

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        Dictionary<int, int> treeDictionary = new();
        var treeBuildingRecords = records.ToList();
        if (treeBuildingRecords.Count == 0) throw new ArgumentException();
        foreach (var record in treeBuildingRecords)
        {
            if (record.RecordId >= treeBuildingRecords.Count) throw new ArgumentException();
            if (record.RecordId < 0 || record.ParentId < 0) throw new ArgumentException();
            if (record.RecordId != 0 && record.RecordId <= record.ParentId) throw new ArgumentException();
            if (!treeDictionary.TryAdd(record.RecordId, record.ParentId)) throw new ArgumentException();
        }
        if (treeDictionary[0] != 0) throw new ArgumentException();
        List<Tree> treeList = new();
        treeList.Add(new Tree { Id = 0 });
        for (int i = 1; i < treeBuildingRecords.Count; i++)
        {
            treeList.Add(new Tree
            {
                Id = i,
                ParentId = treeDictionary[i]
            });
            treeList[treeDictionary[i]].Children.Add(treeList[i]);
        }
        return treeList[0];
    }
}