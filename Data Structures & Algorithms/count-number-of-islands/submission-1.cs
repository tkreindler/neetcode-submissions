public class Solution {
    public int NumIslands(char[][] grid)
    {
        int islandCount = 0;

        for (int y = 0; y < grid.Length; y++)
        {
            char[] row = grid[y];
            for (int x = 0; x < row.Length; x++)
            {
                if (grid[y][x] == '1')
                {
                    islandCount += 1;
                    this.DepthFirstSearch(grid, y, x);
                }
            }
        }

        return islandCount;
    }

    // Does a depth first search, marking all points for this island as '2', representing visited
    public void DepthFirstSearch(char[][] grid, int y, int x)
    {
        var stack = new Stack<(int y, int x)>();
        stack.Push((y: y, x: x));

        while (stack.Any())
        {
            (y, x) = stack.Pop();

            if (y < 0 ||
                y >= grid.Length)
            {
                continue;
            }

            char[] row = grid[y];

            if (x < 0 ||
                x >= row.Length)
            {
                continue;
            }

            if (grid[y][x] != '1')
            {
                // skip water or already visited tiles
                continue;
            }

            // mark it as visited
            grid[y][x] = '2';

            // recurse
            stack.Push((y: y + 1, x: x)); // down
            stack.Push((y: y - 1, x: x)); // up
            stack.Push((y: y, x: x - 1)); // left
            stack.Push((y: y, x: x + 1)); // right
        }
    }
}
