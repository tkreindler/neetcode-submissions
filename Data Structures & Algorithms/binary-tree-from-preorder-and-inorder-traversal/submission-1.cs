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
        var inorderIndicesDictionary = new Dictionary<int, int>(inorder.Length);
        for (int i = 0; i < inorder.Length; i++)
        {
            int val = inorder[i];
            inorderIndicesDictionary[val] = i;
        }

        return this.Helper(
            new FastQueue(preorder),
            inorderIndicesDictionary,
            0,
            inorder.Length)!;
    }

    private TreeNode? Helper(FastQueue preorder, IReadOnlyDictionary<int, int> inorderIndicesDictionary, int minInorderIndex, int maxInorderIndex)
    {
        if (!preorder.Any())
        {
            return null;
        }

        int val = preorder.Peek();

        // split the inorder array into two halves
        int middleIndex = inorderIndicesDictionary[val];

        // not found in inorder array, must belong to the other side, return null
        if (middleIndex < minInorderIndex || middleIndex >= maxInorderIndex)
        {
            return null;
        }

        // it belongs in this side, dequeue it officially
        preorder.Dequeue();

        TreeNode? left = this.Helper(preorder, inorderIndicesDictionary, minInorderIndex, middleIndex);
        TreeNode? right = this.Helper(preorder, inorderIndicesDictionary, middleIndex + 1, maxInorderIndex);

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
