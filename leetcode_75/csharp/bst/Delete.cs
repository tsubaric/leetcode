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

public class Delete {
    public TreeNode DeleteNode(TreeNode root, int key) {
        return DeleteNodeHelper(root, key);
    }

    private TreeNode DeleteNodeHelper(TreeNode node, int key) {
        if (node == null)
            return null;

        node.left = DeleteNodeHelper(node.left, key);
        node.right = DeleteNodeHelper(node.right, key);

        if (node.val != key)
            return node;

        if (node.right == null)
            return node.left;

        if (node.left == null)
            return node.right;

        return MoveLeftToRight(node);
    }

    private TreeNode MoveLeftToRight(TreeNode node) {
        TreeNode left = node.left;
        TreeNode baseRight = node.right;
        TreeNode right = node.right;

        while (right.left != null)
            right = right.left;

        right.left = left;
        return baseRight;
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
        TreeNode root1 = new TreeNode(5,
                            new TreeNode(3,
                                new TreeNode(2),
                                new TreeNode(4)),
                            new TreeNode(6, null, new TreeNode(7)));

        int key1 = 3;
        Delete delete1 = new Delete();
        TreeNode result1 = delete1.DeleteNode(root1, key1);

        Console.WriteLine("Example 1:");
        PrintTree(result1);
        Console.WriteLine();

        // Example 2
        TreeNode root2 = new TreeNode(5,
                            new TreeNode(3,
                                new TreeNode(2),
                                new TreeNode(4)),
                            new TreeNode(6, null, new TreeNode(7)));

        int key2 = 0;
        Delete delete2 = new Delete();
        TreeNode result2 = delete2.DeleteNode(root2, key2);

        Console.WriteLine("Example 2:");
        PrintTree(result2);
        Console.WriteLine();

        // Example 3
        TreeNode root3 = null;
        int key3 = 0;
        Delete delete3 = new Delete();
        TreeNode result3 = delete3.DeleteNode(root3, key3);

        Console.WriteLine("Example 3:");
        if (result3 != null) {
            PrintTree(result3);
        } else {
            Console.WriteLine("Output: []");
        }
        Console.WriteLine();
    }
}
