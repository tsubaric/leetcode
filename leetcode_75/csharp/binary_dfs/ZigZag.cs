using System;
using System.Collections.Generic;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class ZigZag {
    public int LongestZigZag(TreeNode root) {
        Queue<(TreeNode, string, int)> q = new Queue<(TreeNode, string, int)>();
        q.Enqueue((root, "", 0));
        int ans = 0;

        while (q.Count > 0) {
            (TreeNode u, string prevDir, int cnt) = q.Dequeue();
            ans = Math.Max(ans, cnt);

            if (u.left != null) {
                if (prevDir == "r")
                    q.Enqueue((u.left, "l", cnt + 1));
                else
                    q.Enqueue((u.left, "l", 1));
            }

            if (u.right != null) {
                if (prevDir == "l")
                    q.Enqueue((u.right, "r", cnt + 1));
                else
                    q.Enqueue((u.right, "r", 1));
            }
        }

        return ans;
    }

    public static void Main(string[] args) {
        // Example 1
        TreeNode root1 = new TreeNode(1,
                            null,
                            new TreeNode(1,
                                new TreeNode(1,
                                    new TreeNode(1),
                                    null),
                                new TreeNode(1,
                                    null,
                                    new TreeNode(1))));

        ZigZag zigzag1 = new ZigZag();
        int result1 = zigzag1.LongestZigZag(root1);

        Console.WriteLine("Example 1:");
        Console.WriteLine("Output: " + result1);
        Console.WriteLine();

        // Example 2
        TreeNode root2 = new TreeNode(1,
                            new TreeNode(1,
                                new TreeNode(1,
                                    null,
                                    new TreeNode(1)),
                                null),
                            new TreeNode(1,
                                null,
                                new TreeNode(1,
                                    null,
                                    new TreeNode(1))));

        ZigZag zigzag2 = new ZigZag();
        int result2 = zigzag2.LongestZigZag(root2);

        Console.WriteLine("Example 2:");
        Console.WriteLine("Output: " + result2);
        Console.WriteLine();

        // Example 3
        TreeNode root3 = new TreeNode(1);

        ZigZag zigzag3 = new ZigZag();
        int result3 = zigzag3.LongestZigZag(root3);

        Console.WriteLine("Example 3:");
        Console.WriteLine("Output: " + result3);
        Console.WriteLine();
    }
}
