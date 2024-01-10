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

public class Path {
    public int PathSum(TreeNode root, int targetSum) {
        if (root == null)
            return 0;

        return Dfs(root, targetSum)
            + PathSum(root.left, targetSum)
            + PathSum(root.right, targetSum);
    }

    private int Dfs(TreeNode node, long sum) {
        var s = node.val == sum ? 1 : 0;

        if (node.left != null)
            s += Dfs(node.left, sum - node.val);

        if (node.right != null)
            s += Dfs(node.right, sum - node.val);

        return s;
    }

    public static void Main(string[] args) {
        // Example 1
        TreeNode root1 = new TreeNode(10,
                            new TreeNode(5,
                                new TreeNode(3,
                                    new TreeNode(3),
                                    new TreeNode(-2)),
                                new TreeNode(2, null, new TreeNode(1))),
                            new TreeNode(-3, null, new TreeNode(11)));

        int targetSum1 = 8;
        Path path1 = new Path();
        int result1 = path1.PathSum(root1, targetSum1);

        Console.WriteLine("Example 1:");
        Console.WriteLine("Output: " + result1);
        Console.WriteLine();

        // Example 2
        TreeNode root2 = new TreeNode(5,
                            new TreeNode(4,
                                new TreeNode(11,
                                    new TreeNode(7),
                                    new TreeNode(2))),
                            new TreeNode(8,
                                new TreeNode(13),
                                new TreeNode(4,
                                    new TreeNode(5),
                                    new TreeNode(1))));

        int targetSum2 = 22;
        Path path2 = new Path();
        int result2 = path2.PathSum(root2, targetSum2);

        Console.WriteLine("Example 2:");
        Console.WriteLine("Output: " + result2);
        Console.WriteLine();
    }
}
