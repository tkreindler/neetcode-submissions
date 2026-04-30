#nullable enable

public class Solution {
    public bool ValidTree(int n, int[][] edges)
    {
        // Tree means it's a graph and no cycles
        // Math trick is that |edges| == n-1 for a tree
        return edges.Length == n - 1 &&
               this.DepthFirstIsGraph(n, edges);
    }

    private bool DepthFirstIsGraph(int n, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        var dictionary = new Dictionary<int, List<int>>(n);
        foreach (IReadOnlyList<int> edge in edges)
        {
            // Add edge in both directions
            this.AddEdge(dictionary, edge[0], edge[1]);
            this.AddEdge(dictionary, edge[1], edge[0]);
        }

        // TODO optimize this with a better heuristic or an early check
        var stack = new Stack<int>(edges.Count);

        // arbitrary starting position, start with 0, could be any number
        stack.Push(0);

        while (stack.Any())
        {
            int node = stack.Pop();

            // remove from dictionary to signify it's used
            if (dictionary.Remove(node, out List<int>? joinedNodes))
            {
                foreach (int joinedNode in joinedNodes)
                {
                    stack.Push(joinedNode);
                }
            }
        }

        return dictionary.Count == 0;
    }

    private void AddEdge(Dictionary<int, List<int>> dictionary, int edgeStart, int edgeEnd)
    {
        // TODO optimize with CollectionsMarshal
        if (dictionary.ContainsKey(edgeStart))
        {
            // no dedup needed, edges are unique
            dictionary[edgeStart].Add(edgeEnd);
        }
        else
        {
            dictionary[edgeStart] = [ edgeEnd ];
        }
    }
}
