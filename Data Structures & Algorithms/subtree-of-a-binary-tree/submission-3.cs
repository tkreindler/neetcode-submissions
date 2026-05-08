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

public class Solution
{
    
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        ReadOnlyMemory<int> treeSerialized = this.Serialize(root);
        ReadOnlyMemory<int> subTreeSerialized = this.Serialize(subRoot);

        return treeSerialized.Span.IndexOf(subTreeSerialized.Span) >= 0;
    }

    private ReadOnlyMemory<int> Serialize(TreeNode root)
    {
        // preorder serialization
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        var serialized = new List<int>();

        while (stack.Any())
        {
            TreeNode current = stack.Pop();
            if (current is null)
            {
                serialized.Add(int.MinValue);
            }
            else
            {
                stack.Push(current.left);
                stack.Push(current.right);

                serialized.Add(current.val);
            }
        }

        // TODO: avoid an allocation here by using ReadOnlyMemory which references the list object
        return serialized.ToArray().AsMemory();
    }
}
