using Recital;

string[] subjects = ["nail", "shoe", "horse", "rider", "message", "battle", "kingdom", "castle", "dragon", "princess"];

string[] output = Proverb.Recite(subjects);

Console.WriteLine(string.Join("\n", output));
