namespace Day1;

internal class Program
{
    static void Main(string[] args)
    {
        var file = File.ReadAllLines("input.txt");
        var input = new List<string>(file);

        Part1(input);
        Part2(input);
    }
    public static void Part1(List<string> input)
    {
        int maxCalories = 0;
        int groupTotalCalories = 0;
            
        foreach (var line in input)
        {
            if (line == "")
            {
                if (groupTotalCalories > maxCalories)
                    maxCalories = groupTotalCalories;
                groupTotalCalories = 0;
            }
            else 
                groupTotalCalories += int.Parse(line);
        }
        Console.WriteLine(maxCalories);
    }
    public static void Part2(List<string> input)
    {
        int groupTotalCalories = 0;
        int[] leaders = {0,0,0};
            
        foreach (var line in input)
        {
            if (line == "")
            {
                for (var i = leaders.Length - 1; i >= 0; i--)
                {
                    if (groupTotalCalories <= leaders[i]) continue;
                        
                    if (i != leaders.Length - 1)
                    {
                        leaders[i+1] = leaders[i];
                    }
                    leaders[i] = groupTotalCalories;
                }
                groupTotalCalories = 0;
            }else groupTotalCalories += int.Parse(line);
        }
        Console.WriteLine(leaders[0] + leaders[1] + leaders[2]);
    }
}