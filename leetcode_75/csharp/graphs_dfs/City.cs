using System;
using System.Collections.Generic;

public class City
{
    private readonly Dictionary<int, List<(int city, bool direction)>> _graph = new();
    private readonly HashSet<int> _visited = new();
    private int _result;

    public int MinReorder(int n, int[][] connections)
    {
        foreach (var connection in connections)
        {
            var cityA = connection[0];
            var cityB = connection[1];

            _graph[cityA] = _graph.GetValueOrDefault(cityA, new List<(int, bool)>());
            _graph[cityA].Add((cityB, true));

            _graph[cityB] = _graph.GetValueOrDefault(cityB, new List<(int, bool)>());
            _graph[cityB].Add((cityA, false));
        }

        dfs(0);

        return _result;
    }

    private void dfs(int city)
    {
        _visited.Add(city);

        foreach (var (node, direction) in _graph[city])
        {
            if (_visited.Contains(node)) continue;

            if (direction)
            {
                ++_result;
            }

            dfs(node);
        }
    }

    public static void Main(string[] args)
    {
        // Example 1
        int n1 = 6;
        int[][] connections1 = { new int[] {0, 1}, new int[] {1, 3}, new int[] {2, 3}, new int[] {4, 0}, new int[] {4, 5} };
        City city1 = new City();
        int result1 = city1.MinReorder(n1, connections1);
        Console.WriteLine("Example 1 - Minimum edges changed: " + result1);

        // Example 2
        int n2 = 5;
        int[][] connections2 = { new int[] {1, 0}, new int[] {1, 2}, new int[] {3, 2}, new int[] {3, 4} };
        City city2 = new City();
        int result2 = city2.MinReorder(n2, connections2);
        Console.WriteLine("Example 2 - Minimum edges changed: " + result2);

        // Example 3
        int n3 = 3;
        int[][] connections3 = { new int[] {1, 0}, new int[] {2, 0} };
        City city3 = new City();
        int result3 = city3.MinReorder(n3, connections3);
        Console.WriteLine("Example 3 - Minimum edges changed: " + result3);
    }
}
