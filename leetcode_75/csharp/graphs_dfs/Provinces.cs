using System;

public class Provinces {
    private int[] parent;

    public int FindCircleNum(int[][] isConnected) {
        parent = new int[isConnected.Length];
        for (var i = 0; i < isConnected.Length; i++) {
            parent[i] = i;
        }

        for (var i = 0; i < isConnected.Length; i++) {
            for (var j = 0; j < isConnected[0].Length; j++) {
                if (isConnected[i][j] == 1) {
                    union(i, j);
                }
            }
        }

        int count = 0;
        for (var i = 0; i < parent.Length; i++) {
            if (findParent(i) == i) count++;
        }
        return count;
    }

    private int findParent(int x) {
        if (parent[x] != x) {
            parent[x] = findParent(parent[x]);
        }
        return parent[x];
    }

    private void union(int x, int y) {
        parent[findParent(x)] = parent[findParent(y)];
    }

    public static void Main(string[] args) {
        // Example 1
        int[][] isConnected1 = { new int[] {1, 1, 0}, new int[] {1, 1, 0}, new int[] {0, 0, 1} };
        Provinces provinces = new Provinces();
        int result1 = provinces.FindCircleNum(isConnected1);
        Console.WriteLine("Example 1 - Total number of provinces: " + result1);

        // Example 2
        int[][] isConnected2 = { new int[] {1, 0, 0}, new int[] {0, 1, 0}, new int[] {0, 0, 1} };
        int result2 = provinces.FindCircleNum(isConnected2);
        Console.WriteLine("Example 2 - Total number of provinces: " + result2);
    }
}
