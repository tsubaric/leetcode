/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
using System;
using System.Collections.Generic;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Right {
    public IList<int> RightSideView(TreeNode root) {
        if (root == null) return new List<int>();

        List<int> result = new List<int>();

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> currentLevelValues = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();
                currentLevelValues.Add(node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            result.Add(currentLevelValues[currentLevelValues.Count - 1]);
        }

        return result;
    }
}

class Program {
    static void Main() {
        // Test case
        TreeNode root = new TreeNode(1,
            new TreeNode(2, null, new TreeNode(5)),
            new TreeNode(3, null, new TreeNode(4))
        );

        Right right = new Right();
        IList<int> rightSideView = right.RightSideView(root);

        Console.WriteLine("Right Side View: " + string.Join(", ", rightSideView));
    }
}
