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
        if (y < 0 ||
            y >= grid.Length)
        {
            return;
        }

        char[] row = grid[y];

        if (x < 0 ||
            x >= row.Length)
        {
            return;
        }

        if (grid[y][x] != '1')
        {
            // skip water or already visited tiles
            return;
        }

        // mark it as visited
        grid[y][x] = '2';

        // recurse
        this.DepthFirstSearch(grid, y + 1, x); // down
        this.DepthFirstSearch(grid, y - 1, x); // up
        this.DepthFirstSearch(grid, y, x - 1); // left
        this.DepthFirstSearch(grid, y, x + 1); // right
    }
}
