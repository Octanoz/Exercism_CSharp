/* Instructions
---------------
Implement a clock that handles times without dates.

You should be able to add and subtract minutes to it.

Two clocks that represent the same time should be equal to each other.

This exercise requires you to implement a type-specific method for determining equality of instances. 
For more information, see https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1
 */

Clock clock = new(-1, 0);
Console.WriteLine(clock.Add(198).ToString());