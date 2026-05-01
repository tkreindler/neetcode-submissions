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
    public bool IsBalanced(TreeNode root)
    {
        int? balancedHeight = this.Helper(root);

        return balancedHeight is not null;
    }


    // returns null if unbalanced, height otherwise
    private int? Helper(TreeNode? node)
    {
        if (node is null)
        {
            return 0;
        }
        
        int? leftHeight = this.Helper(node.left);
        if (leftHeight is null)
        {
            return null;
        }
        
        int? rightHeight = this.Helper(node.right);
        if (rightHeight is null)
        {
            return null;
        }

        if (Math.Abs(leftHeight.Value - rightHeight.Value) > 1)
        {
            // heights are too different, whole tree is unbalanced
            return null;
        }

        return Math.Max(leftHeight.Value, rightHeight.Value) + 1;
    }
}
