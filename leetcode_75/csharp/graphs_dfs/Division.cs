using System;
using System.Collections.Generic;

public class Division
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        // Create a dictionary to store the graph weights
        var graph = new Dictionary<string, Dictionary<string, double>>();

        // Iterate through the equations list to populate the graph
        for (int i = 0; i < equations.Count; i++)
        {
            string a = equations[i][0], b = equations[i][1];
            if (!graph.ContainsKey(a)) graph[a] = new Dictionary<string, double>();
            if (!graph.ContainsKey(b)) graph[b] = new Dictionary<string, double>();
            graph[a][b] = values[i];
            graph[b][a] = 1 / values[i]; // If A/B=w then B/A=1/w
        }

        // Define a helper function to perform DFS and calculate the product of weights
        double DFS(string start, string end, ISet<string> visited)
        {
            if (!graph.ContainsKey(start) || !visited.Add(start)) 
                return -1; // If the start node is not in the graph or has already been visited, return -1
            if (start == end) 
                return 1; // If the start and end nodes are the same, return 1 (the product of the weights so far)
            foreach (var neighbor in graph[start])
            {
                double product = DFS(neighbor.Key, end, visited); // Recursively explore the neighbors
                if (product > 0) 
                    return neighbor.Value * product; // If a solution is found, return the product of weights
            }
            return -1; // If no solution is found, return -1
        }

        // Iterate through the queries list to perform DFS and find the answers
        var results = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++)
        {
            string a = queries[i][0], b = queries[i][1];
            results[i] = DFS(a, b, new HashSet<string>());
        }

        return results;
    }

    public static void Main(string[] args)
    {
        // Example 1
        var equations1 = new List<IList<string>> { new List<string> {"a","b"}, new List<string> {"b","c"} };
        var values1 = new double[] {2.0, 3.0};
        var queries1 = new List<IList<string>> { new List<string> {"a","c"}, new List<string> {"b","a"}, new List<string> {"a","e"}, new List<string> {"a","a"}, new List<string> {"x","x"} };
        Division division1 = new Division();
        var result1 = division1.CalcEquation(equations1, values1, queries1);
        Console.WriteLine("Example 1 - Results: [" + string.Join(", ", result1) + "]");

        // Example 2
        var equations2 = new List<IList<string>> { new List<string> {"a","b"}, new List<string> {"b","c"}, new List<string> {"bc","cd"} };
        var values2 = new double[] {1.5, 2.5, 5.0};
        var queries2 = new List<IList<string>> { new List<string> {"a","c"}, new List<string> {"c","b"}, new List<string> {"bc","cd"}, new List<string> {"cd","bc"} };
        Division division2 = new Division();
        var result2 = division2.CalcEquation(equations2, values2, queries2);
        Console.WriteLine("Example 2 - Results: [" + string.Join(", ", result2) + "]");

        // Example 3
        var equations3 = new List<IList<string>> { new List<string> {"a","b"} };
        var values3 = new double[] {0.5};
        var queries3 = new List<IList<string>> { new List<string> {"a","b"}, new List<string> {"b","a"}, new List<string> {"a","c"}, new List<string> {"x","y"} };
        Division division3 = new Division();
        var result3 = division3.CalcEquation(equations3, values3, queries3);
        Console.WriteLine("Example 3 - Results: [" + string.Join(", ", result3) + "]");
    }
}
