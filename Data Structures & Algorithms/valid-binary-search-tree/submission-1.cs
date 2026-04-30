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

#nullable enable

public class Solution {
    public bool IsValidBST(TreeNode root)
    {
        return this.Helper(root, null, null);
    }

    private bool Helper(TreeNode root, int? min, int? max)
    {
        int val = root.val;

        if (min is int minNotNull && val <= minNotNull)
        {
            return false;
        }

        if (max is int maxNotNull && val >= maxNotNull)
        {
            return false;
        }

        TreeNode? left = root.left;
        if (left is not null)
        {
            if (!this.Helper(left, min, val))
            {
                return false;
            }
        }

        TreeNode? right = root.right;
        if (right is not null)
        {
            if (!this.Helper(right, val, max))
            {
                return false;
            }
        }

        return true;
    }
}
