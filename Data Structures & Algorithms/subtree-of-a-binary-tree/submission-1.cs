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

public class Solution {
    private readonly Dictionary<(TreeNode lhs, TreeNode rhs), bool> cache = new ();

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        // subRoot remains the same and can never be null
        if (root is null)
        {
            return false;
        }

        if (this.IsIdentical(root, subRoot))
        {
            return true;
        }

        return
            this.IsSubtree(root.left, subRoot) ||
            this.IsSubtree(root.right, subRoot);
    }

    private bool IsIdentical(TreeNode leftRoot, TreeNode rightRoot)
    {
        if (leftRoot is null)
        {
            return rightRoot is null;
        }

        if (rightRoot is null)
        {
            return false;
        }

        if (this.cache.TryGetValue((leftRoot, rightRoot), out bool isIdenticalCached))
        {
            return isIdenticalCached;
        }


        bool isIdentical = leftRoot.val == rightRoot.val &&
            this.IsIdentical(leftRoot.left, rightRoot.left) &&
            this.IsIdentical(leftRoot.right, rightRoot.right);

        this.cache[(leftRoot, rightRoot)] = isIdentical;

        return isIdentical;
    }
}
