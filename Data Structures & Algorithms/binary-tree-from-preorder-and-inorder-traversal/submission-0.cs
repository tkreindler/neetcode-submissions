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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return this.Helper(new FastQueue(preorder), inorder.AsMemory())!;
    }

    private TreeNode? Helper(FastQueue preorder, ReadOnlyMemory<int> inorder)
    {
        if (!preorder.Any())
        {
            return null;
        }

        int val = preorder.Peek();

        // split the inorder array into two halves
        int middleIndex = inorder.Span.IndexOf(val);

        // not found in inorder array, must belong to the other side, return null
        if (middleIndex < 0)
        {
            return null;
        }

        // it belongs in this side, dequeue it officially
        preorder.Dequeue();

        ReadOnlyMemory<int> leftInorder = inorder.Slice(0, middleIndex);
        ReadOnlyMemory<int> rightInorder = inorder.Slice(middleIndex + 1);

        TreeNode? left = this.Helper(preorder, leftInorder);
        TreeNode? right = this.Helper(preorder, rightInorder);

        return new TreeNode(val, left, right);
    }

    private class FastQueue
    {
        private ReadOnlyMemory<int> buffer;

        public FastQueue(int[] queue)
        {
            this.buffer = queue;
        }

        public bool Any() => this.buffer.Length != 0;

        public int Peek() => this.buffer.Span[0];

        public void Dequeue() => this.buffer = this.buffer.Slice(1);
    }
}
