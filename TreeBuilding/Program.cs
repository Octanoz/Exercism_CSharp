
using TreeBuilding;

List<TreeBuildingRecord> records =
[
    new TreeBuildingRecord { RecordId = 5, ParentId = 2 },
    new TreeBuildingRecord { RecordId = 3, ParentId = 9 },
    new TreeBuildingRecord { RecordId = 2, ParentId = 28 },
    new TreeBuildingRecord { RecordId = 4, ParentId = 16 },
    new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
    new TreeBuildingRecord { RecordId = 0, ParentId = 8 },
    new TreeBuildingRecord { RecordId = 6, ParentId = 2 }
];

Tree root = TreeBuilder.BuildTree(records);

Console.WriteLine($"{root.Id} is root, it's parent ID is {root.ParentId}.");
Console.WriteLine($"The root is also a leaf: {root.IsLeaf}\n");

TreeBuilder.PrintTree(root);