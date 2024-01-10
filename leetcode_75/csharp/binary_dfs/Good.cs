using System;

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

public class Good {
    public int goodNodes = 0;

    public int GoodNodes(TreeNode root) {
        if (root == null) {
            return 0;
        }
        if (root.left == null && root.right == null) {
            return 1;
        }
        GetGoodNodeCount(root, root.val);
        return goodNodes;
    }

    public void GetGoodNodeCount(TreeNode root, int currentMax) {
        if (root == null) {
            return;
        }
        if (root.val >= currentMax) {
            currentMax = root.val;
            goodNodes++;
        }

        GetGoodNodeCount(root.left, currentMax);
        GetGoodNodeCount(root.right, currentMax);
    }

    public static void Main(string[] args) {
        // Example 1
        TreeNode root1 = new TreeNode(3,
                            new TreeNode(1,
                                new TreeNode(3),
                                new TreeNode(1, null, new TreeNode(5))),
                            new TreeNode(4));

        Good good1 = new Good();
        int result1 = good1.GoodNodes(root1);

        Console.WriteLine("Example 1:");
        Console.WriteLine("Output: " + result1);
        Console.WriteLine();

        // Example 2
        TreeNode root2 = new TreeNode(3,
                            new TreeNode(3, null, new TreeNode(4, null, new TreeNode(2))));

        Good good2 = new Good();
        int result2 = good2.GoodNodes(root2);

        Console.WriteLine("Example 2:");
        Console.WriteLine("Output: " + result2);
        Console.WriteLine();

        // Example 3
        TreeNode root3 = new TreeNode(1);

        Good good3 = new Good();
        int result3 = good3.GoodNodes(root3);

        Console.WriteLine("Example 3:");
        Console.WriteLine("Output: " + result3);
        Console.WriteLine();
    }
}
