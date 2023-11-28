namespace Day2;

internal class Program
{
    static void Main(string[] args)
    {
        var file = File.ReadAllLines("input.txt");
        var input = new List<string>(file);
        var win = 6;
        var draw = 3;
        var lose = 0;

        var myRock = ("Y", 1);
            
        var score = 0;

        foreach (var set in input)
        {
            var splitSet = set.Split(' ');
            if (splitSet[0] == "A" && splitSet[1] == "Y")
                score += win;
            else if (splitSet[0] == "B" && splitSet[1] == "X")
                score += lose;
        }
    }
}