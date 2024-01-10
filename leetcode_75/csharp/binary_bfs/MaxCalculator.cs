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

public class MaxCalculator {
    public int MaxLevelSum(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var traverse = new Queue<TreeNode>();
        traverse.Enqueue(root);

        var max = 1;
        var maxSum = root.val;

        var currentLevel = 0;

        while (traverse.Count != 0)
        {
            currentLevel++;
            var levelCount = traverse.Count;
            var currentLevelSum = 0;

            for (int i = 0; i < levelCount; i++)
            {
                var node = traverse.Dequeue();

                if (node.left != null)
                {
                    traverse.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    traverse.Enqueue(node.right);
                }

                currentLevelSum += node.val;
            }

            if (maxSum < currentLevelSum)
            {
                maxSum = currentLevelSum;
                max = currentLevel;
            }
        }

        return max;
    }
}

class Program {
    static void Main() {
        // Test cases
        TreeNode root1 = new TreeNode(1,
            new TreeNode(7, null, new TreeNode(0)),
            new TreeNode(7, new TreeNode(-8), null)
        );

        MaxCalculator maxCalculator1 = new MaxCalculator();
        Console.WriteLine("Output for Test Case 1: " + maxCalculator1.MaxLevelSum(root1));

        TreeNode root2 = new TreeNode(989,
            null,
            new TreeNode(10250, new TreeNode(98693), new TreeNode(-89388, null, new TreeNode(-32127)))
        );

        MaxCalculator maxCalculator2 = new MaxCalculator();
        Console.WriteLine("Output for Test Case 2: " + maxCalculator2.MaxLevelSum(root2));
    }
}
