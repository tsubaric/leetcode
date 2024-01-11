using System;
using System.Collections.Generic;

public class KeyRoom {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        if(rooms.Count < 2) { return true; }
        var toVisit = new Stack<int>();
        var Visited = new List<int>();
        Visited.Add(0);
        var current = 0;
        foreach(var key in rooms[0]) {
            toVisit.Push(key);
        }
        while(toVisit.Count != 0) {
            var next = current;
            while(Visited.Contains(next)) {
                if(toVisit.Count == 0) { break;} 
                next = toVisit.Pop();
            }
            if(next == current) { break; }
            current = next;
            if(!Visited.Contains(current)) { Visited.Add(current); }
            foreach(var key in rooms[current]) {
                if(!Visited.Contains(key)) {
                    toVisit.Push(key);
                }
            }
        }
        return Visited.Count == rooms.Count;
    }
}

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
