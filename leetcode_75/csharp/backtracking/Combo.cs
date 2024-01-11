using System;
using System.Collections.Generic;
using System.Linq;

public class Combo
{
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        List<IList<int>> results = new();
        Stack<int> stack = new();
        FindSum(1, k, n);
        return results;

        void FindSum(int startingValue, int numberOfNumbers, int targetSum)
        {
            if (targetSum is 0 && numberOfNumbers is 0) results.Add(new List<int>(stack));
            if (targetSum is 0 || numberOfNumbers is 0) return;

            for (int value = startingValue; value < 10; value++)
            {
                stack.Push(value);
                FindSum(value + 1, numberOfNumbers - 1, targetSum - value);
                stack.Pop();
            }
        }
    }

    public static void Main(string[] args)
    {
        Combo combo = new Combo();

        // Example 1
        int k1 = 3, n1 = 7;
        IList<IList<int>> result1 = combo.CombinationSum3(k1, n1);
        Console.WriteLine("Example 1 - Combination Sum: " + string.Join(", ", result1.Select(list => "[" + string.Join(", ", list) + "]")));

        // Example 2
        int k2 = 3, n2 = 9;
        IList<IList<int>> result2 = combo.CombinationSum3(k2, n2);
        Console.WriteLine("Example 2 - Combination Sum: " + string.Join(", ", result2.Select(list => "[" + string.Join(", ", list) + "]")));

        // Example 3
        int k3 = 4, n3 = 1;
        IList<IList<int>> result3 = combo.CombinationSum3(k3, n3);
        Console.WriteLine("Example 3 - Combination Sum: " + string.Join(", ", result3.Select(list => "[" + string.Join(", ", list) + "]")));
    }
}
