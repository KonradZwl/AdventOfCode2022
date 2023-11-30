var file = File.ReadAllLines("input.txt");
var input = new List<string>(file);
int sum = 0;

foreach (var line in input)
{
    //Prepare
    var set1 = new HashSet<char>(line.Take(line.Length / 2).ToArray());
    var set2 = new HashSet<char>(line.Skip(line.Length / 2).ToArray());
    Dictionary<char, int> alphabetLookup = new Dictionary<char, int>();
    
    for (char c = 'a'; c <= 'z'; c++)
    {
        alphabetLookup[c] = c - 'a' + 1;
        alphabetLookup[char.ToUpper(c)] = char.ToUpper(c) - 'A' + 27;
    }

    //Per line find common letter
    set1.IntersectWith(set2);
    var commonLetter = set1.First();
    
    //Get value of that letter and Add value to the sum
    sum += getValueOfLetter(commonLetter);
    
    //Methods
    int getValueOfLetter(char commonLetter)
    {
        return alphabetLookup[commonLetter];
    }
}

Console.WriteLine(sum);
