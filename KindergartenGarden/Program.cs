using KindergartenGarden;

string test1 = "RC\nGG";
string test2 = "VC\nRC";
string test3 = "VVCG\nVVRC";

Garden garden = new(test1);

var result = garden.Plants("Alice");

foreach (var plant in result)
{
    Console.WriteLine(plant);
}