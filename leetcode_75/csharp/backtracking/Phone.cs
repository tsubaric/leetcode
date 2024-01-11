public class Phone
{
    private readonly Dictionary<char, string> map = new()
    {
        {'2', "abc" }, {'3', "def"},
        {'4', "ghi"}, {'5', "jkl"}, {'6', "mno"},
        {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}
    };

    public IList<string> LetterCombinations(string digits)
    {
        List<string> combinations = new();
        if (string.IsNullOrEmpty(digits))
        {
            return combinations;
        }

        GenerateCombinations(digits, 0, "", combinations);
        return combinations;
    }

    private void GenerateCombinations(string digits, int index, string current, List<string> combinations)
    {
        if (index == digits.Length)
        {
            combinations.Add(current);
            return;
        }

        foreach (var letter in map[digits[index]])
        {
            GenerateCombinations(digits, index + 1, current + letter, combinations);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Phone phone = new Phone();

        // Example 1
        string digits1 = "23";
        IList<string> result1 = phone.LetterCombinations(digits1);
        Console.WriteLine($"Example 1 - Letter Combinations: [{string.Join(", ", result1)}]");

        // Example 2
        string digits2 = "";
        IList<string> result2 = phone.LetterCombinations(digits2);
        Console.WriteLine($"Example 2 - Letter Combinations: [{string.Join(", ", result2)}]");

        // Example 3
        string digits3 = "2";
        IList<string> result3 = phone.LetterCombinations(digits3);
        Console.WriteLine($"Example 3 - Letter Combinations: [{string.Join(", ", result3)}]");
    }
}

