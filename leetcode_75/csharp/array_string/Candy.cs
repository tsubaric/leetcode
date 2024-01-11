public class Candy {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        int mostCandies = candies.Max();
        return candies.Select(
            candyAmount => candyAmount + extraCandies >= mostCandies
        ).ToList();
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        KeyRoom keyRoomObj = new KeyRoom();

        // Example 1
        List<List<int>> rooms1 = new List<List<int>> {
            new List<int> { 1 },
            new List<int> { 2 },
            new List<int> { 3 },
            new List<int> { }
        };
        bool result1 = keyRoomObj.CanVisitAllRooms(rooms1);
        Console.WriteLine("Output 1: " + result1);

        // Example 2
        List<List<int>> rooms2 = new List<List<int>> {
            new List<int> { 1, 3 },
            new List<int> { 3, 0, 1 },
            new List<int> { 2 },
            new List<int> { 0 }
        };
        bool result2 = keyRoomObj.CanVisitAllRooms(rooms2);
        Console.WriteLine("Output 2: " + result2);
    }
}
