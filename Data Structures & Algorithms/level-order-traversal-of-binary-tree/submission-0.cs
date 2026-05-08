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
    public List<List<int>> LevelOrder(TreeNode root)
    {
        // breadth first search makes this quite simple
        var queue = new Queue<(TreeNode node, int height)>();

        if (root is not null)
        {
            queue.Enqueue((root, 0));
        }

        var results = new List<List<int>>();

        while (queue.Any())
        {
            (TreeNode current, int height) = queue.Dequeue();

            if (height >= results.Count)
            {
                if (height != results.Count)
                {
                    throw new NotImplementedException(current.val.ToString());
                }

                results.Add(new List<int>());
            }

            results[height].Add(current.val);

            if (current.left is not null)
            {
                queue.Enqueue((current.left, height + 1));
            }

            if (current.right is not null)
            {
                queue.Enqueue((current.right, height + 1));
            }
        }

        return results;
    }
}
