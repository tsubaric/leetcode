using System;
using System.Collections.Generic;
using System.Linq;

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

public class Leaf {
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        void CollectLeafValues(TreeNode root, List<int> leafValues) {
            if (root == null) {
                return;
            }
            if (root.left == null && root.right == null) {
                leafValues.Add(root.val);
            }
            CollectLeafValues(root.left, leafValues);
            CollectLeafValues(root.right, leafValues);
        }

        List<int> leafValues1 = new List<int>();
        List<int> leafValues2 = new List<int>();
        CollectLeafValues(root1, leafValues1);
        CollectLeafValues(root2, leafValues2);

        return Enumerable.SequenceEqual(leafValues1, leafValues2);
    }
}

class Program {
    static void Main() {
        // Test cases
        TestCase1();
        TestCase2();
    }

    static void TestCase1() {
        TreeNode root1 = new TreeNode(3, 
            new TreeNode(5, new TreeNode(6), new TreeNode(2, new TreeNode(7), new TreeNode(4))),
            new TreeNode(1, new TreeNode(9), new TreeNode(8))
        );

        TreeNode root2 = new TreeNode(3, 
            new TreeNode(5, new TreeNode(6), new TreeNode(7)),
            new TreeNode(1, new TreeNode(4), new TreeNode(2, new TreeNode(9), new TreeNode(8)))
        );

        Leaf leaf = new Leaf();
        Console.WriteLine("Output for Test Case 1: " + leaf.LeafSimilar(root1, root2));
    }

    static void TestCase2() {
        TreeNode root1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        TreeNode root2 = new TreeNode(1, new TreeNode(3), new TreeNode(2));

        Leaf leaf = new Leaf();
        Console.WriteLine("Output for Test Case 2: " + leaf.LeafSimilar(root1, root2));
    }
}
