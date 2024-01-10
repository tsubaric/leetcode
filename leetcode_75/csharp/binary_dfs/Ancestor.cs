using System;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x) {
        val = x;
    }
}

public class Ancestor {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
            return null;

        if (root.val == p.val || root.val == q.val)
            return root;

        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null)
            return root;

        return left ?? right;
    }

    public static void Main(string[] args) {
        // Example 1
        TreeNode root1 = new TreeNode(3,
                            new TreeNode(5,
                                new TreeNode(6),
                                new TreeNode(2,
                                    new TreeNode(7),
                                    new TreeNode(4))),
                            new TreeNode(1,
                                new TreeNode(0),
                                new TreeNode(8)));

        TreeNode p1 = new TreeNode(5);
        TreeNode q1 = new TreeNode(1);

        Ancestor ancestor1 = new Ancestor();
        TreeNode result1 = ancestor1.LowestCommonAncestor(root1, p1, q1);

        Console.WriteLine("Example 1:");
        Console.WriteLine("Output: " + result1.val);
        Console.WriteLine();

        // Example 2
        TreeNode root2 = new TreeNode(3,
                            new TreeNode(5,
                                new TreeNode(6),
                                new TreeNode(2,
                                    new TreeNode(7),
                                    new TreeNode(4))),
                            new TreeNode(1,
                                new TreeNode(0),
                                new TreeNode(8)));

        TreeNode p2 = new TreeNode(5);
        TreeNode q2 = new TreeNode(4);

        Ancestor ancestor2 = new Ancestor();
        TreeNode result2 = ancestor2.LowestCommonAncestor(root2, p2, q2);

        Console.WriteLine("Example 2:");
        Console.WriteLine("Output: " + result2.val);
        Console.WriteLine();

        // Example 3
        TreeNode root3 = new TreeNode(1,
                            new TreeNode(2),
                            null);

        TreeNode p3 = new TreeNode(1);
        TreeNode q3 = new TreeNode(2);

        Ancestor ancestor3 = new Ancestor();
        TreeNode result3 = ancestor3.LowestCommonAncestor(root3, p3, q3);

        Console.WriteLine("Example 3:");
        Console.WriteLine("Output: " + result3.val);
        Console.WriteLine();
    }
}
