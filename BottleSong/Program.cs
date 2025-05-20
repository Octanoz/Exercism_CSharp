using BottleSong;

string[] lyrics = GreenBottleSinger.Recite(3, 1);
Console.WriteLine($"[ {String.Join("", lyrics)} ]");