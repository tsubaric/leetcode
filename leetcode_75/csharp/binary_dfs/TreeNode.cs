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

public class Solution {
    private class NodeWithHeight {
        public TreeNode Node;
        public int Height;

        public NodeWithHeight(TreeNode node, int height) {
            Node = node;
            Height = height;
        }
    }

    public int MaxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int height = 1;
        Stack<NodeWithHeight> stack = new Stack<NodeWithHeight>();
        stack.Push(new NodeWithHeight(root, height));

        while (stack.Count > 0) {
            NodeWithHeight cur = stack.Pop();

            if (cur.Node.left != null) {
                stack.Push(new NodeWithHeight(cur.Node.left, cur.Height + 1));
            }

            if (cur.Node.right != null) {
                stack.Push(new NodeWithHeight(cur.Node.right, cur.Height + 1));
            }

            height = Math.Max(height, cur.Height);
        }

        return height;
    }

    public static void Main() {
        // Example usage:
        TreeNode root1 = new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20,
                new TreeNode(15),
                new TreeNode(7)
            )
        );

        Console.WriteLine("Maximum Depth: " + MaxDepth(root1));

        TreeNode root2 = new TreeNode(1, null, new TreeNode(2));
        Console.WriteLine("Maximum Depth: " + MaxDepth(root2));
    }
}
