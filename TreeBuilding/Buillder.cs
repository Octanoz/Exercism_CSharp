namespace TreeBuilding;

public class Tree(int id, int parentId)
{
    public int Id { get; } = id;
    public int ParentId { get; } = parentId;

    public List<Tree> Children { get; set; } = [];

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        records = records.OrderBy(r => r.RecordId);
        if (!ValidRecords(records, out string messages))
        {
            throw new ArgumentException(messages);
        }

        return BuildBranch(records.Skip(1), records.First());
    }

    public static Tree BuildBranch(IEnumerable<TreeBuildingRecord> records, TreeBuildingRecord current)
    {
        Tree currentTree = new(current.RecordId, current.ParentId);
        foreach (var record in records.Where(r => r.ParentId == current.RecordId))
        {
            currentTree.Children.Add(BuildBranch(records.Where(r => r.RecordId > current.RecordId), record));
        }

        return currentTree;
    }

    public static bool ValidRecords(IEnumerable<TreeBuildingRecord> records, out string messages)
    {
        if (!records.Any())
        {
            messages = $"No records found.";
            return false;
        }

        messages = "";
        var parentIds = records.Select(r => r.ParentId).Except(records.Select(r => r.RecordId));
        if (parentIds.Any())
        {
            messages = $"Found parent ID(s) that don't have matching record ID(s):\n[ {String.Join(", ", parentIds)} ].\n";
        }

        foreach (var (index, record) in records.Index())
        {
            messages += (index != record.RecordId, record.RecordId, record.ParentId) switch
            {
                (true, _, _) => $"Record ID {index} is missing.\n",
                (_, 0, 0) => "",
                (_, 0, var p) => $"Root has a parent: ID {p}.\n",
                (_, var r, var p) when p >= r => $"Parent ID {p} is greater than or equal to record ID: {r}.\n",
                _ => ""
            };
        }

        return messages == "";
    }

    public static void PrintTree(Tree tree, int level = 0)
    {
        Console.WriteLine($"{new string(' ', level)}{tree.Id} (Parent: {tree.ParentId})");
        foreach (var child in tree.Children)
        {
            PrintTree(child, level + 2);
        }
    }
}

public class TreeBuildingRecord
{
    public int RecordId { get; set; }
    public int ParentId { get; set; }
}