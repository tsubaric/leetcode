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

public class Search {
    public TreeNode SearchBST(TreeNode root, int val) {
        if (root == null || root.val == val)
            return root;

        if (root.val < val)
            return SearchBST(root.right, val);
        else
            return SearchBST(root.left, val);
    }

    public static void PrintTree(TreeNode root) {
        if (root == null)
            return;

        PrintTree(root.left);
        Console.Write(root.val + " ");
        PrintTree(root.right);
    }

    public static void Main(string[] args) {
        // Example 1
        TreeNode root1 = new TreeNode(4,
                            new TreeNode(2,
                                new TreeNode(1),
                                new TreeNode(3)),
                            new TreeNode(7));

        int val1 = 2;
        Search search1 = new Search();
        TreeNode result1 = search1.SearchBST(root1, val1);

        Console.WriteLine("Example 1:");
        if (result1 != null) {
            Console.Write("Output: ");
            PrintTree(result1);
        } else {
            Console.WriteLine("Output: []");
        }
        Console.WriteLine();

        // Example 2
        TreeNode root2 = new TreeNode(4,
                            new TreeNode(2,
                                new TreeNode(1),
                                new TreeNode(3)),
                            new TreeNode(7));

        int val2 = 5;
        Search search2 = new Search();
        TreeNode result2 = search2.SearchBST(root2, val2);

        Console.WriteLine("Example 2:");
        if (result2 != null) {
            Console.Write("Output: ");
            PrintTree(result2);
        } else {
            Console.WriteLine("Output: []");
        }
        Console.WriteLine();
    }
}
