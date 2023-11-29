namespace Day2;

internal class Program
{
    static string[][] outcomes =
    {
        new []{ "CX", "AY", "BZ" }, 
        new []{ "AX", "BY", "CZ"}, 
        new []{ "BX", "CY", "AZ"}
    };
    static void Main(string[] args)
    {
        var file = File.ReadAllLines("input.txt");
        var input = new List<string>(file);
        Part1(input);
        Part2(input);
    }

    static void Part1(List<string> input)
    {

        var score = 0;
        foreach (var set in input)
        {
            var splitSet = set.Split(" ");
            var newSet = splitSet[0] + splitSet[1];
            
            for (int i = 0; i < outcomes.Length; i++)
            {
                for (int j = 0; j < outcomes[i].Length; j++)
                {
                    if (newSet == outcomes[i][j])
                    {
                        score += GetScore(newSet, outcomes);
                    }
                }
            }
        }
        Console.WriteLine(score);
    }

    static void Part2(List<string> input)
    {
        
        var score = 0;
        
        for (int i = 0; i < input.Count; i++)
        {
            var splitSet = input[i].Split(" ");
            var newSet = splitSet[0] + splitSet[1];
            for(int j = 0; j < outcomes.Length; j++)
            {
                for (int k = 0; k < outcomes[j].Length; k++)
                {
                    if (newSet == outcomes[j][k])
                    {
                        string requiredMove = GetMoveThat(splitSet[0], splitSet[1], outcomes);
                        score += GetScore(requiredMove, outcomes);
                    }
                }
            }

        }
        Console.WriteLine(score);
    }

    static string GetMoveThat(string move, string condition, string[][] outcomes)
    {
        switch (condition)
        {
            case "Z":
                return outcomes[0].First(x => x.Contains(move));
            case "Y":
                return outcomes[1].First(x => x.Contains(move));
            case "X":
                return outcomes[2].First(x => x.Contains(move));
        }
        return "";
    }

    static int GetScore(string move, string[][] outcomes)
    {
        var score = 0;
        for (int i = 0; i < outcomes.Length; i++)
        {
            for (int j = 0; j < outcomes[i].Length; j++)
            {
                if (move == outcomes[i][j])
                {
                    score += GetScoreOutcome(i);
                    score += GetScoreMove(j);
                }
            }
        }
        return score;
    }

    static int GetScoreMove(int j)
    {
        return j switch
        {
            0 => 1,
            1 => 2,
            2 => 3
        };
    }

    static int GetScoreOutcome(int i)
    {
        return i switch
        {
            0 => 6,
            1 => 3,
            2 => 0
        };
    }
}