using System.Reflection;
using DnD;

DndCharacter phillip = DndCharacter.Generate();
Console.WriteLine("Phillip's character sheet:\n");

PropertyInfo[] properties = typeof(DndCharacter).GetProperties();
foreach (var property in properties)
{
    string propertyName = $"{property.Name}:";
    Console.WriteLine($"{propertyName,-15} {property.GetValue(phillip)}");
}
